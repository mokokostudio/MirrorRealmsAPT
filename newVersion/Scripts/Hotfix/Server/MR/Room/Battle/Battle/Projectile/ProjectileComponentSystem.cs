using System;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (ProjectileComponent))]
    [FriendOfAttribute(typeof (ET.Server.ProjectileComponent))]
    [FriendOfAttribute(typeof (ET.Server.Cast))]
    public static partial class ProjectileComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ProjectileComponent self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<BehaviorTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ProjectileComponent self)
        {
            self.ConfigId = default;
            self.TickCount = default;
            self.OwnerId = default;

            var timer = self.Scene().GetComponent<TimerComponent>();
            timer.Remove(ref self.TickTimerInterval);
            timer.Remove(ref self.TickTimer100Ms);
            timer.Remove(ref self.TickTimer1000Ms);
            timer.Remove(ref self.TotalTimer);

            self.TickTimerInterval = default;
            self.TickTimer100Ms = default;
            self.TickTimer1000Ms = default;
            self.TotalTimer = default;
        }

        public static void Start(this ProjectileComponent self)
        {
            Unit owner = self.GetOwner();
            if (owner == null)
            {
                self.Dispose();
                return;
            }

            ProjectileConfig config = self.Config;

            foreach (int behaviorId in config.SpawnBehaviors)
            {
                self.CreateBehavior(behaviorId, owner, owner, BehaviorRunType.ProjectileSpawn);
            }

            TimerComponent timerCom = self.Root().GetComponent<TimerComponent>();
            if (config.TickInterval > 0)
            {
                int tickInterval = config.TickInterval;
                if (tickInterval <= 0)
                {
                    tickInterval = 100;
                }

                self.TickTimerInterval = timerCom.NewRepeatedTimer(tickInterval, TimerInvokeType.ProjectileTickTimerInterval, self);
            }

            if (config.TickBehaviors100Ms.Length > 0)
            {
                self.TickTimer100Ms = timerCom.NewRepeatedTimer(100, TimerInvokeType.ProjectileTickTimer100Ms, self);
            }

            if (config.TickBehaviors1000Ms.Length > 0)
            {
                self.TickTimer1000Ms = timerCom.NewRepeatedTimer(1000, TimerInvokeType.ProjectileTickTimer1000Ms, self);
            }

            if (config.TotalTime > 0)
            {
                long tillTime = TimeInfo.Instance.ServerNow() + config.TotalTime;
                self.TotalTimer = timerCom.NewOnceTimer(tillTime, TimerInvokeType.ProjectileTotalTimer, self);
            }
        }

        public static void OnTickInterval(this ProjectileComponent self)
        {
            Unit selfUnit = self.GetParent<Unit>();
            Unit owner = self.GetOwner();
            if (owner == null || owner.IsDisposed)
            {
                self.DoDispose();
                return;
            }

            ProjectileConfig config = self.Config;
            self.SelectTarget();

            if (self.TargetIds.Count < 1)
            {
                return;
            }

            self.TickCount++;

            foreach (var tickCastId in config.TickCastIds)
            {
                Cast cast = owner.CreateCast(tickCastId);
                cast.TargetIds.AddRange(self.TargetIds);
                int err = cast.Cast();
                if (err != ErrorCode.ERR_Success)
                {
                    Log.Console($"projectile({self.ConfigId}) cast({tickCastId}) failed: {err}");
                }
            }

            foreach (int behaviorId in config.TickBehaviors)
            {
                self.CreateBehavior(behaviorId, selfUnit, selfUnit, BehaviorRunType.ProjectileTick);
            }

            if (config.TickLimit > 0 && self.TickCount >= config.TickLimit)
            {
                self.DoDestory();
            }
        }

        public static void OnTick100Ms(this ProjectileComponent self)
        {
            self.SelectTarget();

            ProjectileConfig config = self.Config;
            if (config.TickBehaviors100Ms.Length > 0)
            {
                Unit unit = self.GetParent<Unit>();
                foreach (int behaviorId in config.TickBehaviors100Ms)
                {
                    self.CreateBehavior(behaviorId, unit, unit, BehaviorRunType.ProjectileTick);
                }
            }
        }

        public static void OnTick1000Ms(this ProjectileComponent self)
        {
            self.SelectTarget();

            ProjectileConfig config = self.Config;
            if (config.TickBehaviors1000Ms.Length > 0)
            {
                Unit unit = self.GetParent<Unit>();
                foreach (int behaviorId in config.TickBehaviors1000Ms)
                {
                    self.CreateBehavior(behaviorId, unit, unit, BehaviorRunType.ProjectileTick);
                }
            }
        }

        public static void OnTimeOver(this ProjectileComponent self)
        {
            self.DoDestory();
        }

        public static void DoDestory(this ProjectileComponent self)
        {
            self.Scene().GetComponent<TimerComponent>().Remove(ref self.TotalTimer);

            Unit owner = self.GetOwner();
            if (owner == null || owner.IsDisposed)
            {
                self.DoDispose();
                return;
            }

            ProjectileConfig config = self.Config;
            if (config.DestructionBehaviors.Length > 0)
            {
                Unit unit = self.GetParent<Unit>();
                foreach (int behaviorId in config.DestructionBehaviors)
                {
                    self.CreateBehavior(behaviorId, unit, unit, BehaviorRunType.ProjectileDestruction);
                }
            }

            self.DoDispose();
        }

        public static void SelectTarget(this ProjectileComponent self)
        {
            self.TargetIds.Clear();
            Unit selfUnit = self.GetParent<Unit>();
            Unit owner = self.GetOwner();
            ProjectileConfig config = self.Config;

            switch ((ProjectileSelectType)config.SelectType)
            {
                case ProjectileSelectType.None:
                    break;
                case ProjectileSelectType.Circle:
                {
                    bool includeSelf = int.Parse(config.SelectParams[0]) != 0;
                    float range = float.Parse(config.SelectParams[1]);

                    foreach (AOIEntity aoiEntity in selfUnit.GetSeeUnits().Values)
                    {
                        Unit unit = aoiEntity.GetParent<Unit>();
                        UnitType unitType = unit.UnitType();
                        if (unitType != UnitType.Player && unitType != UnitType.Monster)
                        {
                            continue;
                        }

                        if (!includeSelf && unit == owner)
                        {
                            continue;
                        }

                        if (!MrGeometry2DUtility.IsInCircle(owner.Position, unit.Position, unit.Radius, range))
                        {
                            continue;
                        }

                        self.TargetIds.Add(unit.Id);
                    }
                }
                    break;
                case ProjectileSelectType.Fan:
                {
                    bool includeSelf = int.Parse(config.SelectParams[0]) != 0;
                    float range = float.Parse(config.SelectParams[1]);
                    float angle = float.Parse(config.SelectParams[2]);

                    foreach (AOIEntity aoiEntity in selfUnit.GetSeeUnits().Values)
                    {
                        Unit unit = aoiEntity.GetParent<Unit>();
                        UnitType unitType = unit.UnitType();
                        if (unitType != UnitType.Player && unitType != UnitType.Monster)
                        {
                            continue;
                        }

                        if (!includeSelf && unit == owner)
                        {
                            continue;
                        }

                        if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) <= 0)
                        {
                            continue;
                        }

                        if (!MrGeometry2DUtility.IsInFrontFan(owner.Position, owner.Forward, unit.Position, unit.Radius, range, angle))
                        {
                            continue;
                        }

                        self.TargetIds.Add(unit.Id);
                    }
                }
                    break;
                case ProjectileSelectType.Rectangle:
                {
                    bool includeSelf = int.Parse(config.SelectParams[0]) != 0;
                    float rectLength = float.Parse(config.SelectParams[1]);
                    float rectWidth = float.Parse(config.SelectParams[2]);

                    foreach (AOIEntity aoiEntity in selfUnit.GetSeeUnits().Values)
                    {
                        Unit unit = aoiEntity.GetParent<Unit>();
                        UnitType unitType = unit.UnitType();
                        if (unitType != UnitType.Player && unitType != UnitType.Monster)
                        {
                            continue;
                        }

                        if (!includeSelf && unit == owner)
                        {
                            continue;
                        }

                        if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) <= 0)
                        {
                            continue;
                        }

                        if (!MrGeometry2DUtility.IsInFrontRectangle(owner.Position, owner.Forward, unit.Position, unit.Radius, rectLength, rectWidth))
                        {
                            continue;
                        }

                        self.TargetIds.Add(unit.Id);
                    }
                }
                    break;
                default:
                    throw new Exception($"Unknown projectiel SelectType: {config.SelectType}");
            }
        }

        private static void DoDispose(this ProjectileComponent self)
        {
            self.GetParent<Unit>().StopMovement(0);
            self.Scene().GetComponent<UnitComponent>().Remove(self.Parent.Id);
        }

        public static Unit GetOwner(this ProjectileComponent self)
        {
            return self.Root().GetComponent<UnitComponent>().Get(self.OwnerId);
        }

        public static void PreDestroy(this ProjectileComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimerInterval);

            Unit owner = self.GetOwner();
            if (owner == null)
            {
                return;
            }

            ProjectileConfig config = self.Config;
            if (config.DestructionBehaviors.Length < 1)
            {
                return;
            }

            foreach (int behaviorId in config.DestructionBehaviors)
            {
                self.CreateBehavior(behaviorId, owner, owner, BehaviorRunType.ProjectileDestruction);
            }
        }
    }
}