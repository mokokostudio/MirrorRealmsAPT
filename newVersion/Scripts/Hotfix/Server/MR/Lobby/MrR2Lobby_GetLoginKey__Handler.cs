namespace ET.Server
{
    [MessageHandler(SceneType.MrLobby)]
    public class MrR2Lobby_GetLoginKey__Handler: MessageHandler<Scene, MrR2Lobby_GetLoginKey, MrLobby2R_GetLoginKey>
    {
        protected override async ETTask Run(Scene scene, MrR2Lobby_GetLoginKey request, MrLobby2R_GetLoginKey response)
        {
            long key = RandomGenerator.RandInt64();
            scene.GetComponent<MrLobbySessionKeyMgr>().Add(key, request.Account);
            response.Key = key;
            response.GateId = scene.Id;
            await ETTask.CompletedTask;
        }
    }
}