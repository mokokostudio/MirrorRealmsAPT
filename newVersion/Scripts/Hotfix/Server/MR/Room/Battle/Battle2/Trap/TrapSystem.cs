namespace ET.Server
{
    [Invoke(TimerInvokeType.TrapTimer)]
    public class TrapTimer__Handler: ATimer<Trap>
    {
        protected override void Run(Trap t)
        {
            t.OnInterval();
        }
    }

    [EntitySystemOf(typeof (Trap))]
    [FriendOfAttribute(typeof (Trap))]
    public static partial class TrapSystem
    {
        [EntitySystem]
        private static void Awake(this Trap self, int configId)
        {
            self.ConfigId = configId;

            self.TimerId = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(100, TimerInvokeType.TrapTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this Trap self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerId);
            self.ConfigId = default;
        }

        public static void OnInterval(this Trap self)
        {
            Unit selfUnit = self.GetParent<Unit>();
            var config = self.Config;

            using ListComponent<Unit> units = ListComponent<Unit>.Create();

            foreach (AOIEntity aoiEntity in selfUnit.GetSeeUnits().Values)
            {
                Unit unit = aoiEntity.GetParent<Unit>();
                UnitType unitType = unit.UnitType();
                if (unitType != UnitType.Player)
                {
                    continue;
                }

                if (!MrGeometry2DUtility.IsInCircle(selfUnit.Position, unit.Position, unit.Radius, config.Radius))
                {
                    continue;
                }

                units.Add(unit);
            }

            if (units.Count == 0)
            {
                return;
            }

            foreach (Unit unit in units)
            {
                switch ((TrapType)config.TrapType)
                {
                    case TrapType.Poison:
                        unit.GetComponent<BuffComponent2>().AddPoisonBuff(selfUnit.Id, 10f);
                        break;
                    case TrapType.Slow:
                        unit.GetComponent<BuffComponent2>().AddMovementSpeedModifyBuff(0.25f, -0.75f);
                        break;
                }
            }
        }
    }
}