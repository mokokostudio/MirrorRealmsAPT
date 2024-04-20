using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBattleComponent))]
    public class UIBattleComponent_GetItemTipPanel: Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject GameObject;

        public GameObject Template;
    }
}