using Unity.Mathematics;

namespace ET.Server
{
    [FriendOfAttribute(typeof (ReliveComponent))]
    public static class BattleHelper
    {
        public static int CanCastSkill(Unit unit, int castConfigId)
        {
            if (!CastConfigCategory.Instance.Contain(castConfigId))
            {
                return ErrorCode.ERR_Cast_ArgsError;
            }

            if (!unit.IsAlive())
            {
                return ErrorCode.ERR_Caster_NotAlive;
            }

            int error = unit.GetComponent<SkillStatusComponent>()?.CanCastSkill(castConfigId) ?? ErrorCode.ERR_Success;
            return error;
        }

        public static void CalcAttack(Unit attacker, Unit target, Behavior behavior, bool shouldShowDamageText = true)
        {
            SkillConfig.DamageType damageType = (SkillConfig.DamageType)int.Parse(behavior.Config.Params[0]);
            float percent = float.Parse(behavior.Config.Params[1]);
            CalcAttack(attacker, target, damageType, percent, shouldShowDamageText);
        }

        public static void CalcAttack(Unit attacker, Unit target, SkillConfig.DamageType damageType, double percent, bool shouldShowDamageText = true)
        {
            percent = math.max(percent, 0);

            var attackerNum = attacker.GetComponent<NumericComponent>();
            long attack = attackerNum[NumericType.Attack];
            long damage = (long)(attack * percent);

            TakeDamage(attacker.Id, target, damageType, damage, shouldShowDamageText);
        }

        public static void TakeDamage(long attackerId, Unit target, SkillConfig.DamageType damageType, long damage, bool shouldShowDamageText = true)
        {
            NumericComponent numericComponent = target.GetComponent<NumericComponent>();

            long oldHp = numericComponent[NumericType.Hp];
            // 伤害减免
            long damageReduction = numericComponent[NumericType.DamageReduction];
            if (damageReduction > 0)
            {
                float percent = (float)damageReduction / 100f / 10000f;
                damage = (long)(damage * (1 - percent));
            }

            long tarHp = oldHp - damage;

            long finalHp = math.clamp(tarHp, 0, numericComponent[NumericType.MaxHp]);
            numericComponent[NumericType.HpBase] = finalHp;

            long newHp = numericComponent[NumericType.Hp];
            long res_damage = newHp - oldHp;

            if (res_damage > 0)
            {
                target.GetComponent<SkillStatusComponent>()?.BreakSkill();
            }

            if (res_damage != 0)
            {
                M2C_BattleResult msg = new()
                {
                    AttackerId = attackerId,
                    TargetId = target.Id,
                    DamageType = (int)damageType,
                    Damage = res_damage,
                    ShouldShowDamageText = shouldShowDamageText
                };
                MrMapMessageHelper.SendClient(target, msg, NoticeClientType.Broadcast);
            }

            if (oldHp > 0 && newHp == 0)
            {
                Kill(attackerId, target);
            }
        }

        private static void Kill(long killerId, Unit killed)
        {
            OnDead(killed);

            killed.Dispose();
        }

        private static void OnDead(Unit killed)
        {
            DropHelper.Drop(killed);

            killed.StopMovement(0);

            switch (killed.UnitType())
            {
                case UnitType.Player:
                    break;
                case UnitType.Monster:
                    break;
            }
        }
    }
}