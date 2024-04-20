using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof (UIBattleComponent_NavigatePanel))]
    public class UIBattleComponent_NavigatePanel_Cursor: Entity, IAwake<GameObject, float>, IDestroy, ILateUpdate
    {
        public GameObject GameObject;

        public int ParentHalfWidthPixel;

        public RectTransform RectTransform;

        public float3 Destination;
    }
}