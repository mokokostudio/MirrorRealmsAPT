using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (BuffComponent2))]
    [FriendOf(typeof (BuffComponent2))]
    [FriendOf(typeof (KnockbackBuff))]
    [FriendOf(typeof (PoisonBuff))]
    public static partial class BuffComponent2System
    {
        [EntitySystem]
        private static void Awake(this BuffComponent2 self)
        {
            self.BuffDic = new Dictionary<BuffType, long>();
        }

        [EntitySystem]
        private static void Destroy(this BuffComponent2 self)
        {
            self.BuffDic.Clear();
            self.BuffDic = default;
        }

        public static void AddKnockbackBuff(this BuffComponent2 self, int priority, float3 direction, float speed, float durationSecond)
        {
            // 同类型buff只能存在一个
            if (self.BuffDic.ContainsKey(BuffType.Knockback))
            {
                var oldBuff = self.GetChild<KnockbackBuff>(self.BuffDic[BuffType.Knockback]);
                if (oldBuff is { IsDisposed: false })
                {
                    // 优先级低于当前的击退buff不生效
                    if (priority < oldBuff.Priority)
                    {
                        return;
                    }

                    oldBuff.Dispose();
                }
            }

            var buff = self.AddChild<KnockbackBuff>();
            buff.Init(priority, direction, speed, durationSecond);
            self.BuffDic[BuffType.Knockback] = buff.Id;
        }

        public static void AddMovementSpeedModifyBuff(this BuffComponent2 self, float durationSecond, float modifyPercent)
        {
            // 同类型buff只能存在一个
            if (self.BuffDic.ContainsKey(BuffType.MovementSpeedModify))
            {
                var oldBuff = self.GetChild<MovementSpeedModifyBuff>(self.BuffDic[BuffType.MovementSpeedModify]);
                if (oldBuff is { IsDisposed: false })
                {
                    oldBuff.Dispose();
                }
            }

            var buff = self.AddChild<MovementSpeedModifyBuff, float, float>(durationSecond, modifyPercent);
            self.BuffDic[BuffType.MovementSpeedModify] = buff.Id;
        }

        public static void AddAttackModifyBuff(this BuffComponent2 self, float durationSecond, float modifyPercent)
        {
            // 同类型buff只能存在一个
            if (self.BuffDic.ContainsKey(BuffType.AttackModify))
            {
                var oldBuff = self.GetChild<AttackModifyBuff>(self.BuffDic[BuffType.AttackModify]);
                if (oldBuff is { IsDisposed: false })
                {
                    oldBuff.Dispose();
                }
            }

            var buff = self.AddChild<AttackModifyBuff, float, float>(durationSecond, modifyPercent);
            self.BuffDic[BuffType.AttackModify] = buff.Id;
        }

        public static void AddDamageReductionBuff(this BuffComponent2 self, float durationSecond, float modifyPercent)
        {
            // 同类型buff只能存在一个
            if (self.BuffDic.ContainsKey(BuffType.DamageReduction))
            {
                var oldBuff = self.GetChild<DamageReductionBuff>(self.BuffDic[BuffType.DamageReduction]);
                if (oldBuff is { IsDisposed: false })
                {
                    oldBuff.Dispose();
                }
            }

            var buff = self.AddChild<DamageReductionBuff, float, float>(durationSecond, modifyPercent);
            self.BuffDic[BuffType.DamageReduction] = buff.Id;
        }

        public static void AddPoisonBuff(this BuffComponent2 self, long casterId, float durationSecond)
        {
            // 同类型buff只能存在一个
            if (self.BuffDic.ContainsKey(BuffType.Poison))
            {
                var oldBuff = self.GetChild<PoisonBuff>(self.BuffDic[BuffType.Poison]);
                if (oldBuff is { IsDisposed: false })
                {
                    if (oldBuff.CasterId == casterId)
                    {
                        oldBuff.OnStack(durationSecond);
                        return;
                    }

                    oldBuff.Dispose();
                }
            }

            var buff = self.AddChild<PoisonBuff, long, float>(casterId, durationSecond);
            self.BuffDic[BuffType.Poison] = buff.Id;
        }
    }
}