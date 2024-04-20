using System.Collections.Generic;
using System.Linq;
using ET.Server;
using Unity.Mathematics;

namespace ET
{
    [EntitySystemOf(typeof (Skill))]
    [FriendOfAttribute(typeof (Skill))]
    [FriendOfAttribute(typeof (MrArmWeaponComponent))]
    public static partial class SkillSystem
    {
        [EntitySystem]
        private static void Awake(this Skill self, Unit caster, string skillName)
        {
            self.Config = SkillConfigComponent.Instance.Get(skillName);
            self.Caster = caster;
            self.StartTimestamp = TimeInfo.Instance.ServerNow();
            self.PreviousUpdateTimestamp = self.StartTimestamp;
            self.NextPositionModifyIndex = 0;
            self.NextNumericModifyIndex = 0;
            self.NextSelfBuffIndex = 0;
            self.NextMotionIndex = 0;
            self.MotionDelta = float3.zero;
            self.NextAttackBoxIndex_Circle = 0;
            self.NextAttackBoxIndex_Rectangle = 0;

            // if (!self.Config.moveable)
            {
                self.Caster.StopMovement(0);
                self.SetForbidMove(true);
            }

            self.SetForbidRotation(true);
            self.SetForbidSkill(true);
        }

        [EntitySystem]
        private static void Destroy(this Skill self)
        {
            self.SetForbidMove(false);
            self.SetForbidRotation(false);
            self.SetForbidSkill(false);

            self.Config = default;
            self.Caster = default;
            self.StartTimestamp = default;
            self.PreviousUpdateTimestamp = default;
            self.NextPositionModifyIndex = default;
            self.NextNumericModifyIndex = default;
            self.NextSelfBuffIndex = default;
            self.NextMotionIndex = default;
            self.MotionDelta = float3.zero;
            self.NextAttackBoxIndex_Circle = default;
            self.NextAttackBoxIndex_Rectangle = default;
        }

        [EntitySystem]
        private static void Update(this Skill self)
        {
            var now = TimeInfo.Instance.ServerNow();

            self.UpdateChangeWeapon();
            self.UpdateSelfBuffs();
            self.UpdateNumbericModify();
            self.UpdatePoisionModify();
            self.UpdateMotion();
            self.UpdateAttackBox();
            self.UpdateForbidMove();
            self.UpdateForbidSkill();

            self.PreviousUpdateTimestamp = now;

            self.DisposeIfSkillFinish();
        }

        public static bool OnPlayerMoved(this Skill self)
        {
            // if (!self.Config.moveable)
            {
                self.Break();
                return true;
            }

            //return false;
        }

        public static void Break(this Skill self)
        {
            M2C_SkillBreak m2CSkillBreak = new() { SkillId = self.Id, CasterId = self.Caster.Id };
            MrMapMessageHelper.Broadcast(self.Caster, m2CSkillBreak);
            self.Dispose();
        }

        public static bool CanCombo(this Skill self, string skillName)
        {
            if (!self.IsForbidSkillSet)
            {
                return true;
            }

            var runTotalTimeSec = self.RunTotalTimeSecond;
            foreach (var comboSkillPoint in self.Config.comboSkillPoints)
            {
                var comboSkillName = comboSkillPoint.skill;
                if (comboSkillName != skillName)
                {
                    continue;
                }

                var startPoint = comboSkillPoint.startPoint;
                var endPoint = comboSkillPoint.endPoint;
                if (runTotalTimeSec < startPoint || runTotalTimeSec > endPoint)
                {
                    continue;
                }

                return true;
            }

            return false;
        }

        private static void UpdateForbidMove(this Skill self)
        {
            if (self.IsForbidMoveSet == false)
            {
                return;
            }

            var forbidMoveReleaseTime = self.Config.forbidMoveReleaseTime;
            if (forbidMoveReleaseTime <= 0)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;
            if (runTotalSecond >= forbidMoveReleaseTime)
            {
                self.SetForbidMove(false);
            }
        }

        // private static void UpdateForbidRotation(this Skill self)
        // {
        //     if (self.isForbidRotationSet == false)
        //     {
        //         return;
        //     }
        //
        //     var forbidRotationReleaseTime = self.Config.forbidRotationReleaseTime;
        //     if (forbidRotationReleaseTime <= 0)
        //     {
        //         return;
        //     }
        //
        //     var runTotalSecond = self.RunTotalTimeSecond;
        //     if (runTotalSecond >= forbidRotationReleaseTime)
        //     {
        //         self.SetForbidRotation(false);
        //     }
        // }

        private static void UpdateForbidSkill(this Skill self)
        {
            if (self.IsForbidSkillSet == false)
            {
                return;
            }

            var forbidSkillReleaseTime = self.Config.forbidSkillReleaseTime;
            if (forbidSkillReleaseTime <= 0)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;
            if (runTotalSecond >= forbidSkillReleaseTime)
            {
                self.SetForbidSkill(false);
            }
        }

        private static void SetForbidMove(this Skill self, bool isForbid)
        {
            if (self.IsForbidMoveSet == isForbid)
            {
                return;
            }

            var numericComponent = self.Caster.GetComponent<NumericComponent>();
            if (numericComponent is { IsDisposed: false })
            {
                if (isForbid)
                {
                    numericComponent[NumericType.ForbidMove]++;
                }
                else
                {
                    numericComponent[NumericType.ForbidMove]--;
                }
            }

            self.IsForbidMoveSet = isForbid;
        }

        private static void SetForbidRotation(this Skill self, bool isForbid)
        {
            if (self.IsForbidRotationSet == isForbid)
            {
                return;
            }

            var numericComponent = self.Caster.GetComponent<NumericComponent>();
            if (numericComponent is { IsDisposed: false })
            {
                if (isForbid)
                {
                    numericComponent[NumericType.ForbidRotation]++;
                }
                else
                {
                    numericComponent[NumericType.ForbidRotation]--;
                }
            }

            self.IsForbidRotationSet = isForbid;
        }

        private static void SetForbidSkill(this Skill self, bool isForbid)
        {
            if (self.IsForbidSkillSet == isForbid)
            {
                return;
            }

            var numericComponent = self.Caster.GetComponent<NumericComponent>();
            if (numericComponent is { IsDisposed: false })
            {
                if (isForbid)
                {
                    numericComponent[NumericType.ForbidSkill]++;
                }
                else
                {
                    numericComponent[NumericType.ForbidSkill]--;
                }
            }

            self.IsForbidSkillSet = isForbid;
        }

        private static void UpdateChangeWeapon(this Skill self)
        {
            if (self.IsChangeWeaponApplied)
            {
                return;
            }

            var changeWeaponConfig = self.Config.changeWeaponConfig;
            if (changeWeaponConfig == null)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;
            if (runTotalSecond < changeWeaponConfig.startPoint)
            {
                return;
            }

            MrArmWeaponComponent mrArmWeaponComponent = self.Caster.GetComponent<MrArmWeaponComponent>();
            mrArmWeaponComponent?.ChangeWeapon((ArmWeaponMode)changeWeaponConfig.weapon);

            self.IsChangeWeaponApplied = true;
        }

        private static void UpdateNumbericModify(this Skill self)
        {
            var numericModifyConfigs = self.Config.numericModifyConfigs;
            if (self.NextNumericModifyIndex >= numericModifyConfigs.Length)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;
            for (; self.NextNumericModifyIndex < numericModifyConfigs.Length; ++self.NextNumericModifyIndex)
            {
                var numericModifyConfig = numericModifyConfigs[self.NextNumericModifyIndex];

                if (numericModifyConfig.startPoint > runTotalSecond)
                {
                    break;
                }

                self.ApplyNumericModify(numericModifyConfig);
            }
        }

        private static void ApplyNumericModify(this Skill self, SkillConfig.NumericModifyConfig numericModifyConfig)
        {
            var numericComponent = self.Caster.GetComponent<NumericComponent>();

            var valueKey = numericModifyConfig.modifyType switch
            {
                SkillConfig.NumericModifyType.HealthPoint => NumericType.Hp,
                SkillConfig.NumericModifyType.SkillPoint => NumericType.Sp,
                SkillConfig.NumericModifyType.SlidePoint => NumericType.SlidePoint,
                _ => NumericType.Unknown
            };

            var maxValueKey = numericModifyConfig.modifyType switch
            {
                SkillConfig.NumericModifyType.HealthPoint => NumericType.MaxHp,
                SkillConfig.NumericModifyType.SkillPoint => NumericType.MaxSp,
                SkillConfig.NumericModifyType.SlidePoint => NumericType.MaxSlidePoint,
                _ => NumericType.Unknown
            };

            if (valueKey == NumericType.Unknown || maxValueKey == NumericType.Unknown)
            {
                Log.Error($"不支持的数值类型: {numericModifyConfig.modifyType}");
                return;
            }

            var valueBaseKey = valueKey * 10 + 1;
            var oldValue = numericComponent[valueKey];
            var modifyValue = (long)(numericComponent[maxValueKey] * numericModifyConfig.modifyValue);
            var newValue = oldValue + modifyValue;
            var finalValue = math.clamp(newValue, 0, numericComponent[maxValueKey]);
            numericComponent[valueBaseKey] = finalValue;
        }

        private static void UpdateSelfBuffs(this Skill self)
        {
            var buffConfigs = self.Config.numericModifyBuffConfigs;
            if (self.NextSelfBuffIndex >= buffConfigs.Length)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;
            for (; self.NextAttackBoxIndex_Circle < buffConfigs.Length; ++self.NextAttackBoxIndex_Circle)
            {
                var buffConfig = buffConfigs[self.NextAttackBoxIndex_Circle];

                if (buffConfig.startPoint > runTotalSecond)
                {
                    break;
                }

                self.ApplySelfBuff(buffConfig);
            }
        }

        private static void ApplySelfBuff(this Skill self, SkillConfig.NumericModifyBuffConfig buffConfig)
        {
            var duration = buffConfig.duration;
            var modifyPercent = buffConfig.modifyValue;
            switch (buffConfig.buffType)
            {
                case SkillConfig.NumericModifyBuffType.MovementSpeed:
                {
                    var bc = self.Caster.GetComponent<BuffComponent2>();
                    bc.AddMovementSpeedModifyBuff(duration, modifyPercent);
                    break;
                }
                case SkillConfig.NumericModifyBuffType.Attack:
                {
                    var bc = self.Caster.GetComponent<BuffComponent2>();
                    bc.AddAttackModifyBuff(duration, modifyPercent);
                    break;
                }
                case SkillConfig.NumericModifyBuffType.DamageReduction:
                {
                    var bc = self.Caster.GetComponent<BuffComponent2>();
                    bc.AddDamageReductionBuff(duration, modifyPercent);
                    break;
                }
                default:
                {
                    Log.Error($"不支持的buff类型: {buffConfig.buffType}");
                    break;
                }
            }
        }

        private static void UpdatePoisionModify(this Skill self)
        {
            var congfigs = self.Config.positionModifyCongfigs;
            if (self.NextPositionModifyIndex >= congfigs.Length)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;
            for (; self.NextPositionModifyIndex < congfigs.Length; ++self.NextPositionModifyIndex)
            {
                var numericModifyConfig = congfigs[self.NextPositionModifyIndex];

                if (numericModifyConfig.startPoint > runTotalSecond)
                {
                    break;
                }

                self.ApplyPoisionModify(numericModifyConfig);
            }
        }

        private static void ApplyPoisionModify(this Skill self, SkillConfig.PositionModifyConfig numericModifyConfig)
        {
            var p1 = numericModifyConfig.position;
            var p2 = new float3(p1.x, p1.y, p1.z);
            self.SetToRelativePosition(p2);
        }

        private static void UpdateMotion(this Skill self)
        {
            var frameMotions = self.Config.motions;
            if (self.NextMotionIndex >= frameMotions.Length)
            {
                return;
            }

            var time = (TimeInfo.Instance.ServerNow() - self.StartTimestamp) / 1000f;
            int frame = (int)math.floor(time * ConstValue.FramesPerSecond);

            int start = self.NextMotionIndex;
            int end = math.clamp(frame, 0, frameMotions.Length - 1);

            for (int i = start; i <= end; i++)
            {
                self.MotionDelta.x += frameMotions[i].x;
                self.MotionDelta.z += frameMotions[i].y;
            }

            self.NextMotionIndex = end + 1; // 下一次从end+1开始

            //
            bool isLastFrame = end == frameMotions.Length - 1;

            // 优化: 如果移动量太小, 将motion累计到下一次, 避免频繁的移动, 缺点是不够精确平滑
            var threshold = isLastFrame? 0.001f : 0.01f;
            if (math.lengthsq(self.MotionDelta) < math.pow(threshold, 2))
            {
                if (isLastFrame)
                {
                    self.MotionDelta = float3.zero;
                }

                return;
            }

            self.SetToRelativePosition(self.MotionDelta);
            //
            self.MotionDelta = float3.zero;
        }

        private static void SetToRelativePosition(this Skill self, float3 relativePosition, bool publishEvent = true)
        {
            if (relativePosition.Equals(float3.zero))
            {
                return;
            }

            // 转换成世界坐标系
            float x = math.dot(relativePosition, math.normalize(self.Caster.Right));
            float y = 0; // math.dot(relativePosition, math.normalize(self.Caster.Up)); // 2d
            float z = math.dot(relativePosition, math.normalize(self.Caster.Forward));
            // 左手坐标系, 所以x要取反
            float3 deltaPos = new(-x, y, z);
            var pos = self.Caster.Position + deltaPos;
            pos.y = 0; // 2d
            //TODO: 墙体检测
            self.Caster.Position = pos;
            //
            M2C_SetPosition msg = new() { UnitId = self.Caster.Id, Position = self.Caster.Position, Rotation = self.Caster.Rotation };
            MrMapMessageHelper.Broadcast(self.Caster, msg);
        }

        private static void UpdateAttackBox(this Skill self)
        {
            self.UpdateAttackBox_Circle();
            self.UpdateAttackBox_Rectangle();
        }

        private static void UpdateAttackBox_Circle(this Skill self)
        {
            var attackBoxes = self.Config.circleAttackBoxConfigs;
            if (attackBoxes == null || attackBoxes.Length == 0)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;

            for (; self.NextAttackBoxIndex_Circle < attackBoxes.Length; ++self.NextAttackBoxIndex_Circle)
            {
                var attackBox = attackBoxes[self.NextAttackBoxIndex_Circle];

                if (attackBox.startPoint > runTotalSecond)
                {
                    break;
                }

                self.ApplyAttackBox(attackBox);
            }
        }

        private static void UpdateAttackBox_Rectangle(this Skill self)
        {
            var attackBoxes = self.Config.rectangleAttackBoxConfigs;
            if (attackBoxes == null || attackBoxes.Length == 0)
            {
                return;
            }

            var runTotalSecond = self.RunTotalTimeSecond;

            for (; self.NextAttackBoxIndex_Rectangle < attackBoxes.Length; ++self.NextAttackBoxIndex_Rectangle)
            {
                var attackBox = attackBoxes[self.NextAttackBoxIndex_Rectangle];

                if (attackBox.startPoint > runTotalSecond)
                {
                    break;
                }

                self.ApplyAttackBox(attackBox);
            }
        }

        private static void ApplyAttackBox(this Skill self, SkillConfig.AttackBoxBaseConfig attackBoxBaseConfig)
        {
            using var impactUnits = self.GetAttackBoxImpactUnits(attackBoxBaseConfig);
            if (impactUnits.Count == 0)
            {
                return;
            }

            if (attackBoxBaseConfig.damageMultiplier > 0)
            {
                foreach (Unit unit in impactUnits)
                {
                    var damageMultiplier = attackBoxBaseConfig.damageMultiplier;
                    BattleHelper.CalcAttack(self.Caster, unit, attackBoxBaseConfig.damageType, damageMultiplier);
                }
            }

            if (attackBoxBaseConfig.knockbackTarget)
            {
                foreach (Unit unit in impactUnits)
                {
                    self.ApplyKnockback(attackBoxBaseConfig, unit);
                }
            }

            if (attackBoxBaseConfig.slowTarget)
            {
                foreach (Unit unit in impactUnits)
                {
                    self.ApplySlowdown(attackBoxBaseConfig, unit);
                }
            }

            M2C_SkillImpact msg = new() { CasterId = self.Caster.Id, SkillId = self.Id, TargetIds = impactUnits.Select(u => u.Id).ToList() };
            MrMapMessageHelper.Broadcast(self.Caster, msg);
        }

        private static ListComponent<Unit> GetAttackBoxImpactUnits(this Skill self, SkillConfig.AttackBoxBaseConfig attackBox)
        {
            ListComponent<Unit> impactUnits = ListComponent<Unit>.Create();
            switch (attackBox)
            {
                case SkillConfig.CircleAttackBoxConfig circleAttackBox:
                {
                    var center = self.Caster.Position +
                            self.Caster.Forward * new float3(circleAttackBox.position.x, 0, circleAttackBox.position.y);
                    impactUnits.AddRange(GetUnits().Where(e => MrGeometry2DUtility.IsInCircle(center, e.Position, e.Radius, circleAttackBox.radius)));
                    break;
                }
                case SkillConfig.RectangleAttackBoxConfig rectangleAttackBox:
                {
                    var width = rectangleAttackBox.width;
                    var length = rectangleAttackBox.length;
                    impactUnits.AddRange(GetUnits()
                            .Where(unit =>
                                    // TODO 要加新的算法,这个不对
                                    MrGeometry2DUtility.IsInFrontRectangle(self.Caster.Position, self.Caster.Forward, unit.Position, unit.Radius,
                                        length,
                                        width)));
                    break;
                }
                default:
                    Log.Error($"不支持的攻击盒类型: {attackBox.GetType()}");
                    break;
            }

            return impactUnits;

            IEnumerable<Unit> GetUnits()
            {
                var enumerable = from aoiEntity in self.Caster.GetSeeUnits().Values
                        select aoiEntity.GetParent<Unit>()
                        into unit
                        let unitType = unit.UnitType()
                        where unitType is UnitType.Player or UnitType.Monster or UnitType.Treasure
                        where unit != self.Caster
                        select unit;
                return enumerable;
            }
        }

        private static void ApplyKnockback(this Skill self, SkillConfig.AttackBoxBaseConfig attackBoxBaseConfig, Unit unit)
        {
            var buffComponent = unit.GetComponent<BuffComponent2>();
            if (buffComponent == null)
            {
                return;
            }

            var priority = attackBoxBaseConfig.knockbackPriority;
            var direction = unit.Position - self.Caster.Position;
            direction.y = 0;
            direction = math.normalize(direction);
            var speed = attackBoxBaseConfig.knockbackSpeed;
            var duration = attackBoxBaseConfig.knockbackDuration;
            buffComponent.AddKnockbackBuff(priority, direction, speed, duration);
        }

        private static void ApplySlowdown(this Skill self, SkillConfig.AttackBoxBaseConfig attackBoxBaseConfig, Unit unit)
        {
            var buffComponent = unit.GetComponent<BuffComponent2>();
            if (buffComponent == null)
            {
                return;
            }

            var slowDownPercent = attackBoxBaseConfig.slowValue * -1;
            var duration = attackBoxBaseConfig.slowDuration;
            buffComponent.AddMovementSpeedModifyBuff(duration, slowDownPercent);
        }

        private static void DisposeIfSkillFinish(this Skill self)
        {
            var currentTime = TimeInfo.Instance.ServerNow() - self.StartTimestamp;
            if (currentTime < self.Config.length * 1000)
            {
                return;
            }

            M2C_SkillFinish msg = new() { CasterId = self.Caster.Id, SkillId = self.Id };
            MrMapMessageHelper.Broadcast(self.Caster, msg);
            self.Dispose();
        }
    }
}