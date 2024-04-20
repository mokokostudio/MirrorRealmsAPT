namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_InventoryCountChanged__Handler: MessageHandler<Scene, MrM2C_InventoryCountChanged>
    {
        protected override async ETTask Run(Scene scene, MrM2C_InventoryCountChanged message)
        {
            Log.Console($"Zone: {scene.Zone()} -> rune count changed");
            // 只有自己的item才会变化
            var unit = MrUnitHelper.GetMyUnitFromClientScene(scene);
            var inventory = unit.GetComponent<ClientInventoryComponent>();
            foreach (MrInventoryCountChangeInfo changeInfo in message.ChangeList)
            {
                inventory.OnCountChanged(changeInfo.ItemConfigId, changeInfo.OldCount, changeInfo.NewCount);
            }

            await ETTask.CompletedTask;
        }
    }
}