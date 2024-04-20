using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (Cast))]
    [FriendOf(typeof (Cast))]
    public static partial class CastSystem
    {
        [EntitySystem]
        private static void Awake(this Cast self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<BehaviorTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this Cast self)
        {
            self.ConfigId = default;
            self.Caster = default;
            self.TargetIds.Clear();
            self.StartTime = default;
        }

        public static int Cast(this Cast self)
        {
            int err = self.CastCheck();
            if (err != ErrorCode.ERR_Success)
            {
                return err;
            }

            self.SelectTarget();

            err = self.CastCheckBeforeBegin();
            if (err != ErrorCode.ERR_Success)
            {
                return err;
            }

            self.CastBeginAsync().Coroutine();

            return ErrorCode.ERR_Success;
        }

        private static int CastCheck(this Cast self)
        {
            if (self == null || self.IsDisposed)
            {
                return ErrorCode.ERR_Cast_ArgsError;
            }

            if (self.Caster == null || self.Caster.IsDisposed)
            {
                return ErrorCode.ERR_Cast_CasterIsNull;
            }

            return ErrorCode.ERR_Success;
        }

        private static void SelectTarget(this Cast self)
        {
            Unit caster = self.Caster;
            CastConfig config = self.Config;

            switch ((CastSelectType)config.SelectType)
            {
                case CastSelectType.External:
                {
                }
                    break;
                case CastSelectType.SelfSelect:
                {
                    self.TargetIds.Clear();
                    self.TargetIds.Add(caster.Id);
                    break;
                }
                case CastSelectType.SelectInCircle:
                {
                    self.TargetIds.Clear();

                    bool includeSelf = int.Parse(config.SelectParams[0]) != 0;
                    float range = float.Parse(config.SelectParams[1]);

                    foreach (Unit unit in caster.GetSeeUnits().Values
                                     .Select(aoiEntity => aoiEntity.GetParent<Unit>())
                                     .Where(unit => unit.UnitType() == UnitType.Player || unit.UnitType() == UnitType.Monster))
                    {
                        if (!includeSelf && unit == caster)
                        {
                            continue;
                        }

                        if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) <= 0)
                        {
                            continue;
                        }

                        if (!MrGeometry2DUtility.IsInCircle(caster.Position, unit.Position, unit.Radius, range))
                        {
                            continue;
                        }

                        self.TargetIds.Add(unit.Id);
                    }
                }
                    break;
                case CastSelectType.SelectInFan:
                {
                    self.TargetIds.Clear();

                    bool includeSelf = int.Parse(config.SelectParams[0]) != 0;
                    float range = float.Parse(config.SelectParams[1]);
                    float angle = float.Parse(config.SelectParams[2]);

                    foreach (Unit unit in caster.GetSeeUnits().Values
                                     .Select(aoiEntity => aoiEntity.GetParent<Unit>())
                                     .Where(unit => unit.UnitType() == UnitType.Player || unit.UnitType() == UnitType.Monster))
                    {
                        if (!includeSelf && unit == caster)
                        {
                            continue;
                        }

                        if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) <= 0)
                        {
                            continue;
                        }

                        if (!MrGeometry2DUtility.IsInFrontFan(caster.Position, caster.Forward, unit.Position, unit.Radius, range, angle))
                        {
                            continue;
                        }

                        self.TargetIds.Add(unit.Id);
                    }
                }
                    break;
                case CastSelectType.SelectInRectangle:
                {
                    self.TargetIds.Clear();

                    bool includeSelf = int.Parse(config.SelectParams[0]) != 0;
                    float rectLength = float.Parse(config.SelectParams[1]);
                    float rectWidth = float.Parse(config.SelectParams[2]);

                    foreach (Unit unit in caster.GetSeeUnits().Values
                                     .Select(aoiEntity => aoiEntity.GetParent<Unit>())
                                     .Where(unit => unit.UnitType() == UnitType.Player || unit.UnitType() == UnitType.Monster))
                    {
                        if (!includeSelf && unit == caster)
                        {
                            continue;
                        }

                        if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) <= 0)
                        {
                            continue;
                        }

                        if (!MrGeometry2DUtility.IsInFrontRectangle(caster.Position, caster.Forward, unit.Position, unit.Radius, rectLength, rectWidth))
                        {
                            continue;
                        }

                        self.TargetIds.Add(unit.Id);
                    }
                }
                    break;
            }
        }

        private static int CastCheckBeforeBegin(this Cast self)
        {
            switch ((CastSelectType)self.Config.SelectType)
            {
                case CastSelectType.External:
                    break;
                case CastSelectType.SelfSelect:
                case CastSelectType.SelectInCircle:
                case CastSelectType.SelectInFan:
                case CastSelectType.SelectInRectangle:
                {
                    if (self.TargetIds.Count < 1)
                    {
                        return ErrorCode.ERR_Cast_TargetIsNull;
                    }
                }
                    break;
                default:
                    break;
            }

            return ErrorCode.ERR_Success;
        }

        private static async ETTask CastBeginAsync(this Cast self)
        {
            bool notBreak = self.Caster.GetComponent<SkillStatusComponent>()?.RunningSkill(self) ?? true;

            if (!notBreak)
            {
                self.Break();
                return;
            }

            CastConfig config = self.Config;

            self.StartTime = TimeInfo.Instance.ServerNow();
            M2C_CastStart msg = new()
            {
                CastId = self.Id, CasterId = self.Caster.Id, CastCongfigId = config.Id, TargetIds = new(),
            };
            msg.TargetIds.AddRange(self.TargetIds);
            MrMapMessageHelper.SendClient(self.Caster, msg, (NoticeClientType)config.NoticeClientType);

            if (config.Times.Count < 1)
            {
                return;
            }

            long castInstanceId = 0;
            long casterInstanceId = 0;

            foreach (int time in config.Times)
            {
                castInstanceId = self.InstanceId;
                casterInstanceId = self.Caster.InstanceId;
                await self.Root().GetComponent<TimerComponent>().WaitTillAsync(self.StartTime + time);
                if (!self.CheckAsyncInvalid(castInstanceId, casterInstanceId))
                {
                    Log.Error($"cast begin async invalid: {self.InstanceId} {self.Caster.InstanceId}");
                    return;
                }

                foreach (CastBehaviorTimes castBehaviorTimes in config.TimesDict[time])
                {
                    if (castBehaviorTimes.IsSelfImpact)
                    {
                        self.HandleSelfImpact(castBehaviorTimes.Index);
                    }
                    else
                    {
                        self.HandleTargetImpact(castBehaviorTimes.Index);
                    }
                }
            }

            if (config.TotalTime > 0)
            {
                castInstanceId = self.InstanceId;
                casterInstanceId = self.Caster.InstanceId;

                await self.Root().GetComponent<TimerComponent>().WaitTillAsync(self.StartTime + config.TotalTime);

                if (!self.CheckAsyncInvalid(castInstanceId, casterInstanceId))
                {
                    Log.Error($"cast begin async invalid: {self.InstanceId} {self.Caster.InstanceId}");
                    return;
                }
            }

            self.CastFinish();
        }

        private static bool CheckAsyncInvalid(this Cast self, long castInstnaceId, long casterInstanceId)
        {
            if (self.Caster == null)
            {
                return false;
            }

            if (self.Caster.IsDisposed)
            {
                return false;
            }

            if (self.InstanceId != castInstnaceId)
            {
                return false;
            }

            if (self.Caster.InstanceId != casterInstanceId)
            {
                return false;
            }

            return true;
        }

        private static void HandleSelfImpact(this Cast self, int index)
        {
            self.SelectTarget();

            if (self.TargetIds.Count < 1)
            {
                return;
            }

            CastConfig config = self.Config;

            M2C_CastImpact msg = new() { CastId = self.Id, CasterId = self.Caster.Id, TargetIds = new() };
            msg.TargetIds.AddRange(self.TargetIds);
            MrMapMessageHelper.SendClient(self.Caster, msg, (NoticeClientType)config.NoticeClientType);

            if (config.SelfImpactBehaviors.Length > index)
            {
                int behaivorId = config.SelfImpactBehaviors[index];
                if (behaivorId > 0)
                {
                    self.CreateBehavior(behaivorId, self.Caster, BehaviorRunType.CastImpact);
                }
            }

            if (config.SelfImpactBuffs.Length > index)
            {
                int buffId = config.SelfImpactBuffs[index];
                if (buffId > 0)
                {
                    self.Caster.GetComponent<BuffComponent>()?.CreateAndAdd(buffId);
                }
            }
        }

        private static void HandleTargetImpact(this Cast self, int index)
        {
            self.SelectTarget();

            if (self.TargetIds.Count < 1)
            {
                return;
            }

            CastConfig config = self.Config;

            M2C_CastImpact msg = new() { CastId = self.Id, CasterId = self.Caster.Id, TargetIds = new() };
            msg.TargetIds.AddRange(self.TargetIds);
            MrMapMessageHelper.SendClient(self.Caster, msg, (NoticeClientType)config.NoticeClientType);

            UnitComponent unitComponent = self.Root().GetComponent<UnitComponent>();

            foreach (Unit unit in self.TargetIds
                             .Select(targetId => unitComponent.Get(targetId))
                             .Where(unit => unit is { IsDisposed: false }))
            {
                if (config.ImpactBehaviors.Length > index)
                {
                    int behaviorId = config.ImpactBehaviors[index];
                    if (behaviorId > 0)
                    {
                        self.CreateBehavior(behaviorId, unit, BehaviorRunType.CastImpact);
                    }
                }

                if (config.ImpactBuffs.Length > index)
                {
                    int buffId = config.ImpactBuffs[index];
                    if (buffId > 0)
                    {
                        unit.GetComponent<BuffComponent>()?.CreateAndAdd(buffId);
                    }
                }
            }
        }

        private static void CastFinish(this Cast self)
        {
            bool notBreak = self.Caster.GetComponent<SkillStatusComponent>()?.FinishSkill(self) ?? true;

            if (!notBreak)
            {
                self.Break();
                return;
            }

            // 没有持续时间的瞬发技能不通知客户端结束, 客户端自行结束
            if (self.Config.TotalTime > 0)
            {
                M2C_CastFinish msg = new() { CastId = self.Id, CasterId = self.Caster.Id };
                MrMapMessageHelper.SendClient(self.Caster, msg, (NoticeClientType)self.Config.NoticeClientType);
            }

            foreach (int behaviorId in self.Config.FinishBehaviors)
            {
                self.CreateBehavior(behaviorId, self.Caster, BehaviorRunType.CastFinish);
            }

            self.Dispose();
        }

        private static void Break(this Cast self)
        {
            M2C_CastBreak msg = new() { CastId = self.Id, CasterId = self.Caster.Id };
            MrMapMessageHelper.SendClient(self.Caster, msg, (NoticeClientType)self.Config.NoticeClientType);

            self.Dispose();
        }
    }
}