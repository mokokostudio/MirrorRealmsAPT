using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf(typeof (UIBattleComponent_RunePanel))]
    public class UIBattleComponent_RunePanel_Rune: Entity, IAwake<int, int, GameObject>, IDestroy, IUpdate
    {
        public int ConfigId;
        public int Count;
        public float CooldownTimer;

        public float Cooldown;
        public ItemConfig Config => ItemConfigCategory.Instance.Get(this.ConfigId);

        public GameObject GameObject;

        public Button Button_Use;

        public Image Image_Icon;
        public Image Image_CDMask;

        public TextMeshProUGUI Text_RuneCount;
    }
}