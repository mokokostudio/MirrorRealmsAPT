namespace ET.Server
{
    [Invoke(TimerInvokeType.MovementSpeedModifyBuffTimer)]
    public class MovementSpeedModifyBuff_TimerHandler: ATimer<MovementSpeedModifyBuff>
    {
        protected override void Run(MovementSpeedModifyBuff buff)
        {
            buff.Dispose();
        }
    }

    [EntitySystemOf(typeof (MovementSpeedModifyBuff))]
    [FriendOf(typeof (MovementSpeedModifyBuff))]
    public static partial class MovementSpeedModifyBuffSystem
    {
        private enum ModifyType
        {
            Add,
            Remove
        }

        [EntitySystem]
        private static void Awake(this MovementSpeedModifyBuff self, float durationSecond, float modifyPercent)
        {
            self.DurationSecond = durationSecond;
            self.ModifyPercent = modifyPercent;

            self.Modify(ModifyType.Add);

            var buffEndTime = TimeInfo.Instance.ServerNow() + (long)(self.DurationSecond * 1000);
            self.TimerId = self.Root().GetComponent<TimerComponent>().NewOnceTimer(buffEndTime, TimerInvokeType.MovementSpeedModifyBuffTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this MovementSpeedModifyBuff self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerId);

            self.Modify(ModifyType.Remove);

            self.ModifyPercent = default;
        }

        private static void Modify(this MovementSpeedModifyBuff self, ModifyType modifyType)
        {
            var owner = self.GetParent<BuffComponent2>().GetParent<Unit>();
            var numericComponent = owner.GetComponent<NumericComponent>();
            if (numericComponent is { IsDisposed: false })
            {
                var modifyPercent = (long)(self.ModifyPercent * 100 * 10000);
                if (modifyType == ModifyType.Add)
                {
                    numericComponent[NumericType.SpeedPct] += modifyPercent;
                }
                else
                {
                    numericComponent[NumericType.SpeedPct] -= modifyPercent;
                }
            }
        }
    }
}