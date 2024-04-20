using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (UIBattleComponent))]
    public class UIBattleComponent_InventoryPanel: Entity, IAwake<GameObject>
    {
        public bool IsShow;
        public GameObject GameObject;
        public Button Btn_Close;
        public GameObject Item_Template;
    }
}