namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class MrLobby2C_NotifyMatchSuccess__Handler: MessageHandler<Scene, MrLobby2C_NotifyMatchSuccess>
    {
        protected override async ETTask Run(Scene entity, MrLobby2C_NotifyMatchSuccess message)
        {
            Log.Warning($"匹配成功");
          
            await ETTask.CompletedTask;
        }
    }
}