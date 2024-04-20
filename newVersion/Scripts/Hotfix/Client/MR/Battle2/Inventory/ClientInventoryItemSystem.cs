namespace ET.Client
{
    [EntitySystemOf(typeof (ClientInventoryItem))]
    [FriendOf(typeof (ClientInventoryItem))]
    public static partial class ClientInventoryItemSystem
    {
        [EntitySystem]
        private static void Awake(this ClientInventoryItem self, int itemConfigId, int count)
        {
            self.ConfigId = itemConfigId;
            self.Count = count;
        }

        [EntitySystem]
        private static void Destroy(this ClientInventoryItem self)
        {
            self.ConfigId = default;
            self.Count = default;
        }
    }
}