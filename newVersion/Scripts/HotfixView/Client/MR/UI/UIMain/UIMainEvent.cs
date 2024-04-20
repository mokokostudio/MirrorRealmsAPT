using System;
using UnityEngine;
using ET;

namespace ET.Client
{
    [UIEvent(MrUIType.UIMain)]
    public class UIMainEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            string assetsName = $"Assets/Bundles/UI/Window/{MrUIType.UIMain}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(MrUIType.UIMain, gameObject);
            ui.AddComponent<MrUIMainComponent>();

            await EventSystem.Instance.PublishAsync(uiComponent.Scene(), new UILoadingRemove());
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            Debug.LogWarning("=== UIMainEvent: OnRemove ===");
        }
    }
}