namespace ET.Server
{
    [ChildOf(typeof (BuffComponent2))]
    public class PoisonBuff: Entity, IAwake<long, float>, IDestroy, IUpdate
    {
        public long CasterId;
        public long NextPoisonEffectTime;

        public long StartTime;
        public long EndTime;
        public long PreviousUpdateTime;

        public EntityRef<Unit> UnitRef;

        public Unit Unit
        {
            get => this.UnitRef;
            set => this.UnitRef = value;
        }
    }
}