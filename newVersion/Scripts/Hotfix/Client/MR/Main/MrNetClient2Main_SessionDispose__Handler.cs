namespace ET.Client
{
    [MessageHandler(SceneType.All)]
    public class MrNetClient2Main_SessionDispose__Handler: MessageHandler<Scene, MrNetClient2Main_SessionDispose>
    {
        protected override async ETTask Run(Scene entity, MrNetClient2Main_SessionDispose message)
        {
            Log.Error($"session dispose, error: {message.Error}");
            await ETTask.CompletedTask;
        }
    }
}