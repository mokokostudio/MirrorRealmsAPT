namespace ET.Server
{
    [MessageSessionHandler(SceneType.Realm)]
    public class MrC2R_Login__Handler: MessageSessionHandler<MrC2R_Login, MrR2C_Login>
    {
        protected override async ETTask Run(Session session, MrC2R_Login request, MrR2C_Login response)
        {
            // 我们没有Gate(否则还要一层转发做起来很麻烦, demo先简单点), 所以直接连接Lobby.
            // 我设想的是将来还是有Gate(1~N个), 然后Gate再转发到Lobby, 这样就可以做负载均衡了.
            // 我们只有1个大厅(除非以后做分区服等, 每个区服1个大厅), 目前是为了适配框架的流程, 所以才有这个Realm.
            StartSceneConfig config = StartSceneConfigCategory.Instance.MrLobby;
            Log.Debug($"lobby address: {config}");
            
            MrLobby2R_GetLoginKey mrLobby2RGetLoginKey = (MrLobby2R_GetLoginKey)await session.Fiber().Root.GetComponent<MessageSender>()
                    .Call(config.ActorId, new MrR2Lobby_GetLoginKey() { Account = request.Account });

            response.Address = config.InnerIPPort.ToString();
            response.Key = mrLobby2RGetLoginKey.Key;

            CloseSession(session).Coroutine();
        }

        private async ETTask CloseSession(Session session)
        {
            await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            session.Dispose();
        }
    }
}