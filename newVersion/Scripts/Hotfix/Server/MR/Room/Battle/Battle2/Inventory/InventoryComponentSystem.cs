using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof (InventoryComponent))]
    [FriendOf(typeof (InventoryComponent))]
    [FriendOf(typeof (InventoryItem))]
    public static partial class InventoryComponentSystem
    {
        [EntitySystem]
        private static void Awake(this InventoryComponent self)
        {
            self.AddItem(1, 1, false);
            self.AddItem(2, 1, false);
            // self.AddItem(3, 1, false);// bow 没有实现

            if (Define.IsEditor)
            {
                self.AddItem(4, 100, false);
                self.AddItem(5, 100, false);
                self.AddItem(6, 100, false);
            }
            else
            {
                self.AddItem(4, 1, false);
                self.AddItem(5, 1, false);
                self.AddItem(6, 0, false);
            }
        }

        [EntitySystem]
        private static void Deserialize(this InventoryComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this InventoryComponent self)
        {
        }

        public static void AddItem(this InventoryComponent self, int itemConfigId, int count, bool eventPublish = true)
        {
            if (count <= 0)
            {
                return;
            }

            if (!ItemConfigCategory.Instance.Contain(itemConfigId))
            {
                Log.Error($"AddItem failed,错误的itemId: {itemConfigId}");
                return;
            }

            var oldCount = 0;
            var newCount = 0;
            var item = self.GetItem(itemConfigId);
            if (item != null)
            {
                oldCount = item.Count;
                item.Count += count;
                newCount = item.Count;
            }
            else
            {
                var x = self.AddChild<InventoryItem, int, int>(itemConfigId, count);

                oldCount = 0;
                newCount = count;
            }

            if (eventPublish)
            {
                self.SendCountChange(MrInventoryType.Item, itemConfigId, oldCount, newCount);
            }
        }

        public static int RemoveItem(this InventoryComponent self, int itemId, int count, bool eventPublish = true)
        {
            if (count <= 0)
            {
                return ErrorCode.ERR_RemoveItem_CountError;
            }

            var item = self.GetItem(itemId);
            if (item == null || item.Count < count)
            {
                return ErrorCode.ERR_RemoveItem_NotEnough;
            }

            var oldCount = item.Count;
            item.Count -= count;
            var newCount = item.Count;

            if (item.Count <= 0)
            {
                item.Dispose();
            }

            if (eventPublish)
            {
                self.SendCountChange(MrInventoryType.Item, itemId, oldCount, newCount);
            }

            return ErrorCode.ERR_Success;
        }

        public static int GetItemCount(this InventoryComponent self, int itemId)
        {
            var item = self.GetItem(itemId);
            return item?.Count ?? 0;
        }

        public static IEnumerable<InventoryItem> ListChildren(this InventoryComponent self, MrInventoryType type)
        {
            return self.Children.Select(child => child.Value as InventoryItem).Where(e => e.ItemType == type);
        }

        public static InventoryItem GetItem(this InventoryComponent self, int itemId)
        {
            return self.Children.Values.FirstOrDefault(e => (e as InventoryItem).ConfigId == itemId) as InventoryItem;
        }

        private static void SendCountChange(this InventoryComponent self, MrInventoryType mrInventoryType, int configId, int oldCount, int newCount)
        {
            var msg = new MrM2C_InventoryCountChanged() { ChangeList = new() };
            msg.ChangeList.Add(new MrInventoryCountChangeInfo() { ItemConfigId = configId, OldCount = oldCount, NewCount = newCount });
            MrMapMessageHelper.SendToClient(self.GetParent<Unit>(), msg);
        }
    }
}