namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class MrAfterCreateClientScene_LSAddComponent : AEvent<Scene, MrAfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, MrAfterCreateClientScene args)
        {
            scene.AddComponent<UIComponent>();
            scene.AddComponent<ResourcesLoaderComponent>();
            await ETTask.CompletedTask;
        }
    }
}