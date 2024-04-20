namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class ClientPickableComponent: Entity, IAwake<long>, IDestroy
    {
        public long CreateTime;
    }
}