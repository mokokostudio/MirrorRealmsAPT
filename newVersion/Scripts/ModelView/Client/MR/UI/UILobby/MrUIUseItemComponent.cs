using TMPro;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MrUIUseItemComponent: Entity, IAwake, IDestroy
    {
        public TMP_Text ItemName;
        public Image ItemIcon;
        public TMP_InputField InputField;
        public Button ConfirmBtn;
        public Button BgMaskBtn;

        public int ItemId;
        public bool IsClicked;
    }
}

// EOF