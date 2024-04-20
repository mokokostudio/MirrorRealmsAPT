namespace ET.Client
{
    [ComponentOf(typeof(Session))]
    public class MrPingComponent: Entity, IAwake, IDestroy
    {
        public long Ping { get; set; } //延迟值
    }
}