namespace ET.Server
{
    [EntitySystemOf(typeof (InventoryItem))]
    [FriendOf(typeof (InventoryItem))]
    public static partial class InventorySystem
    {
        [EntitySystem]
        private static void Awake(this InventoryItem self, int itemConfigId, int count)
        {
            self.ConfigId = itemConfigId;
            self.Count = count;
        }

        [EntitySystem]
        private static void Destroy(this InventoryItem self)
        {
            self.ConfigId = default;
            self.Count = default;
        }
    }
}