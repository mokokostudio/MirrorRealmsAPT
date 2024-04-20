using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    public enum TrapType
    {
        None = 0,
        Slow,
        Poison,
    }

    [ComponentOf(typeof (Unit))]
    public class Trap: Entity, IAwake<int>, IDestroy
    {
        public int ConfigId = default;

        [BsonIgnore]
        public TrapConfig Config => TrapConfigCategory.Instance.Get(this.ConfigId);

        public long TimerId;
    }
}