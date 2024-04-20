using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    public enum MonsterType
    {
        Normal,
        Elite,
        Boss
    }

    [ComponentOf(typeof (Unit))]
    public class MonsterComponent: Entity, IAwake<int, int>, IDestroy
    {
        public int ConfigId;
        public int GroupConfigId;

        [BsonIgnore]
        public MonsterConfig Config => MonsterConfigCategory.Instance.Get(this.ConfigId);
    }
}