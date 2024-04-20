using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET.Server
{
    [ChildOf(typeof (SkillComponent))]
    public sealed class Skill: Entity, IAwake<Unit, string>, IUpdate, IDestroy
    {
        /// <summary>
        /// 配置
        /// </summary>
        public SkillConfig Config;

        /// <summary>
        /// 技能释放者
        /// </summary>
        [BsonIgnore]
        public Unit Caster { get; set; }

        /// <summary>
        /// 开始释放时的时间戳
        /// </summary>
        public long StartTimestamp;

        /// <summary>
        /// 上一次更新的时间戳
        /// 可以用来计算delata
        /// </summary>
        public long PreviousUpdateTimestamp;

        public long DeltaTime => TimeInfo.Instance.ServerNow() - this.PreviousUpdateTimestamp;

        /// <summary>
        /// 
        /// </summary>
        public long RunTotalTimeMs => TimeInfo.Instance.ServerNow() - this.StartTimestamp;

        public float RunTotalTimeSecond => this.RunTotalTimeMs * 0.001f;

        /// <summary>
        ///  指向下一个未应用的 position index
        /// </summary>
        public int NextPositionModifyIndex;
        
        /// <summary>
        /// 指向下一个未应用的 numeric modify index
        /// </summary>
        public int NextNumericModifyIndex;
        
        /// <summary>
        /// 指向下一个未应用的 self buff index
        /// </summary>
        public int NextSelfBuffIndex;

        /// <summary>
        /// 指向下一个未应用的 motion index
        /// </summary>
        public int NextMotionIndex;

        /// <summary>
        /// 累计的motion量
        /// </summary>
        public float3 MotionDelta;

        /// <summary>
        /// 指向下一个未应用的 attack box index
        /// </summary>
        public int NextAttackBoxIndex_Circle;
        public int NextAttackBoxIndex_Rectangle;
        
        public bool IsChangeWeaponApplied;

        public bool IsForbidSkillSet;
        public bool IsForbidMoveSet;
        public bool IsForbidRotationSet;
    }
}