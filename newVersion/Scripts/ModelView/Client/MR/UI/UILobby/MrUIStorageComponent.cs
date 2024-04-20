using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MrUIStorageComponent: Entity, IAwake, IDestroy
    {
        public GameObject ExitBtn;

        public GameObject WeaponsBtn;
        public GameObject ItemsBtn;
        public GameObject WeaponsPanel;
        public GameObject ItemsPanel;
        public GameObject WeaponInfoRoot;
        public GameObject WeaponEmptyPanel;
        public GameObject ItemInfoRoot;
        public GameObject ItemEmptyPanel;

        public Transform WeaponPanelContentTrans;
        public Transform ItemPanelContentTrans;

        public MrWindowStorageItemInfoDesc ItemDesc;
        public MrWindowStorageWeaponInfoDesc WeaponDesc;
        public int SelectItemId;
        public Dictionary<int, long> ItemCompIdsDic = new();
        public Dictionary<int, long> WeaponCompIdsDic = new();
    }
}