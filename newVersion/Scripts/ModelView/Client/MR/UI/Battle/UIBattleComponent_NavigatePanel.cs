using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (UIBattleComponent))]
    public class UIBattleComponent_NavigatePanel: Entity, IAwake<GameObject>, ILateUpdate
    {
        public GameObject GameObject;
        
        public RawImage RawImg_HUD;

        public GameObject RectTransform_Target_Template;
        
        public float RawImg_HUD_WidthPixel;
    }
}