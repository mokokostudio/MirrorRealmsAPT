using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    [FriendOf(typeof (ClientInventoryItem))]
    public class InventoryInited__EventHandler: AEvent<Scene, InventoryInited>
    {
        protected override async ETTask Run(Scene scene, InventoryInited a)
        {
            Log.Info($"Init inventory inited event handler.");

            var ui = scene.GetComponent<UIComponent>();
            var ui_b = ui.Get(MrUIType.UIBattle);
            // 有可能还没创建UIBattle
            if (ui_b != null)
            {
                var bc = ui_b.GetComponent<UIBattleComponent>();
                var ir = bc.GetComponent<UIBattleComponent_InventoryPanel>();
                ir.Init();

                var rp = bc.GetComponent<UIBattleComponent_RunePanel>();
                rp.Init();
            }

            await ETTask.CompletedTask;
        }
    }
}