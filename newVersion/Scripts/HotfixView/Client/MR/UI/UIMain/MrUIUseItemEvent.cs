
using UnityEngine;

namespace ET.Client
{
    [UIEvent(MrUIType.UIUseItem)]
    public class MrUIUseItemEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            Debug.LogWarning("=== MrUIUseItemEvent: OnCreate ===");

            string assetsName = $"Assets/Bundles/UI/Window/{MrUIType.UIUseItem}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(MrUIType.UIUseItem, gameObject);
            ui.AddComponent<MrUIUseItemComponent>();

            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            Debug.LogWarning("=== MrUIUseItemEvent: OnRemove ===");
        }
    }
}

// EOF