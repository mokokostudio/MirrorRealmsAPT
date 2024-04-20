namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class MrLoginFinish_RemoveLoginUI : AEvent<Scene, MrLoginFinish>
    {
        protected override async ETTask Run(Scene scene, MrLoginFinish args)
        {
            await EventSystem.Instance.PublishAsync(scene, new UILoadingCreate());
            await MrUIHelper.Remove(scene, MrUIType.UILogin);
        }
    }
}
