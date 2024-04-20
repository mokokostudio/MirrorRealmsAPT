namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MrPlayerComponent : Entity, IAwake
    {
        public long MyId { get; set; }
        public string MyName { get; set; }
    }
}