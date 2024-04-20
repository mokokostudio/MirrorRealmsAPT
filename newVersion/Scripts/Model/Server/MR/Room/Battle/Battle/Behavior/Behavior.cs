using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof (BehaviorTempComponent))]
    public class Behavior: Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId { get; set; }

        [BsonIgnore]
        public BehaviorConfig Config => BehaviorConfigCategory.Instance.Get(this.ConfigId);

        [BsonIgnore]
        public Unit Caster { get; set; }

        [BsonIgnore]
        public Unit Owner { get; set; }

        [BsonIgnore]
        public Cast CastSelf => this.Parent.GetParent<Cast>();

        [BsonIgnore]
        public Buff BuffSelf => this.Parent.GetParent<Buff>();

        [BsonIgnore]
        public ProjectileComponent ProjectileSelf => this.Parent.GetParent<ProjectileComponent>();
    }
}