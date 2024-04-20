using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    public enum SkillStatusType: byte
    {
        New = 0,
        Init = 1,
        Running = 2,
        Finish = 3
    }

    [ComponentOf(typeof (Unit))]
    public class SkillStatusComponent: Entity, IAwake, IDestroy
    {
        public long CurSkillCastInstanceId = default;

        public int CurSkillCastId = default;

        public long CurSKillStartTime = default;

        public SkillStatusType CurSkillStatus = SkillStatusType.New;

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> CoolDowns = new();
    }
}