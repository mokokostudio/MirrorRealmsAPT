using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBattleComponent))]
    public class UIBattleComponent_RunePanel: Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject Rune_Template;

        // 固定显示这3种
        public int[] ShowRuneConfigIds = { 4, 5, 6 };
    }
}