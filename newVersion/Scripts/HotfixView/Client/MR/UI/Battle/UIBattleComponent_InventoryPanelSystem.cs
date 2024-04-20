using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent_InventoryPanel))]
    [FriendOfAttribute(typeof (UIBattleComponent_InventoryPanel))]
    [FriendOfAttribute(typeof (UIBattleComponent_InventoryPanel_Item))]
    [FriendOfAttribute(typeof (ClientInventoryItem))]
    public static partial class UIBattleComponent_InventoryPanelSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent_InventoryPanel self, GameObject go)
        {
            self.GameObject = go;

            var rc = go.GetComponent<ReferenceCollector>();
            self.Btn_Close = rc.Get<GameObject>("Btn_Close").GetComponent<Button>();
            self.Item_Template = rc.Get<GameObject>("Item_Template");
            self.Item_Template.SetActive(false);

            self.Init();

            self.Btn_Close.onClick.AddListener(() => { self.Hide(); });

            self.Hide();
        }

        public static void Show(this UIBattleComponent_InventoryPanel self)
        {
            self.IsShow = true;
            self.GameObject.SetActive(self.IsShow);
        }

        public static void Hide(this UIBattleComponent_InventoryPanel self)
        {
            self.IsShow = false;
            self.GameObject.SetActive(self.IsShow);
        }

        public static void Toggle(this UIBattleComponent_InventoryPanel self)
        {
            self.IsShow = !self.IsShow;
            self.GameObject.SetActive(self.IsShow);
        }

        public static void Init(this UIBattleComponent_InventoryPanel self)
        {
            var unit = MrUnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null)
            {
                return;
            }

            var inventoryComponent = unit.GetComponent<ClientInventoryComponent>();
            if (inventoryComponent == null)
            {
                return;
            }

            var items = inventoryComponent.Children.Select(x => x.Value as ClientInventoryItem);
            foreach (var x in items)
            {
                self.OnCountChanged(x.ConfigId, 0, x.Count);
            }
        }

        public static void OnCountChanged(this UIBattleComponent_InventoryPanel self, int itemConfigId, int oldCount, int newCount)
        {
            var inventoryItem = self.Children.Select(x => x.Value as UIBattleComponent_InventoryPanel_Item)
                    .FirstOrDefault(x => x.ConfigId == itemConfigId);
            if (inventoryItem == null)
            {
                var go = UnityEngine.Object.Instantiate(self.Item_Template, self.Item_Template.transform.parent, false);
                self.AddChild<UIBattleComponent_InventoryPanel_Item, GameObject, int, int>(go, itemConfigId, newCount);
            }
            else
            {
                inventoryItem.OnCountChanged(newCount);
            }
        }
    }
}