using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUIEquipComponent))]
    [FriendOf(typeof(MrUIEquipComponent))]
    public static partial class UIEquipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrUIEquipComponent self)
        {
            GameObject uiObj = self.GetParent<UI>().GameObject;
            ReferenceCollector rc = uiObj.GetComponent<ReferenceCollector>();

            self.weaponList = rc.Get<GameObject>("WeaponList");
            self.exit = rc.Get<GameObject>("ExitBtn");
            self.exit.GetComponent<Button>().onClick.AddListener(() => {
                self.OnExitBtnClicked().Coroutine();
            });

            // EOS
            self.player = rc.Get<GameObject>("Player");
            self.playerCamera = rc.Get<GameObject>("PlayerCamera");

            // TODO: 暂时没有数据，先用假的
            var Equiped = new int[3] { 1000000001, 1000001001, 1000002001 };
            //PlayerData.Equiped = new int[0];
            // 1000000001，1000000301，1000001001，1000001002，1000001301，1000002001，1000002002，1000002301，1000003001，1000003002，1000003301

            UIWindowMainBehaviour uiWindowMain = uiObj.GetComponent<UIWindowMainBehaviour>();
            WindowMainWeaponItem[] weaponItems = self.weaponList.GetComponentsInChildren<WindowMainWeaponItem>(true);
            int itemsNum = weaponItems.Length;
            int weaponId = 0;
            int i = 0;
            for (; i < Equiped.Length; i++)
            {
                WindowMainWeaponItem item = weaponItems[i];
                weaponId = Equiped[i];
                InitWeaponInfos(self, item, weaponId, i).Coroutine();
                item.SetParentView(uiWindowMain);
            }

            for (; i < itemsNum; i++)
            {
                weaponItems[i].SetWeaponState(false);
            }
        }

        private static async ETTask OnExitBtnClicked(this MrUIEquipComponent self)
        {
            Scene scene = self.Root();
            UIComponent uiComp = scene.GetComponent<UIComponent>();
            if (uiComp == null)
            {
                Debug.LogWarning($"=== UIEquipComponentSystem exit btn: uicomponet is null. ===");
            }
            else
            {
                UI ui = uiComp.Get(MrUIType.UIMain);
                MrUIMainComponent mrUIMain = ui.GetComponent<MrUIMainComponent>();
                mrUIMain.SetComponentViewState(true);
            }
            await MrUIHelper.Remove(scene, MrUIType.UIEquip);
            //await ETTask.CompletedTask;
        }

        public static void ResetInfos(this MrUIEquipComponent self)
        {
            self.IsBtnClicked = false;
        }

        private static async ETTask InitWeaponInfos(this MrUIEquipComponent self, WindowMainWeaponItem weaponItem, int weaponId, int idx)
        {
            WeaponInfoConfig weaponCfg = WeaponInfoConfigCategory.Instance.Get(weaponId);
            string weaponIconPath = $"Assets/ABAssets/Icon/{weaponCfg.Icon}.png";
            Sprite sp = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<Sprite>(weaponIconPath);
            Sprite icon = GameObject.Instantiate<Sprite>(sp);
            WeaponTypeConfig weaponTypeCfg = WeaponTypeConfigCategory.Instance.Get(weaponCfg.WeaponType);

            //$"Weapon/{weapon.Prefabs[i]}.prefab"
            if (!string.IsNullOrEmpty(weaponCfg.Weapon1))
            {
                string path = $"Assets/ABAssets/Weapon/{weaponCfg.Weapon1}.prefab";
                GameObject weapon = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
                weaponItem.SetWeapon(path, weapon, weaponTypeCfg.EquipPos1);
                self.weaponDic.Add(path, weapon);
            }
            if (!string.IsNullOrEmpty(weaponCfg.Weapon2))
            {
                string path = $"Assets/ABAssets/Weapon/{weaponCfg.Weapon2}.prefab";
                GameObject weapon = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
                weaponItem.SetWeapon(path, weapon, weaponTypeCfg.EquipPos2);
                self.weaponDic.Add(path, weapon);
            }

            weaponItem.InitWeaponItem(idx, weaponCfg.Name, icon, weaponCfg.Quality > (int)WeaponQualityType.N);
        }
    }
}