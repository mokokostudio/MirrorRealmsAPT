using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public sealed class SkillComponent: Entity, IAwake, IDestroy, ITransfer
    {
        public long CastingSkillId;

        public Dictionary<string, long> SkillCooldownDic;
    }
}