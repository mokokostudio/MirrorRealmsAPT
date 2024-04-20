using System;
using TMPro;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UI))]
    public class MrUIMainComponent: Entity, IAwake, IDestroy
    {
        public GameObject joinRoom;
        public GameObject createRoom;
        public GameObject player;
        public GameObject playerCamera;
        public GameObject bgImage;
        public GameObject equipBtn;
        public GameObject storageBtn;
        public GameObject rankBtn;
        public GameObject modeSelectPanel;

        public int[] WeaponEquipedIdAry;
        public bool IsBtnClicked;

        public GameObject MultiBtnTxtObj;
        public TMP_Text matchCntTxt;
        public int matchCnt;
        public long matchCntTimerId;
        public bool isSingle;
        public MrWindowMainModeSelectItem selectItem;
        public GameObject startBtn;
        public GameObject startBtnTxtObj;
        public TMP_Text startMatchCntTxt;

        // For equip select panel
        public MrWindowMainModeSelectItem singleItem;
        public MrWindowMainModeSelectItem multiItem;
    }
}