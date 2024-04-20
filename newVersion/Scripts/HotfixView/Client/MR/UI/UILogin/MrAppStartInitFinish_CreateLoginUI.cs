using UnityEngine;

namespace ET.Client
{

    [Event(SceneType.Demo)]
    public class MrAppStartInitFinish_CreateLoginUI : AEvent<Scene, MrAppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, MrAppStartInitFinish args)
        {
            Debug.LogWarning("=== MR Demo AppStartInitFinish_CreateLoginUI. ===");
            await MrUIHelper.Create(root, MrUIType.UILogin, UILayer.Mid);
        }
    }
}
