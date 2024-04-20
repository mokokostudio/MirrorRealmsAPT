using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIBattleComponent : Entity, IAwake, IUpdate, ILateUpdate
    {
        public GameObject waitDraw;
        public GameObject moveFG;
        public GameObject btnAttack;
        public GameObject btnDodge;
        public GameObject btnDefence;
        public GameObject btnDiscard;
        public GameObject btnWeapon1;
        public GameObject btnWeapon2;
        public GameObject btnWeapon3;
        public Text countDownText;
        public int countDown;
        public long countDownTimerId;
        public bool isMatchFinish;

        public Slider MyHpBar_Slider;
        
        public Button Btn_Inventory;
    }
}

// EOF