using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [ComponentOf(typeof (Scene))]
    public class UI_IconResourceComponent: Entity, IAwake, IDestroy
    {
        public readonly Dictionary<string, Sprite> Dict = new();
    }
}