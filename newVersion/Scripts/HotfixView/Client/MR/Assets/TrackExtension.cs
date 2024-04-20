using System;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;
using UnityEngine.Timeline;

namespace ET.Client
{
    using static CharacterAnimationDataClip;

    public static class VectorExtensions
    {
        public static SkillConfig.float2 ToFloat2(this Vector2 vector)
        {
            return new SkillConfig.float2(vector.x, vector.y);
        }

        public static SkillConfig.float3 ToFloat3(this Vector3 vector)
        {
            return new SkillConfig.float3(vector.x, vector.y, vector.z);
        }
    }

    public static class TrackExtension
    {
        public static Tuple<IEnumerable<SkillConfig.CircleAttackBoxConfig>, IEnumerable<SkillConfig.RectangleAttackBoxConfig>> Export(
        this AttackBoxTrack attackBoxTrack
        )
        {
            var rectagleAttackBoxConfigList = new List<SkillConfig.RectangleAttackBoxConfig>();
            var circleAttackBoxConfigList = new List<SkillConfig.CircleAttackBoxConfig>();
            foreach (var clip in attackBoxTrack.GetClips())
            {
                if (clip.asset is CircleAttackBoxPlayableAsset ca)
                {
                    var circleAttackBoxConfig = new SkillConfig.CircleAttackBoxConfig();

                    ExportAttackBoxConfigBase(circleAttackBoxConfig, ca, clip);
                    circleAttackBoxConfig.radius = ca.radius;

                    circleAttackBoxConfigList.Add(circleAttackBoxConfig);
                }
                else if (clip.asset is RectangleAttackBoxPlayableAsset ra)
                {
                    var rectangleAttackBoxConfig = new SkillConfig.RectangleAttackBoxConfig();

                    ExportAttackBoxConfigBase(rectangleAttackBoxConfig, ra, clip);

                    rectangleAttackBoxConfig.width = ra.width;
                    rectangleAttackBoxConfig.length = ra.length;

                    rectagleAttackBoxConfigList.Add(rectangleAttackBoxConfig);
                }
            }

            return new Tuple<IEnumerable<SkillConfig.CircleAttackBoxConfig>, IEnumerable<SkillConfig.RectangleAttackBoxConfig>>(
                circleAttackBoxConfigList, rectagleAttackBoxConfigList);
        }

        private static void ExportAttackBoxConfigBase(SkillConfig.AttackBoxBaseConfig attackBoxConfig, AAttackBoxPlayableAsset asset,
        TimelineClip clip)
        {
            attackBoxConfig.startPoint = (float)clip.start;
            attackBoxConfig.position = asset.position.ToFloat2();

            attackBoxConfig.damageType = asset.DamageType;
            attackBoxConfig.damageMultiplier = asset.DamageMultiplier;

            attackBoxConfig.impactEffectId = asset.ImpactEffectId;

            attackBoxConfig.knockbackTarget = asset.knockbackTarget;
            attackBoxConfig.knockbackPriority = asset.knockbackPriority;
            attackBoxConfig.knockbackSpeed = asset.knockbackSpeed;
            attackBoxConfig.knockbackDuration = asset.knockbackDuration;

            attackBoxConfig.slowTarget = asset.slowTarget;
            attackBoxConfig.slowDuration = asset.slowDuration;
            attackBoxConfig.slowValue = asset.slowValue;
        }

        public static SkillConfig.BulletConfig[] Export(this BulletTrack bulletTrack)
        {
            var result = new List<SkillConfig.BulletConfig>();
            foreach (var clip in bulletTrack.GetClips())
            {
                var asset = clip.asset as BulletPlayableAsset;
                var p = new SkillConfig.BulletConfig();
                p.startPoint = (float)clip.start;
                p.position = asset.position.ToFloat3();
                p.rotation = asset.rotation.ToFloat3();
                p.atkLv = asset.atkLv;
                p.damageType = asset.damageType;
                p.sp = asset.sp;
                p.hp = asset.hp;
                p.faceTarget = asset.faceTarget;
                p.speed = (float)asset.speed;
                p.trackDeg = (float)asset.trackDeg;
                p.trackTime = (float)asset.trackTime;
                result.Add(p);
            }

            return result.ToArray();
        }

        public static IEnumerable<SkillConfig.ComboSkillPoint> Export(this ComboSkillTrack comboSkillTrack)
        {
            var result = new List<SkillConfig.ComboSkillPoint>();
            foreach (var clip in comboSkillTrack.GetClips())
            {
                var asset = clip.asset as ComboSkillPlayableAsset;
                var p = new SkillConfig.ComboSkillPoint();
                p.startPoint = (float)clip.start;
                p.endPoint = (float)clip.end;
                p.skill = asset.Skill;
                p.release = asset.ReleaseBtn;
                result.Add(p);
            }

            return result;
        }

        public static SkillConfig.SimpleConfig[] Export(this DefenseTrack defenseTrack)
        {
            var result = new List<SkillConfig.SimpleConfig>();
            foreach (var clip in defenseTrack.GetClips())
            {
                var p = new SkillConfig.SimpleConfig();
                p.startPoint = (float)clip.start;
                p.endPoint = (float)clip.end;
                result.Add(p);
            }

            return result.ToArray();
        }

        public static IEnumerable<EffectConfig> Export(this EffectTrack effectTrack)
        {
            var result = new List<EffectConfig>();
            foreach (var clip in effectTrack.GetClips())
            {
                var asset = clip.asset as EffectPlayableAsset;
                var p = new EffectConfig();
                p.startPoint = clip.start;
                p.endPoint = clip.end;
                p.target = asset.target;
                p.follow = asset.follow;
                p.speed = asset.speed;
                p.position = asset.position;
                p.rotation = asset.rotation;
                p.scale = asset.scale;
                result.Add(p);
            }

            return result;
        }

        public static IEnumerable<AudioConfig> Export(this AudioTrack t)
        {
            var result = new List<AudioConfig>();
            foreach (var clip in t.GetClips())
            {
                var audioPlayableAsset = clip.asset as AudioPlayableAsset;
                var p = new AudioConfig();
                p.startPoint = clip.start;
                p.endPoint = clip.end;
                p.audioClip = audioPlayableAsset.clip;
                p.volume = 1f; //TODO
                result.Add(p);
            }

            return result;
        }

        public static SkillConfig.EndureConfig[] Export(this EndureTrack equipTrack)
        {
            var result = new List<SkillConfig.EndureConfig>();
            foreach (var clip in equipTrack.GetClips())
            {
                var asset = clip.asset as EndurePlayableAsset;
                var p = new SkillConfig.EndureConfig();
                p.startPoint = (float)clip.start;
                p.endPoint = (float)clip.end;
                p.defLV = asset.defLv;
                result.Add(p);
            }

            return result.ToArray();
        }

        public static SkillConfig.ChangeWeaponConfig Export(this EquipTrack equipTrack)
        {
            foreach (var clip in equipTrack.GetClips())
            {
                var asset = clip.asset as EquipPlayableAsset;
                var skillConfig = new SkillConfig.ChangeWeaponConfig();
                skillConfig.startPoint = (float)clip.start;
                skillConfig.weapon = (int)asset.Weapon;
                return skillConfig;
            }

            return null;
        }

        public static SkillConfig.FaceConfig[] Export(this FaceTrack faceTrack)
        {
            var result = new List<SkillConfig.FaceConfig>();
            foreach (var clip in faceTrack.GetClips())
            {
                var asset = clip.asset as FacePlayableAsset;
                var config = new SkillConfig.FaceConfig();
                config.point = (float)clip.start;
                config.lockTarget = asset.lockTarget;
                config.maxAngle = asset.maxAngle;
                result.Add(config);
            }

            return result.ToArray();
        }

        public static IEnumerable<ImpulseConfig> Export(this ImpulseTrack impulseTrack)
        {
            var result = new List<ImpulseConfig>();
            foreach (var marker in impulseTrack.GetMarkers())
            {
                var impulseMarker = marker as ImpulseMarker;
                var config = new ImpulseConfig();
                config.startPoint = impulseMarker.time;
                config.onlySelf = impulseMarker.onlySelf;
                config.power = impulseMarker.power;
                result.Add(config);
            }

            return result.ToArray();
        }

        public static float Export(this LimitDodgeTrack limitDodgeTrack)
        {
            foreach (var clip in limitDodgeTrack.GetClips())
            {
                return (float)clip.start;
            }

            return 0;
        }

        public static float Export(this LimitMoveTrack limitMoveTrack)
        {
            foreach (var clip in limitMoveTrack.GetClips())
            {
                return (float)clip.start;
            }

            return 0;
        }

        public static float Export(this LimitSkillTrack limitSkillTrack)
        {
            foreach (var clip in limitSkillTrack.GetClips())
            {
                return (float)clip.start;
            }

            return 0;
        }

        public static SkillConfig.SimpleConfig[] Export(this LookTargetTrack lookTargetTrack)
        {
            var result = new List<SkillConfig.SimpleConfig>();
            foreach (var clip in lookTargetTrack.GetClips())
            {
                var p = new SkillConfig.SimpleConfig();
                p.startPoint = (float)clip.start;
                p.endPoint = (float)clip.end;
                result.Add(p);
            }

            return result.ToArray();
        }

        public static void Export(this MoveTrack moveTrack, int fps, ref SkillConfig.float2[] data)
        {
            foreach (var clip in moveTrack.GetClips())
            {
                var asset = clip.asset as MovePlayableAsset;
                var start = (int)(clip.start * fps);
                var end = (int)(clip.end * fps);
                var len = end - start;
                var step = asset.Offset / len;
                for (int i = start; i < end; i++)
                {
                    data[i] = new SkillConfig.float2(step.x, step.z);
                }
            }
        }

        public static SkillConfig.RunModeConfig[] Export(this RunModeTrack runModeTrack)
        {
            var result = new List<SkillConfig.RunModeConfig>();
            foreach (var clip in runModeTrack.GetClips())
            {
                var p = new SkillConfig.RunModeConfig();
                p.startPoint = (float)clip.start;
                p.endPoint = (float)clip.end;
                p.mode = (clip.asset as RunModePlayableAsset).mode;
                result.Add(p);
            }

            return result.ToArray();
        }

        public static IEnumerable<SkillConfig.ConsumptionConfig> Export(this ConsumptionTrack sPTrack)
        {
            var result = new List<SkillConfig.ConsumptionConfig>();
            foreach (var clip in sPTrack.GetClips())
            {
                var asset = clip.asset as ConsumptionPlayableAsset;
                var c = new SkillConfig.ConsumptionConfig();
                c.startPoint = (float)clip.start;
                c.type = asset.consumptionType;
                c.value1 = asset.value1;
                c.value2 = asset.value2;
                result.Add(c);
            }

            return result;
        }

        public static IEnumerable<SkillConfig.NumericModifyBuffConfig> Export(this BuffTrack buffTrack)
        {
            var result = new List<SkillConfig.NumericModifyBuffConfig>();
            foreach (IMarker marker in buffTrack.GetMarkers())
            {
                var buffMarker = marker as AddNumericModifyBuffMarker;
                var buffConfig = new SkillConfig.NumericModifyBuffConfig();
                buffConfig.startPoint = (float)marker.time;
                buffConfig.duration = buffMarker.buffDuration;
                buffConfig.buffType = buffMarker.buffType;
                buffConfig.modifyValue = buffMarker.modifyPercent;

                result.Add(buffConfig);
            }

            return result;
        }

        public static IEnumerable<SkillConfig.NumericModifyConfig> Export(this NumericModifyTrack track)
        {
            var result = new List<SkillConfig.NumericModifyConfig>();
            foreach (IMarker marker in track.GetMarkers())
            {
                var buffMarker = marker as NumericModifyMarker;
                var x = new SkillConfig.NumericModifyConfig();
                x.startPoint = (float)marker.time;
                x.modifyType = buffMarker.numericModifyType;
                x.modifyValue = buffMarker.modifyPercent;

                result.Add(x);
            }

            return result;
        }

        public static IEnumerable<SkillConfig.PositionModifyConfig> Export(this PositionModifyTrack track)
        {
            var result = new List<SkillConfig.PositionModifyConfig>();
            foreach (IMarker marker in track.GetMarkers())
            {
                var m = marker as PositionModifyMarker;
                var x = new SkillConfig.PositionModifyConfig();
                x.startPoint = (float)marker.time;
                x.position = new SkillConfig.float3(m.relativePosition.x, m.relativePosition.y, m.relativePosition.z);

                result.Add(x);
            }

            return result;
        }
    }
}