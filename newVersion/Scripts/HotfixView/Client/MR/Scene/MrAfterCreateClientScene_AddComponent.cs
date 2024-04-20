namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class MrAfterCreateClientScene_AddComponent: AEvent<Scene, MrAfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, MrAfterCreateClientScene args)
        {
            scene.AddComponent<UIComponent>();
            scene.AddComponent<ResourcesLoaderComponent>();
            await ETTask.CompletedTask;
        }
    }
}