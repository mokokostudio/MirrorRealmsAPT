using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUIStorageItemComponent))]
    [FriendOf(typeof(MrUIStorageItemComponent))]
    [FriendOf(typeof(MrUIStorageComponent))]
    public static partial class MrUIStorageItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrUIStorageItemComponent self, string args2, GameObject args3)
        {
            self.CompName = args2;
            self.CompObject = args3;
            self.IsSelect = false;

            string[] strs = args2.Split('_');
            self.ItemId = int.Parse(strs[1]);
            self.ItemCount = int.Parse(strs[2]);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.ItemId);

            //GameObject uiObj = self.GetParent<UI>().GameObject;
            ReferenceCollector rc = self.CompObject.GetComponent<ReferenceCollector>();

            self.ItemBtn = rc.Get<GameObject>("ItemBtn").GetComponent<Button>();
            self.ItemIcon = rc.Get<GameObject>("ItemIcon").GetComponent<Image>();
            self.ItemName = rc.Get<GameObject>("ItemNameText").GetComponent<TMP_Text>();
            self.ItemNumber = rc.Get<GameObject>("ItemNumText").GetComponent<TMP_Text>();

            self.ItemName.text = itemConfig.ShowName;
            self.ItemNumber.text = $"{self.ItemCount}";

            UI_IconResourceComponent uiIconComp = self.Scene().GetComponent<UI_IconResourceComponent>();
            self.ItemIcon.sprite = uiIconComp.Get(itemConfig.Icon);

            self.ItemBtn.onClick.AddListener(() => { self.OnClicked().Coroutine(); });
        }

        [EntitySystem]
        private static void Destroy(this MrUIStorageItemComponent self)
        {
            GameObject.Destroy(self.CompObject);
        }

        public static void SetItemDescItem(this MrUIStorageItemComponent self, MrWindowStorageItemInfoDesc descItem)
        {
            self.DescItem = descItem;
        }

        public static void SetClickItemCallback(this MrUIStorageItemComponent self, Action callback)
        {
        }

        public static void SetItemDescInfo(this MrUIStorageItemComponent self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.ItemId);
            self.DescItem.SetItemInfoPanel(self.ItemName.text, self.ItemIcon.sprite, self.ItemNumber.text, itemConfig.Desc);
            MrUIStorageComponent uiStorage = self.GetParent<MrUIStorageComponent>();
            uiStorage.SetSelectItemId(self.ItemId);

        }

        public static async ETTask OnClicked(this MrUIStorageItemComponent self)
        {
            if (self.IsSelect)
            {
                await MrUIHelper.Create(self.Root(), MrUIType.UIUseItem, UILayer.Mid);
                await EventSystem.Instance.PublishAsync(self.Scene(), new InitUseItemPanelInfo());
            }
            else
            {
                self.IsSelect = true;
                self.SetItemDescInfo();
            }
        }

        public static void UpdateInfo(this MrUIStorageItemComponent self, int useNum)
        {
            self.ItemCount -= useNum;
            self.ItemNumber.text = $"{self.ItemCount}";

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.ItemId);
            self.DescItem.SetItemInfoPanel(self.ItemName.text, self.ItemIcon.sprite, self.ItemNumber.text, itemConfig.Desc);
        }

        public static bool IsItemEmpty(this MrUIStorageItemComponent self)
        {
            return self.ItemCount == 0;
        }

        public static void Unselect(this MrUIStorageItemComponent self)
        {
            self.IsSelect = false;
        }
    }
}

// EOF