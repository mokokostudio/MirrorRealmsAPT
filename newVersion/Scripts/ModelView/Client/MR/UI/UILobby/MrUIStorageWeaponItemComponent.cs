using ET;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf(typeof(MrUIStorageComponent))]
    public class MrUIStorageWeaponItemComponent: Entity, IAwake<string, GameObject>
    {
        public string CompName;
        public GameObject CompObject;

        public Button WeaponBtn;
        public Image WeaponIcon;
        public TMP_Text WeaponName;
        // $"Lv.{xxx}"
        public TMP_Text WeaponLv;
        public Image[] WeaponStars;

        public int WeaponLvNumber;
        public int WeaponStarsNumber;

        public int WeaponId;
        public MrWindowStorageWeaponInfoDesc WeaponDesc;
        public bool IsSelect;

    }
}