using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;


namespace ET.Server
{
    [ChildOf(typeof (CastComponent))]
    public sealed class Cast: Entity, IAwake<int>, IDestroy
    {
        public int ConfigId { get; set; }

        [BsonIgnore]
        public CastConfig Config => CastConfigCategory.Instance.Get(this.ConfigId);

        [BsonIgnore]
        public Unit Caster { get; set; }

        [BsonIgnore]
        public List<long> TargetIds = new();

        public long StartTime;
    }
}