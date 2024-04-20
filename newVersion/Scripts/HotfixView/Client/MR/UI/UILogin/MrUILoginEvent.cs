using UnityEngine;

namespace ET.Client
{
    [UIEvent(MrUIType.UILogin)]
    public class MrUILoginEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            string assetsName = $"Assets/Bundles/UI/Window/{MrUIType.UILogin}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(MrUIType.UILogin, gameObject);
            ui.AddComponent<MrUILoginComponent>();
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            Debug.LogWarning("=== UILoginEvent: OnRemove ===");
        }
    }
}