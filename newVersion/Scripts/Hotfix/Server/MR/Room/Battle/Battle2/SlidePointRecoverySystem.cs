using Unity.Mathematics;

namespace ET.Server
{
    [Invoke(TimerInvokeType.SlidePointRecoveryTimer)]
    public class SlidePointRecovery_TimerHandler: ATimer<SlidePointRecovery>
    {
        protected override void Run(SlidePointRecovery s)
        {
            s.OnSlidePointRecoveryTimer();
        }
    }

    [EntitySystemOf(typeof (SlidePointRecovery))]
    [FriendOf(typeof (SlidePointRecovery))]
    public static partial class SlidePointRecoverySystem
    {
        private const int TickInterval = 1000;

        [EntitySystem]
        private static void Awake(this SlidePointRecovery self)
        {
            self.Init();
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.SlidePointRecovery self)
        {
            self.Init();
        }

        private static void Init(this SlidePointRecovery self)
        {
            self.ValuePerSecond = 20; //TODO: 配置化

            self.TimerId = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TickInterval, TimerInvokeType.SlidePointRecoveryTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this SlidePointRecovery self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerId);
            self.ValuePerSecond = default;
        }

        public static void OnSlidePointRecoveryTimer(this SlidePointRecovery self)
        {
            var unit = self.GetParent<Unit>();
            var nc = unit.GetComponent<NumericComponent>();
            if (nc is { IsDisposed: false })
            {
                long maxSp = nc[NumericType.MaxSlidePoint];
                long oldSp = nc[NumericType.SlidePoint];
                if (oldSp >= maxSp)
                {
                    return;
                }

                long addSp = (long)(self.ValuePerSecond * (TickInterval / 1000f));
                long newSp = oldSp + addSp;
                long finalSp = math.clamp(newSp, 0, maxSp);

                nc[NumericType.SlidePointBase] = finalSp;
            }
        }
    }
}