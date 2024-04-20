using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof (UIBattleComponent_GetItemTipPanel))]
    public class UIBattleComponent_GetItemTipPanel_Item: Entity, IAwake<GameObject, int, int>, IDestroy
    {
        public GameObject GameObject;

        public long ShowGetItemTip_DestroyTimerId;
    }
}