using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf(typeof (UIBattleComponent_InventoryPanel))]
    public class UIBattleComponent_InventoryPanel_Item: Entity, IAwake<GameObject, int,int>, IDestroy
    {
        public int ConfigId;

        public ItemConfig Config => ItemConfigCategory.Instance.Get(ConfigId);

        public GameObject GameObject;
        public Image Img_Icon;
        public TextMeshProUGUI Txt_Name;
        public TextMeshProUGUI Txt_Count;
        public GameObject Go_Star;
        public Image Img_QualityBorder;

        public int Count;
    }
}