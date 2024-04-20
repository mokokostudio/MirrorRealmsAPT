namespace ET.Client
{
    [ChildOf(typeof(NetComponent))]
    public class MrRouterConnector: Entity, IAwake, IDestroy
    {
        public byte Flag { get; set; }
    }
}