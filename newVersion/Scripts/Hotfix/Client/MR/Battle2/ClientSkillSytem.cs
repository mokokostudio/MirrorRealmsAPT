namespace ET.Client
{
    [EntitySystemOf(typeof (ClientSkill))]
    [FriendOfAttribute(typeof (ClientSkill))]
    public static partial class ClientSkillSytem
    {
        [EntitySystem]
        private static void Awake(this ClientSkill self, string skillName)
        {
            self.SkillName = skillName;
        }

        [EntitySystem]
        private static void Destroy(this ClientSkill self)
        {
            self.SkillName = default;
        }

        public static string GetSkillName(this ClientSkill self)
        {
            return self.SkillName;
        }
    }
}