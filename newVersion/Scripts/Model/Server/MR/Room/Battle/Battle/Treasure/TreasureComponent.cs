using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class TreasureComponent: Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        [BsonIgnore]
        public TreasureConfig Config => TreasureConfigCategory.Instance.Get(this.ConfigId);
    }
}