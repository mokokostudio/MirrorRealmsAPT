namespace ET.Server
{
    [MessageSessionHandler(SceneType.MrLobby)]
    public class MrC2Lobby_Match__Handler: MessageSessionHandler<MrC2Lobby_Match, MrLobby2C_Match>
    {
        protected override async ETTask Run(Session session, MrC2Lobby_Match request, MrLobby2C_Match response)
        {
            var player = session.GetComponent<MrSessionPlayer>().Player;
            var scene = player.Scene();

            var matchComponent = scene.GetComponent<MrMatch>();
            matchComponent.Match(player.Id, request.SinglePlay);
            await ETTask.CompletedTask;
        }
    }
}