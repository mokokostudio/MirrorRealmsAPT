namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class AutoPickComponent: Entity, IAwake<float>, IDestroy
    {
        public float Radius;
        public float RadiusSq => Radius * Radius;
        
        public long TickTimerId;
        public EntityRef<Unit> UnitRef;

        public Unit Unit => UnitRef;
    }
}