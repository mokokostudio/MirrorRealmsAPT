using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUIStorageComponent))]
    [FriendOf(typeof(MrUIStorageComponent))]
    [FriendOf(typeof(MrUIStorageItemComponent))]
    [FriendOf(typeof(MrUIStorageWeaponItemComponent))]
    [FriendOf(typeof(MrPlayerInfoComponent))]
    public static partial class MrUIStorageComponentSystem
    {
        [EntitySystem]
        private static async ETTask Awake(this MrUIStorageComponent self)
        {
            GameObject uiObj = self.GetParent<UI>().GameObject;
            ReferenceCollector rc = uiObj.GetComponent<ReferenceCollector>();

            self.ExitBtn = rc.Get<GameObject>("ExitBtn");
            self.ExitBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                self.OnExitBtnCLicked().Coroutine();
            });

            self.ItemsPanel = rc.Get<GameObject>("ItemsPanel");
            self.WeaponsPanel = rc.Get<GameObject>("WeaponsPanel");
            self.ItemDesc = rc.Get<GameObject>("ItemDesc").GetComponent<MrWindowStorageItemInfoDesc>();
            self.WeaponDesc = rc.Get<GameObject>("WeaponDesc").GetComponent<MrWindowStorageWeaponInfoDesc>();
            
            self.ItemInfoRoot = rc.Get<GameObject>("ItemInfoRoot");
            self.ItemEmptyPanel = rc.Get<GameObject>("ItemEmptyPanel");
            self.WeaponInfoRoot = rc.Get<GameObject>("WeaponInfoRoot");
            self.WeaponEmptyPanel = rc.Get<GameObject>("WeaponEmptyPanel");

            self.WeaponPanelContentTrans = rc.Get<GameObject>("WeaponPanelContent").transform;
            self.ItemPanelContentTrans = rc.Get<GameObject>("ItemPanelContent").transform;

            Scene scene = self.Scene();
            MrPlayerInfoComponent mrPlayerInfoComponent = scene.GetComponent<MrPlayerInfoComponent>();
            ResourcesLoaderComponent rlc = scene.GetComponent<ResourcesLoaderComponent>();
            // Items
            string itemItemAssetName = $"Assets/Bundles/UI/WindowItem/Window_Storage_ItemItem.prefab";
            GameObject itemItemAsset = await rlc.LoadAssetAsync<GameObject>(itemItemAssetName);
            int itemNumbers = mrPlayerInfoComponent.ItemsIdAry.Count;
            self.ItemInfoRoot.SetActive(itemNumbers > 0);
            self.ItemEmptyPanel.SetActive(itemNumbers == 0);
            if (itemNumbers > 0)
            {
                for (int idx = 0; idx < itemNumbers; idx++)
                {
                    int itemId = mrPlayerInfoComponent.ItemsIdAry[idx];
                    int itemNum = mrPlayerInfoComponent.ItemsNumberAry[idx];

                    GameObject itemItemObject = GameObject.Instantiate(itemItemAsset, self.ItemPanelContentTrans, false);
                    MrUIStorageItemComponent itemComp = self.AddChild<MrUIStorageItemComponent, string, GameObject>($"Item_{itemId}_{itemNum}", itemItemObject);
                    itemComp.SetItemDescItem(self.ItemDesc);
                    self.ItemCompIdsDic.Add(itemId, itemComp.Id);
                }
            }

            // Weapons
            string weaponItemAssetName = $"Assets/Bundles/UI/WindowItem/Window_Storage_WeaponItem.prefab";
            GameObject weaponItemAsset = await rlc.LoadAssetAsync<GameObject>(weaponItemAssetName);
            int weaponNumbers = mrPlayerInfoComponent.WeaponsIdAry.Length;
            self.WeaponInfoRoot.SetActive(weaponNumbers > 0);
            self.WeaponEmptyPanel.SetActive(weaponNumbers == 0);
            if (weaponNumbers > 0)
            {
                foreach (int weaponId in mrPlayerInfoComponent.WeaponsIdAry)
                {
                    GameObject weaponItemObject = GameObject.Instantiate(weaponItemAsset, self.WeaponPanelContentTrans, false);
                    MrUIStorageWeaponItemComponent weaponComp = self.AddChild<MrUIStorageWeaponItemComponent, string, GameObject>($"Weapon_{weaponId}", weaponItemObject);
                    weaponComp.SetWeaponDescItem(self.WeaponDesc);
                    self.WeaponCompIdsDic.Add(weaponId, weaponComp.Id);
                }
            }

            await ETTask.CompletedTask;
        }

        [EntitySystem]
        private static void Destroy(this MrUIStorageComponent self)
        {

        }

        private static async ETTask OnExitBtnCLicked(this MrUIStorageComponent self)
        {
            Scene scene = self.Root();
            UIComponent uiComp = scene.GetComponent<UIComponent>();
            if (uiComp == null)
            {
                Debug.LogWarning($"=== UIStorageComponentSystem exit btn: uicomponet is null. ===");
            }
            else
            {
                UI ui = uiComp.Get(MrUIType.UIMain);
                MrUIMainComponent mrUIMain = ui.GetComponent<MrUIMainComponent>();
                mrUIMain.SetComponentViewState(true);
            }
            await MrUIHelper.Remove(scene, MrUIType.UIStorage);
        }

        public static void SetSelectItemId(this MrUIStorageComponent self, int itemId)
        {
            if (self.SelectItemId > 0)
            {
                MrUIStorageItemComponent itemComponent = self.GetChild<MrUIStorageItemComponent>(self.ItemCompIdsDic[self.SelectItemId]);
                itemComponent?.Unselect();
            }
            self.SelectItemId = itemId;
        }

        public static void InitClickItemInfo(this MrUIStorageComponent self)
        {
            Scene scene = self.Root();
            UIComponent uiComp = scene.GetComponent<UIComponent>();
            UI ui = uiComp.Get(MrUIType.UIUseItem);
            MrUIUseItemComponent useItem = ui.GetComponent<MrUIUseItemComponent>();
            useItem.SetUseItemInfo(self.SelectItemId);
        }

        public static void UseItem(this MrUIStorageComponent self, int itemId, int useNum)
        {
            if (self.ItemCompIdsDic.TryGetValue(itemId, out long itemCompId))
            {
                MrUIStorageItemComponent itemComponent = self.GetChild<MrUIStorageItemComponent>(itemCompId);
                if (itemComponent != null)
                {
                    itemComponent.UpdateInfo(useNum);
                    if (itemComponent.IsItemEmpty())
                    {
                        self.RemoveChild(itemCompId);
                    }
                    MrPlayerInfoComponent mrPlayerInfoComponent = self.Scene().GetComponent<MrPlayerInfoComponent>();
                    int itemNumbers = mrPlayerInfoComponent.ItemsIdAry.Count;
                    self.ItemInfoRoot.SetActive(itemNumbers > 0);
                    self.ItemEmptyPanel.SetActive(itemNumbers == 0);
                }
                else
                {
                    Debug.LogWarning($"=== UIStorage:UseItem  itemComponent is null.  ===");
                }
            }
        }
    }
}

// EOF