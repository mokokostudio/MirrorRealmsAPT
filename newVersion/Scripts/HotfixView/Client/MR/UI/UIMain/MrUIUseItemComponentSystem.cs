using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUIUseItemComponent))]
    [FriendOf(typeof(MrUIUseItemComponent))]
    [FriendOf(typeof(MrPlayerInfoComponent))]
    [FriendOf(typeof(MrUIStorageComponent))]
    public static partial class MrUIUseItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrUIUseItemComponent self)
        {
            GameObject uiObj = self.GetParent<UI>().GameObject;
            ReferenceCollector rc = uiObj.GetComponent<ReferenceCollector>();

            self.ItemName = rc.Get<GameObject>("ItemName").GetComponent<TMP_Text>();
            self.ItemIcon = rc.Get<GameObject>("ItemIcon").GetComponent<Image>();
            self.InputField = rc.Get<GameObject>("InputField").GetComponent<TMP_InputField>();

            self.ConfirmBtn = rc.Get<GameObject>("ConfirmBtn").GetComponent<Button>();
            self.ConfirmBtn.onClick.AddListener(() => {
                self.OnConfirmBtnClicked().Coroutine();
            });

            self.BgMaskBtn = rc.Get<GameObject>("BGMask").GetComponent<Button>();
            self.BgMaskBtn.onClick.AddListener(() => {
                self.OnBgMaskClicked().Coroutine();
            });

            self.IsClicked = false;
        }

        [EntitySystem]
        private static void Destroy(this MrUIUseItemComponent self)
        {
        }

        public static void SetUseItemInfo(this MrUIUseItemComponent self, int itemId)
        {
            self.ItemId = itemId;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            self.ItemName.text = itemConfig.ShowName;
            UI_IconResourceComponent uiIconComp = self.Scene().GetComponent<UI_IconResourceComponent>();
            self.ItemIcon.sprite = uiIconComp.Get(itemConfig.Icon);
        }

        public static async ETTask OnConfirmBtnClicked(this MrUIUseItemComponent self)
        {
            if (self.IsClicked) await ETTask.CompletedTask;

            self.IsClicked = true;
            int number = int.Parse(self.InputField.text);
            // 和server通信，并等待
            // await 

            Scene scene = self.Scene();
            MrPlayerInfoComponent mrPlayerInfoComponent = scene.GetComponent<MrPlayerInfoComponent>();

            int index = mrPlayerInfoComponent.ItemsIdAry.IndexOf(self.ItemId);
            mrPlayerInfoComponent.ItemsNumberAry[index] -= number;
            if (mrPlayerInfoComponent.ItemsNumberAry[index] == 0)
            {
                mrPlayerInfoComponent.ItemsIdAry.RemoveAt(index);
                mrPlayerInfoComponent.ItemsNumberAry.RemoveAt(index);
            }

            EventSystem.Instance.Publish(scene, new UseItem() { itemId = self.ItemId, useNumber = number });

            await MrUIHelper.Remove(scene, MrUIType.UIUseItem);
        }

        public static async ETTask OnBgMaskClicked(this MrUIUseItemComponent self)
        {
            await MrUIHelper.Remove(self.Root(), MrUIType.UIUseItem);
        }
    }
}

// EOF