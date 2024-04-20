using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class ProjectileComponent: Entity, IAwake<int>, IDestroy
    {
        public int ConfigId = default;

        [BsonIgnore]
        public ProjectileConfig Config => ProjectileConfigCategory.Instance.Get(this.ConfigId);

        public int TickCount = default;

        public List<long> TargetIds = new();

        public long OwnerId = default;
        
        public long TickTimerInterval = default;

        public long TickTimer100Ms = default;

        public long TickTimer1000Ms = default;

        public long TotalTimer = default;
    }
}