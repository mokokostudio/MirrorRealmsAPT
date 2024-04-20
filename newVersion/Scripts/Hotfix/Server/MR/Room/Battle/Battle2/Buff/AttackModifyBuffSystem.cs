namespace ET.Server
{
    [Invoke(TimerInvokeType.AttackModifyBuffTimer)]
    public class AttackModifyBuff_TimerHandler: ATimer<AttackModifyBuff>
    {
        protected override void Run(AttackModifyBuff buff)
        {
            buff.Dispose();
        }
    }

    [EntitySystemOf(typeof (AttackModifyBuff))]
    [FriendOf(typeof (AttackModifyBuff))]
    public static partial class AttackModifyBuffSystem
    {
        private enum ModifyType
        {
            Add,
            Remove
        }

        [EntitySystem]
        private static void Awake(this AttackModifyBuff self, float durationSecond, float modifyPercent)
        {
            self.DurationSecond = durationSecond;
            self.ModifyPercent = modifyPercent;

            self.Modify(ModifyType.Add);

            var buffEndTime = TimeInfo.Instance.ServerNow() + (long)(self.DurationSecond * 1000);
            self.TimerId = self.Root().GetComponent<TimerComponent>().NewOnceTimer(buffEndTime, TimerInvokeType.AttackModifyBuffTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this AttackModifyBuff self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerId);
            self.Modify(ModifyType.Remove);

            self.ModifyPercent = default;
        }

        private static void Modify(this AttackModifyBuff self, ModifyType modifyType)
        {
            var owner = self.GetParent<BuffComponent2>().GetParent<Unit>();
            var numericComponent = owner.GetComponent<NumericComponent>();
            if (numericComponent is { IsDisposed: false })
            {
                var modifyPercent = (long)self.ModifyPercent * 100 * 10000;
                if (modifyType == ModifyType.Add)
                {
                    numericComponent[NumericType.AttackPct] += modifyPercent;
                }
                else
                {
                    numericComponent[NumericType.AttackPct] -= modifyPercent;
                }
            }
        }
    }
}