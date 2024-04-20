namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MrAfterCreateCurrentScene_AddComponent: AEvent<Scene, MrAfterCreateCurrentScene>
    {
        protected override async ETTask Run(Scene scene, MrAfterCreateCurrentScene args)
        {
            scene.AddComponent<UIComponent>();
            scene.AddComponent<ResourcesLoaderComponent>();
            await ETTask.CompletedTask;
        }
    }
}