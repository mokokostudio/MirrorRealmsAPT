using System.Collections.Generic;
using System.Linq;
using ET.EventType;

namespace ET.Client
{
    [EntitySystemOf(typeof (ClientInventoryComponent))]
    [FriendOf(typeof (ClientInventoryComponent))]
    [FriendOf(typeof (ClientInventoryItem))]
    public static partial class ClientInventoryComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientInventoryComponent self, List<InventoryItemProto> items)
        {
            foreach (InventoryItemProto item in items)
            {
                self.OnCountChanged(item.ConfigId, 0, item.Count, false);
            }

            EventSystem.Instance.Publish(self.Root().CurrentScene(), new InventoryInited());
        }

        [EntitySystem]
        private static void Destroy(this ClientInventoryComponent self)
        {
        }

        private static IEnumerable<ClientInventoryItem> ListInventory(this ClientInventoryComponent self, MrInventoryType mrInventoryType)
        {
            return self.Children.Select(x => x.Value as ClientInventoryItem).Where(x => x.ItemType == mrInventoryType);
        }

        public static void OnCountChanged(this ClientInventoryComponent self, int itemConfigId, int oldOunt, int newCount,
        bool eventPublish = true)
        {
            var inventoryList = self.ListInventory(MrInventoryType.Item);

            var inventory = inventoryList.FirstOrDefault(x => x.ConfigId == itemConfigId);
            if (inventory != null)
            {
                inventory.Count = newCount;
                if (inventory.Count == 0)
                {
                    inventory.Dispose();
                }
            }
            else
            {
                inventory = self.AddChild<ClientInventoryItem, int, int>(itemConfigId, newCount);
            }

            if (eventPublish)
            {
                EventSystem.Instance.Publish(self.Root().CurrentScene(),
                    new IventoryCountChanged() { ItemConfigId = itemConfigId, OldCount = oldOunt, NewCount = newCount });
            }
        }
    }
}