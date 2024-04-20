namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class LoginFinish_CreateUIMain : AEvent<Scene, MrLoginFinish>
    {
        protected override async ETTask Run(Scene scene, MrLoginFinish args)
        {
            await MrUIHelper.Create(scene, MrUIType.UIMain, UILayer.Mid);
        }
    }
}
