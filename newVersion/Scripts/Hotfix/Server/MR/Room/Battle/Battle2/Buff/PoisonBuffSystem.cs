using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (PoisonBuff))]
    [FriendOf(typeof (PoisonBuff))]
    public static partial class PoisonBuffSystem
    {
        public const float PoisonDamageRate = 0.02f;
        public const long PoisonDamageInterval = 1000;

        [EntitySystem]
        private static void Awake(this PoisonBuff self, long casterId, float duration)
        {
            self.StartTime = TimeInfo.Instance.ServerNow();
            self.EndTime = self.StartTime + (long)(duration * 1000);
            self.PreviousUpdateTime = self.StartTime;
            self.NextPoisonEffectTime = self.StartTime + PoisonDamageInterval;
            self.CasterId = casterId;

            self.Unit = self.GetParent<BuffComponent2>().GetParent<Unit>();
        }

        [EntitySystem]
        private static void Destroy(this PoisonBuff self)
        {
            self.StartTime = default;
            self.EndTime = default;
            self.PreviousUpdateTime = default;
            self.NextPoisonEffectTime = default;

            self.Unit = null;
        }

        [EntitySystem]
        private static void Update(this PoisonBuff self)
        {
            var now = TimeInfo.Instance.ServerNow();

            while (now >= self.NextPoisonEffectTime)
            {
                self.NextPoisonEffectTime += PoisonDamageInterval;
                var nCom = self.Unit.GetComponent<NumericComponent>();
                var damage = (long)math.floor(nCom[NumericType.MaxHp] * PoisonDamageRate);

                BattleHelper.TakeDamage(self.CasterId, self.Unit,SkillConfig.DamageType.PoisonDamage, damage);
            }

            if (now >= self.EndTime)
            {
                self.Dispose();
            }
        }

        public static void OnStack(this PoisonBuff self, float duration)
        {
            self.EndTime = TimeInfo.Instance.ServerNow() + (long)(duration * 1000);
        }
    }
}