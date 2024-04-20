using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MrUIBattleResultComponent : Entity, IAwake, IUpdate
    {
        public bool isEnd = false;

        public GameObject victoryIcon;
        public GameObject defeatIcon;
    }
}

// EOF