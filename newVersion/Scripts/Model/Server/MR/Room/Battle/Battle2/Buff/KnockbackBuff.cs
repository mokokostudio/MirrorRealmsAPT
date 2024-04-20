using Unity.Mathematics;

namespace ET.Server
{
    [ChildOf(typeof (BuffComponent2))]
    public class KnockbackBuff: Entity, IAwake, IUpdate, IDestroy
    {
        public int Priority;
        public float3 Direction;
        public float Speed;
        public float DurationSecond;
        public long EndTime;

        public long StartTime;
        public long PreviousUpdateTime;

        public EntityRef<Unit> UnitRef;

        public Unit Unit
        {
            get => this.UnitRef;
            set => this.UnitRef = value;
        }
    }
}