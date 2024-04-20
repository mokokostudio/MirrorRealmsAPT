using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MrUIEquipComponent : Entity, IAwake
    {
        public GameObject weaponList;
        public GameObject exit;
        public GameObject player;
        public GameObject playerCamera;

        public int[] WeaponEquipedIdAry;
        public Dictionary<string, GameObject> weaponDic = new Dictionary<string, GameObject>();

        public bool IsBtnClicked;
    }
}