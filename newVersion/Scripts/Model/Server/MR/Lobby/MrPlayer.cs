namespace ET.Server
{
    [ChildOf(typeof(MrPlayerMgr))]
    public sealed class MrPlayer : Entity, IAwake<string>
    {
        public string Account { get; set; }
        
    }
}