using TMPro;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent_InventoryPanel_Item))]
    [FriendOfAttribute(typeof (ET.Client.UIBattleComponent_InventoryPanel_Item))]
    public static partial class UIBattleComponent_InventoryPanel_ItemSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UIBattleComponent_InventoryPanel_Item self, UnityEngine.GameObject go, int configId, int count)
        {
            self.GameObject = go;
            self.GameObject.SetActive(true);

            var rc = go.GetComponent<ReferenceCollector>();
            self.Img_Icon = rc.Get<UnityEngine.GameObject>("Img_Icon").GetComponent<UnityEngine.UI.Image>();
            self.Img_QualityBorder = rc.Get<UnityEngine.GameObject>("Img_QualityBorder").GetComponent<UnityEngine.UI.Image>();
            self.Txt_Name = rc.Get<UnityEngine.GameObject>("Txt_Name").GetComponent<TextMeshProUGUI>();
            self.Txt_Count = rc.Get<UnityEngine.GameObject>("Txt_Count").GetComponent<TextMeshProUGUI>();
            self.Go_Star = rc.Get<UnityEngine.GameObject>("Go_Star");

            self.ConfigId = configId;
            var itemConfig = self.Config;

            var iconRc = self.Root().GetComponent<UI_IconResourceComponent>();
            self.Img_Icon.sprite = iconRc.Get(itemConfig.Icon) ?? iconRc.Get("Default");
            self.Img_QualityBorder.color = QualityColor.GetColor((MrItemQuality)itemConfig.Quality);

            self.Txt_Name.text = itemConfig.ShowName;
            self.Go_Star.SetActive((MrInventoryType)itemConfig.ItemType == MrInventoryType.Weapon);
            self.OnCountChanged(count);
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.UIBattleComponent_InventoryPanel_Item self)
        {
            UnityEngine.Object.Destroy(self.GameObject);

            self.GameObject = null;
            self.Img_Icon = null;
            self.Txt_Name = null;
            self.Txt_Count = null;
            self.Go_Star = null;
            self.Count = 0;
        }

        public static void OnCountChanged(this UIBattleComponent_InventoryPanel_Item self, int count)
        {
            self.Count = count;
            self.Txt_Count.text = $"x {self.Count}";

            if (self.Count == 0)
            {
                self.Dispose();
            }
        }
    }
}