using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [ComponentOf(typeof (Scene))]
    public class PlayerWeaponResourceComponent: Entity, IAwake, IDestroy
    {
        public readonly Dictionary<string, GameObject> Dict = new();
    }
}