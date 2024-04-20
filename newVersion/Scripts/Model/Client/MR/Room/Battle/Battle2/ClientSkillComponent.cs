namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class ClientSkillComponent: Entity, IAwake, IDestroy
    {
        public EntityRef<ClientSkill> CastingSkillRef;

        public ClientSkill CastingSkill => CastingSkillRef;
    }
}