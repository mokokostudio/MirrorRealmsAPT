using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (KnockbackBuff))]
    [FriendOf(typeof (KnockbackBuff))]
    public static partial class KnockbackBuffSystem
    {
        [EntitySystem]
        public static void Awake(this KnockbackBuff self)
        {
            self.StartTime = TimeInfo.Instance.ServerNow();
            self.PreviousUpdateTime = self.StartTime;

            self.Unit = self.GetParent<BuffComponent2>().GetParent<Unit>();

            var numericComponent = self.Unit.GetComponent<NumericComponent>();
            numericComponent[NumericType.ForbidSkill]++;
            numericComponent[NumericType.ForbidMove]++;
            numericComponent[NumericType.ForbidRotation]++;
        }

        public static void Init(this KnockbackBuff self, int priority, float3 direction, float speed, float duration)
        {
            self.Priority = priority;
            self.Direction = direction;
            self.Speed = speed;
            self.DurationSecond = duration;
            self.EndTime = TimeInfo.Instance.ServerNow() + (long)(duration * 1000);
        }

        [EntitySystem]
        public static void Destroy(this KnockbackBuff self)
        {
            var numericComponent = self.Unit.GetComponent<NumericComponent>();
            if (numericComponent is { IsDisposed: false })
            {
                numericComponent[NumericType.ForbidSkill]--;
                numericComponent[NumericType.ForbidMove]--;
                numericComponent[NumericType.ForbidRotation]--;
            }

            self.Priority = default;
            self.Direction = default;
            self.Speed = default;
            self.DurationSecond = default;
            self.EndTime = default;

            self.StartTime = default;
            self.PreviousUpdateTime = default;

            self.Unit = null;
        }

        [EntitySystem]
        public static void Update(this KnockbackBuff self)
        {
            var now = TimeInfo.Instance.ServerNow();
            var deltaTime = (now - self.PreviousUpdateTime) / 1000f;

            var duration = (now - self.StartTime) / 1000f;
            if (duration >= self.DurationSecond)
            {
                deltaTime = self.DurationSecond - (duration - deltaTime);
            }

            var unit = self.Unit;
            var pos = unit.Position + self.Direction * self.Speed * deltaTime;

            //TODO: 墙体检测

            unit.Position = pos;

            M2C_SetPosition msg = new() { UnitId = unit.Id, Position = unit.Position, Rotation = unit.Rotation };
            MrMapMessageHelper.Broadcast(unit, msg);

            if (duration >= self.DurationSecond)
            {
                self.Dispose();
            }
        }
    }
}