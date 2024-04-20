using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class BuffComponent: Entity, IAwake, IDestroy, IDeserialize, ITransfer
    {
        public Dictionary<int, Buff> CongfigBuffs = new();
    }
}