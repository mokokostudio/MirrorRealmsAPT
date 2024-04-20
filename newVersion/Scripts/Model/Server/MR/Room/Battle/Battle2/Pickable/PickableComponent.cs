using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class PickableComponent: Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;
        
        [BsonIgnore]
        public PickableConfig Config => PickableConfigCategory.Instance.Get(this.ConfigId);
    }
}