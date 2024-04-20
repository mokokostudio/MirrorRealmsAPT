using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUIStorageWeaponItemComponent))]
    [FriendOf(typeof(MrUIStorageWeaponItemComponent))]
    [FriendOf(typeof(MrUIStorageComponent))]
    public static partial class MrUIStorageWeaponItemComponentSystem
    {
        [EntitySystem]
        private static async ETTask Awake(this MrUIStorageWeaponItemComponent self, string args2, GameObject args3)
        {
            self.CompName = args2;
            self.CompObject = args3;

            string[] strs = args2.Split('_');
            self.WeaponId = int.Parse(strs[1]);
            WeaponInfoConfig weaponInfoConfig = WeaponInfoConfigCategory.Instance.Get(self.WeaponId);

            //GameObject uiObj = self.GetParent<UI>().GameObject;
            ReferenceCollector rc = self.CompObject.GetComponent<ReferenceCollector>();

            self.WeaponBtn = rc.Get<GameObject>("WeaponItemBtn").GetComponent<Button>();
            self.WeaponName = rc.Get<GameObject>("WeaponNameText").GetComponent<TMP_Text>();
            self.WeaponLv = rc.Get<GameObject>("WeaponLvText").GetComponent<TMP_Text>();
            self.WeaponIcon = rc.Get<GameObject>("WeaponIcon").GetComponent<Image>();
            self.WeaponStars = rc.Get<GameObject>("WeaponStars").GetComponentsInChildren<Image>();

            self.WeaponName.text = weaponInfoConfig.Name;

            string weaponIconPath = $"Assets/ABAssets/Icon/{weaponInfoConfig.Icon}.png";
            Sprite sp = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<Sprite>(weaponIconPath);
            self.WeaponIcon.sprite = GameObject.Instantiate<Sprite>(sp);
            // TODO: 
            self.WeaponLvNumber = RandomGenerator.RandomNumber(1, 100);
            self.WeaponLv.text = $"Lv.{self.WeaponLvNumber}";
            self.WeaponStarsNumber = RandomGenerator.RandomNumber(0, 6);
            for (int i = 0; i < 6; i++)
            {
                self.WeaponStars[i].gameObject.SetActive(i <= self.WeaponStarsNumber);
            }

            self.WeaponBtn.onClick.AddListener(() => {
                self.SetItemDescInfo();
            });

            await ETTask.CompletedTask;
        }

        public static void SetWeaponDescItem(this MrUIStorageWeaponItemComponent self, MrWindowStorageWeaponInfoDesc descItem)
        {
            self.WeaponDesc = descItem;
        }

        public static void SetItemDescInfo(this MrUIStorageWeaponItemComponent self)
        {
            WeaponInfoConfig weaponInfoConfig = WeaponInfoConfigCategory.Instance.Get(self.WeaponId);
            string weaponInfo = $"{weaponInfoConfig.Name}\n{self.WeaponLvNumber}\n{100}\n{100}";
            self.WeaponDesc.SetWeaponInfoPanel(self.WeaponName.text, self.WeaponIcon.sprite, weaponInfo, weaponInfoConfig.Desc, self.WeaponStarsNumber);
        }
    }
}

// EOF