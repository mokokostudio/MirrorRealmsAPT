namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class MrM2C_StartSceneChange__Handler: MessageHandler<Scene, M2C_StartSceneChange>
    {
        protected override async ETTask Run(Scene root, M2C_StartSceneChange message)
        {
            Log.Info($"MrM2C_StartSceneChange__Handler.Run: {message.SceneName} {message.SceneInstanceId}");
            await MrSceneChangeHelper.SceneChangeTo(root, message.SceneName, message.SceneInstanceId);
        }
    }
}