namespace ET.Server
{
    [EntitySystemOf(typeof (SkillStatusComponent))]
    [FriendOfAttribute(typeof (ET.Server.SkillStatusComponent))]
    public static partial class SkillStatusComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SkillStatusComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SkillStatusComponent self)
        {
            self.ClearCurSkillInfo();
            self.CoolDowns.Clear();
        }

        public static int CanCastSkill(this SkillStatusComponent self, int castConfigId)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit == null)
            {
                return ErrorCode.ERR_Cast_UnitIsNull;
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent == null)
            {
                return ErrorCode.ERR_Cast_NumComIsNull;
            }

            if (numericComponent[NumericType.ForbidSkill] > 0)
            {
                return ErrorCode.ERR_Cast_ForbidSkill;
            }

            if (self.CoolDowns.TryGetValue(castConfigId, out long tarTime))
            {
                if (TimeInfo.Instance.ServerNow() <= tarTime)
                {
                    return ErrorCode.ERR_Cast_SkillCDDown;
                }
            }

            return ErrorCode.ERR_Success;
        }

        public static bool StartSkill(this SkillStatusComponent self, Cast cast)
        {
            int castConfigId = cast.ConfigId;
            if (self.CanCastSkill(castConfigId) != ErrorCode.ERR_Success)
            {
                return false;
            }

            if (cast.Config.StatusSkill == 0)
            {
                return true;
            }

            long now = TimeInfo.Instance.ServerNow();

            self.CurSkillCastId = castConfigId;
            self.CurSkillCastInstanceId = cast.InstanceId;
            self.CurSKillStartTime = now;
            self.CurSkillStatus = SkillStatusType.Init;

            int coolDown = CastConfigCategory.Instance.Get((castConfigId)).CoolDown;
            if (coolDown > 0)
            {
                self.CoolDowns[castConfigId] = now + coolDown;
                Unit unit = self.GetParent<Unit>();

                M2C_CoolDownChange msg = new() { CastConfigIds = new(), CoolDownTimes = new(), CoolDownStartTime = new() };
                msg.CastConfigIds.Add(self.CurSkillCastId);
                msg.CoolDownTimes.Add(self.CoolDowns[self.CurSkillCastId]);
                msg.CoolDownStartTime.Add(self.CurSKillStartTime);
                MrMapMessageHelper.SendClient(unit, msg, NoticeClientType.Self);
            }

            return true;
        }

        public static bool RunningSkill(this SkillStatusComponent self, Cast cast)
        {
            if (cast.Config.StatusSkill == 0)
            {
                return true;
            }

            if (self.CurSkillStatus != SkillStatusType.Init || self.CurSkillCastInstanceId != cast.InstanceId)
            {
                return false;
            }

            self.CurSkillStatus = SkillStatusType.Running;

            return true;
        }

        public static bool FinishSkill(this SkillStatusComponent self, Cast cast)
        {
            if (cast.Config.StatusSkill == 0)
            {
                return true;
            }

            if (self.CurSkillStatus != SkillStatusType.Running || self.CurSkillCastInstanceId != cast.InstanceId)
            {
                return false;
            }

            self.CurSkillStatus = SkillStatusType.Finish;

            return true;
        }

        public static bool BreakSkill(this SkillStatusComponent self)
        {
            if (!self.CanBreakSkill())
            {
                return false;
            }

            self.ClearCurSkillInfo();

            return true;
        }

        public static bool CanBreakSkill(this SkillStatusComponent self)
        {
            return true;
        }

        public static void ClearCurSkillInfo(this SkillStatusComponent self)
        {
            self.CurSkillCastInstanceId = default;
            self.CurSkillCastId = default;
            self.CurSKillStartTime = default;
            self.CurSkillStatus = SkillStatusType.New;
        }
    }
}