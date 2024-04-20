using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class BuffComponent2: Entity, IAwake, IDestroy, ITransfer
    {
        public Dictionary<BuffType, long> BuffDic;
    }
}