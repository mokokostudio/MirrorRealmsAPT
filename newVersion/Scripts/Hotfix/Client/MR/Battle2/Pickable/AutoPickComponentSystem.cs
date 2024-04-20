using System.Linq;
using Unity.Mathematics;

namespace ET.Client
{
    [Invoke(TimerInvokeType.AutoPickComponent_PickIntervalTimer)]
    public class AutoPickComponent_PickIntervalTimer__TimerHandler: ATimer<AutoPickComponent>
    {
        protected override void Run(AutoPickComponent c)
        {
            c.OnPickIntervalTimer();
        }
    }

    [EntitySystemOf(typeof(AutoPickComponent))]
    [FriendOfAttribute(typeof(AutoPickComponent))]
    [FriendOfAttribute(typeof(ClientPickableComponent))]
    public static partial class AutoPickComponentSystem
    {
        private const long CheckInterval = 200;

        [EntitySystem]
        private static void Awake(this AutoPickComponent self, float radius)
        {
            self.Radius = radius;
            self.UnitRef = self.GetParent<Unit>();

            var timerCom = self.Root().GetComponent<TimerComponent>();
            self.TickTimerId = timerCom.NewRepeatedTimer(CheckInterval, TimerInvokeType.AutoPickComponent_PickIntervalTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this AutoPickComponent self)
        {
            var timer = self.Root().GetComponent<TimerComponent>();
            timer.Remove(ref self.TickTimerId);

            self.TickTimerId = default;
            self.Radius = default;
            self.UnitRef = default;
        }

        public static void OnPickIntervalTimer(this AutoPickComponent self)
        {
            var myUnit = self.Unit;
            var unitComponent = myUnit.Scene().GetComponent<UnitComponent>();
            foreach (Unit unit in from Unit unit in unitComponent.Children.Values
                                  let clientPickableComponent = unit.GetComponent<ClientPickableComponent>()
                                  where clientPickableComponent != null
                                  where !(math.distancesq(myUnit.Position, unit.Position) > self.RadiusSq)
                                  where clientPickableComponent.CreateTime < TimeInfo.Instance.ServerNow() - 1000 // 1s 可拾取
                                  select unit)
            {
                self.PickTreasure(unit).Coroutine();
            }
        }

        private static async ETTask PickTreasure(this AutoPickComponent self, Unit unit)
        {
            MrC2M_Pick req = new() { UnitId = unit.Id, };
            MrM2C_Pick res = (MrM2C_Pick)await self.Root().GetComponent<MrClientSenderCompnent>().Call(req);

            if (res.Error != ErrorCode.ERR_Success)
            {
                Log.Error($"PickTreasure {unit.Id} error: {res.Error} {res.Message}");
                return;
            }
        }
    }
}