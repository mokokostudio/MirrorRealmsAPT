using UnityEngine;
using ET;

namespace ET.Client
{
    [UIEvent(MrUIType.UIBattle)]
    public class UIBattleEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            string assetsName = $"Assets/Bundles/UI/Window/{MrUIType.UIBattle}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(MrUIType.UIBattle, gameObject);
            ui.AddComponent<UIBattleComponent>();
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            Debug.LogWarning("=== UIBattleEvent: OnRemove ===");
        }
    }
}