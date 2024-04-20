namespace ET.Client
{
    [ChildOf(typeof (ClientSkillComponent))]
    public class ClientSkill: Entity, IAwake<string>, IDestroy
    {
        public string SkillName;
    }
}