namespace ET.Client
{
    [Event(SceneType.Main)]
    public class AppStartInitFinish_RemoveUILoading : AEvent<Scene, UILoadingRemove>
    {
        protected override async ETTask Run(Scene root, UILoadingRemove args)
        {
            await MrUIHelper.Remove(root, MrUIType.UILoadingEnterMain);
        }
    }

    [Event(SceneType.Demo)]
    public class EnterMain_RemoveUILoading : AEvent<Scene, UILoadingRemove>
    {
        protected override async ETTask Run(Scene root, UILoadingRemove args)
        {
            await MrUIHelper.Remove(root, MrUIType.UILoadingEnterMain);
        }
    }
}