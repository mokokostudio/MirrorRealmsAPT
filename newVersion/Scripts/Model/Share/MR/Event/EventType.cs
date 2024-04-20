using Unity.Mathematics;

namespace ET
{
    namespace EventType
    {
        public struct BuffTimeOut
        {
            public Unit Unit;
            public long BuffId;
        }

        public struct CastStart
        {
            public long CasterId;
            public long CastConfigId;
            public long CastId;
        }

        public struct CastImpact
        {
            public long CasterId;
            public long CastId;
            public long TargetId;
        }

        public struct CastFinish
        {
            public long CasterId;
            public long CastId;
        }

        public struct CastBreak
        {
            public long CasterId;
            public long CastId;
        }

        public struct BuffAdd
        {
            public Unit Unit;
            public long BuffId;
            public int BuffConfigId;
        }

        public struct BuffRemove
        {
            public Unit Unit;
            public long BuffId;
        }

        public struct BuffTick
        {
            public Unit Unit;
            public long BuffId;
        }

        public struct BuffUpdate
        {
            public Unit Unit;
            public long BuffId;
            public int BuffConfigId;
        }

        public struct UnitWeaponChanged
        {
            public Unit Unit;
            public ArmWeaponMode ArmWeaponMode;
        }

        public struct SkillStart
        {
            public long CasterId;
            public long SkillId;
            public string SkillName;
        }

        public struct SkillImpact
        {
            public long CasterId;
            public long SkillId;
            public long[] TargetIds;
        }

        public struct SkillBreak
        {
            public long CasterId;
            public long SkillId;
        }

        public struct SkillFinish
        {
            public long CasterId;
            public long SkillId;
        }

        public struct InventoryInited
        {
        }

        public struct IventoryCountChanged
        {
            public int ItemConfigId;
            public int OldCount;
            public int NewCount;
        }
        
        public struct NumericChanged
        {
            public long UnitId;
            public int NumericType;
            public float OldValue;
            public float NewValue;
        }

        public struct TakeDamage
        {
            public long AttackerId;
            public long TargetId;
            public SkillConfig.DamageType DamageType;
            public long Damage;
        }

        public struct DropCreated
        {
            public long UnitId;
            public float3 SpawnPosition;
            public float3 TargetPosition;
        }
    }
}