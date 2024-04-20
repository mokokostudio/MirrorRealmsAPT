namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Event_InitUseItemPanelInfo : AEvent<Scene, InitUseItemPanelInfo>
    {
        protected override async ETTask Run(Scene root, InitUseItemPanelInfo args)
        {
            UIComponent uiComp = root.GetComponent<UIComponent>();
            UI ui = uiComp.Get(MrUIType.UIStorage);
            MrUIStorageComponent uiStorage = ui.GetComponent<MrUIStorageComponent>();
            uiStorage.InitClickItemInfo();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class Event_UseItem : AEvent<Scene, UseItem>
    {
        protected override async ETTask Run(Scene scene, UseItem a)
        {
            UIComponent uiComp = scene.GetComponent<UIComponent>();
            UI ui = uiComp.Get(MrUIType.UIStorage);
            MrUIStorageComponent uiStorage = ui.GetComponent<MrUIStorageComponent>();
            uiStorage.UseItem(a.itemId, a.useNumber);
            await ETTask.CompletedTask;
        }
    }
}

// EOF