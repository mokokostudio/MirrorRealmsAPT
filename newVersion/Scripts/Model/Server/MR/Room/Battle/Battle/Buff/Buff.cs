using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof (BuffComponent))]
    public class Buff: Entity, IAwake<int>, IDestroy, ISerializeToEntity, IDeserialize
    {
        public int ConfigId { get; set; }

        [BsonIgnore]
        public BuffConfig Config => BuffConfigCategory.Instance.Get(this.ConfigId);

        [BsonIgnore]
        public Unit Owner { get; set; }

        public long CreateTime;

        public int TickTime;

        public long TickBeginTime;

        [BsonIgnore]
        public long TickTimer;

        [BsonIgnore]
        public long waitTickTimer;

        public long ExpireTime;

        [BsonIgnore]
        public long ExpireTimer;
    }
}