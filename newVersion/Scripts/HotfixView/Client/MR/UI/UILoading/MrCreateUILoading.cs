namespace ET.Client
{
    [Event(SceneType.Main)]
    public class AppStart_CreateUILoading: AEvent<Scene, UILoadingCreate>
    {
        protected override async ETTask Run(Scene root, UILoadingCreate args)
        {
            await MrUIHelper.Create(root, MrUIType.UILoadingEnterMain, UILayer.High);
        }
    }

    [Event(SceneType.LockStep)]
    public class LSLoginFinish_CreateUILoading : AEvent<Scene, UILoadingCreate>
    {
        protected override async ETTask Run(Scene root, UILoadingCreate args)
        {
            await MrUIHelper.Create(root, MrUIType.UILoadingEnterMain, UILayer.High);
        }
    }

    [Event(SceneType.Demo)]
    public class LoginFinish_CreateUILoading : AEvent<Scene, UILoadingCreate>
    {
        protected override async ETTask Run(Scene root, UILoadingCreate args)
        {
            await MrUIHelper.Create(root, MrUIType.UILoadingEnterMain, UILayer.High);
        }
    }
}