namespace ET.Server
{
    [MessageSessionHandler(SceneType.MrLobby)]
    public class MrC2Lobby_Login__Handler: MessageSessionHandler<MrC2Lobby_Login, MrLobby2C_Login>
    {
        protected override async ETTask Run(Session session, MrC2Lobby_Login request, MrLobby2C_Login response)
        {
            Scene root = session.Root();
            string account = root.GetComponent<MrLobbySessionKeyMgr>().Get(request.Key);
            if (account == null)
            {
                response.Error = ErrorCore.ERR_ConnectGateKeyError;
                response.Message = "login key验证失败!";
                return;
            }
            
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            var playerComponent = root.GetComponent<MrPlayerMgr>();
            var player = playerComponent.GetByAccount(account);
            if (player == null)
            {
                player = playerComponent.AddChild<MrPlayer, string>(account);
                playerComponent.Add(player);
                var playerSessionComponent = player.AddComponent<MrPlayerSession>();
                playerSessionComponent.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.GateSession);
                await playerSessionComponent.AddLocation(LocationType.GateSession);

                player.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
                await player.AddLocation(LocationType.Player);

                session.AddComponent<MrSessionPlayer>().Player = player;
                playerSessionComponent.Session = session;
            }
            else
            {
                // if(在房间中)
                // {
                //      DOTO: 断线重连处理
                // }

                // 更新session
                var playerSessionComponent = player.GetComponent<MrPlayerSession>();
                playerSessionComponent.Session = session;
            }

            response.PlayerId = player.Id;
            await ETTask.CompletedTask;
        }
    }
}