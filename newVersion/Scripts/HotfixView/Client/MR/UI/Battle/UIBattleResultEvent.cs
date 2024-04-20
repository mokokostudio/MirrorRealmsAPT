using UnityEngine;
using ET;

namespace ET.Client
{
    [UIEvent(MrUIType.UIBattleResult)]
    public class UIBattleResultEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            string assetsName = $"Assets/Bundles/UI/Window/{MrUIType.UIBattleResult}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(MrUIType.UIBattle, gameObject);
            ui.AddComponent<MrUIBattleResultComponent>();
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            Debug.LogWarning("=== UIBattleResultEvent: OnRemove ===");
        }
    }
}

// EOF