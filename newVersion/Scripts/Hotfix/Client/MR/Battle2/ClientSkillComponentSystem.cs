namespace ET.Client
{
    [EntitySystemOf(typeof (ClientSkillComponent))]
    [FriendOfAttribute(typeof (ClientSkillComponent))]
    [FriendOfAttribute(typeof (ClientSkill))]
    public static partial class ClientSkillComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientSkillComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ClientSkillComponent self)
        {
        }

        public static void Start(this ClientSkillComponent self, long skillId, string skillName)
        {
            var oldSkill = self.CastingSkill;
            if (oldSkill != null)
            {
                oldSkill.Dispose();
            }

            var newSkill = self.AddChildWithId<ClientSkill, string>(skillId, skillName);
            self.CastingSkillRef = newSkill;
        }

        public static bool IsCasting(this ClientSkillComponent self, long skillId)
        {
            var skill = self.CastingSkill;
            if (skill == null)
            {
                return false;
            }

            if (skill.Id != skillId)
            {
                return false;
            }

            return true;
        }

        public static bool IsCasting(this ClientSkillComponent self, string skillName)
        {
            var skill = self.CastingSkill;
            if (skill == null)
            {
                return false;
            }

            if (skill.SkillName != skillName)
            {
                return false;
            }

            return true;
        }

        public static void Break(this ClientSkillComponent self, long skillId)
        {
            self.Finish(skillId);
        }

        public static void Finish(this ClientSkillComponent self, long skillId)
        {
            var skill = self.CastingSkill;
            if (skill == null)
            {
                return;
            }

            if (skill.Id != skillId)
            {
                return;
            }

            skill.Dispose();

            self.CastingSkillRef = null;
        }
    }
}