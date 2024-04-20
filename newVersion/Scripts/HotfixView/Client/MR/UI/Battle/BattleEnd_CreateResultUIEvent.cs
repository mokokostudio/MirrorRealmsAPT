using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class BattleEnd_CreateResultUIEvent : AEvent<Scene, MrBattleEnd>
    {
        protected override async ETTask Run(Scene scene, MrBattleEnd args)
        {
            await MrUIHelper.Create(scene, MrUIType.UIBattleResult, UILayer.Mid);
            // 设置成功失败信息
            Debug.LogWarning(args.IsVictory);
            UI ui = scene.GetComponent<UIComponent>().Get(MrUIType.UIBattleResult);
            MrUIBattleResultComponent resultMrUI = ui.GetComponent<MrUIBattleResultComponent>();
            resultMrUI.SetUIArgs(args);
        }
    }

}

// EOF