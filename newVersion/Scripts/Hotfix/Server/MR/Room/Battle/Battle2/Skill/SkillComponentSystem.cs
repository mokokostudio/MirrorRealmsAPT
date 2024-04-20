using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (SkillComponent))]
    [FriendOfAttribute(typeof (SkillComponent))]
    [FriendOfAttribute(typeof (Skill))]
    public static partial class SkillComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillComponent self)
        {
            self.CastingSkillId = 0;
            self.SkillCooldownDic = new Dictionary<string, long>();
        }

        [EntitySystem]
        private static void Destroy(this SkillComponent self)
        {
            self.CastingSkillId = default;
            self.SkillCooldownDic = default;
        }

        public static bool IsCasting(this SkillComponent self)
        {
            return self.GetCastingSkill() != null;
        }

        public static Skill GetCastingSkill(this SkillComponent self)
        {
            if (self.CastingSkillId == 0)
            {
                return null;
            }

            var skill = self.GetChild<Skill>(self.CastingSkillId);
            if (skill == null || skill.IsDisposed)
            {
                return null;
            }

            return skill;
        }

        public static void OnPlayerMoved(this SkillComponent self)
        {
            var castingSkill = self.GetCastingSkill();
            if (castingSkill != null)
            {
                if (castingSkill.OnPlayerMoved())
                {
                    self.CastingSkillId = 0;
                }
            }
        }

        /// <summary>
        /// 打断当前正在释放的技能
        /// </summary>
        public static void BreakCastingSkill(this SkillComponent self)
        {
            var castingSkill = self.GetCastingSkill();
            if (castingSkill != null)
            {
                castingSkill.Break();
            }

            self.CastingSkillId = 0;
        }

        public static int StartCast(this SkillComponent self, string skillName)
        {
            if (string.IsNullOrWhiteSpace(skillName))
            {
                return ErrorCode.ERR_Skill_NameError;
            }

            var castingSkill = self.GetCastingSkill();
            bool isCasting = castingSkill != null;
            bool combo = false;
            if (isCasting)
            {
                combo = castingSkill.CanCombo(skillName);
                if (combo)
                {
                    castingSkill.Dispose();
                    self.CastingSkillId = 0;
                }
            }

            if (isCasting && !combo)
            {
                return ErrorCode.ERR_Skill_Casting;
            }

            // 技能冷却判断
            if (self.SkillCooldownDic.TryGetValue(skillName, out var skillCooldown))
            {
                if (skillCooldown > TimeInfo.Instance.ServerNow())
                {
                    return ErrorCode.ERR_Skill_Coolingdown;
                }
            }

            var unit = self.GetParent<Unit>();

            // 技能消耗
            // 目前只支持一个消耗,并且无视startpoint, 固定在开始释放时消耗
            var skillConfig = SkillConfigComponent.Instance.Get(skillName);
            if (skillConfig.consumptionConfigs.Length > 0)
            {
                var config = skillConfig.consumptionConfigs[0];
                switch (config.type)
                {
                    case SkillConfig.ConsumptionType.HealthPoint:
                    {
                        var nc = unit.GetComponent<NumericComponent>();
                        var hp = nc[NumericType.Hp];
                        if (hp < config.value1)
                        {
                            return ErrorCode.ERR_Skill_ConsumptionNotEnough_HealPoint;
                        }

                        nc[NumericType.Hp] -= config.value1;
                        break;
                    }
                    case SkillConfig.ConsumptionType.SkillPoint:
                    {
                        var nc = unit.GetComponent<NumericComponent>();
                        var sp = nc[NumericType.Sp];
                        if (sp < config.value1)
                        {
                            return ErrorCode.ERR_Skill_ConsumptionNotEnough_SkillPoint;
                        }

                        nc[NumericType.Sp] -= config.value1;
                        break;
                    }
                    case SkillConfig.ConsumptionType.SlidePoint:
                    {
                        var nc = unit.GetComponent<NumericComponent>();
                        var sp = nc[NumericType.SlidePoint];
                        if (sp < config.value1)
                        {
                            return ErrorCode.ERR_Skill_ConsumptionNotEnough_SlidePoint;
                        }

                        nc[NumericType.SlidePoint] -= config.value1;
                        break;
                    }

                    case SkillConfig.ConsumptionType.Item:
                    {
                        var ic = unit.GetComponent<InventoryComponent>();
                        var ret = ic.RemoveItem(config.value2, config.value1);
                        if (ret != ErrorCode.ERR_Success)
                        {
                            return ret;
                        }

                        break;
                    }
                }
            }

            // 释放技能
            var newSkill = self.AddChild<Skill, Unit, string>(unit, skillName);
            self.CastingSkillId = newSkill.Id;

            // 技能冷却
            if (newSkill.Config.cooldown > 0)
            {
                var cdSecond = newSkill.Config.cooldown;

                // 方便调试
                cdSecond = 0.5f;

                self.SkillCooldownDic[skillName] = TimeInfo.Instance.ServerNow() + (long)(cdSecond * 1000);
            }

            M2C_SkillStart msg = new() { SkillId = newSkill.Id, CasterId = unit.Id, SkillName = skillName };
            MrMapMessageHelper.Broadcast(unit, msg);

            return ErrorCode.ERR_Success;
        }
    }
}