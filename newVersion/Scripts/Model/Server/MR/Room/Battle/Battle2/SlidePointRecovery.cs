using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class SlidePointRecovery: Entity, IAwake, IDestroy, ITransfer, IDeserialize
    {
        [BsonIgnore]
        public int ValuePerSecond;

        [BsonIgnore]
        public long TimerId;
    }
}