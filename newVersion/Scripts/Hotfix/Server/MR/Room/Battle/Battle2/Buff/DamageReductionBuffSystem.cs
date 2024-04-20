namespace ET.Server
{
    [Invoke(TimerInvokeType.DamageReductionModifyBuffTimer)]
    public class DamageReductionBuff_TimerHandler: ATimer<DamageReductionBuff>
    {
        protected override void Run(DamageReductionBuff buff)
        {
            buff.Dispose();
        }
    }

    [EntitySystemOf(typeof (DamageReductionBuff))]
    [FriendOf(typeof (DamageReductionBuff))]
    public static partial class DamageReductionBuffSystem
    {
        private enum ModifyType
        {
            Add,
            Remove
        }

        [EntitySystem]
        private static void Awake(this DamageReductionBuff self, float durationSecond, float modifyPercent)
        {
            self.DurationSecond = durationSecond;
            self.ModifyPercent = modifyPercent;

            self.Modify(ModifyType.Add);

            var buffEndTime = TimeInfo.Instance.ServerNow() + (long)(self.DurationSecond * 1000);
            self.TimerId = self.Root().GetComponent<TimerComponent>().NewOnceTimer(buffEndTime, TimerInvokeType.DamageReductionModifyBuffTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this DamageReductionBuff self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerId);
            self.Modify(ModifyType.Remove);

            self.ModifyPercent = default;
        }

        private static void Modify(this DamageReductionBuff self, ModifyType modifyType)
        {
            var owner = self.GetParent<BuffComponent2>().GetParent<Unit>();
            var numericComponent = owner.GetComponent<NumericComponent>();
            if (numericComponent is { IsDisposed: false })
            {
                var modifyPercent = (long)self.ModifyPercent * 100 * 10000;
                if (modifyType == ModifyType.Add)
                {
                    numericComponent[NumericType.DamageReduction] += modifyPercent;
                }
                else
                {
                    numericComponent[NumericType.DamageReduction] -= modifyPercent;
                }
            }
        }
    }
}