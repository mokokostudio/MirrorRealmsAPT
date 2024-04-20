namespace ET.Server
{
    public static class BehaviorType
    {
        /// <summary>
        /// 造成伤害
        ///
        /// Params:
        ///   - 0: damage
        /// </summary>
        public const int Damage = 1;

        /// <summary>
        /// 改变目标数值, 如果是Buff, 移除时会还原数值
        ///
        /// Params:
        ///   - 0: numbericType
        ///   - 1: numbericValue
        /// </summary>
        public const int NumbericChange = 2;

        /// <summary>
        ///  产生子弹
        /// 
        /// Params:
        ///   - 0: unitId
        ///   - 1: projectileId
        /// </summary>
        public const int SpawnProjectile = 3;

        /// <summary>
        /// 向目标移动指定距离
        /// 无目标时则向前移动
        ///
        /// Params:
        ///   - 0: movement speed
        /// 
        /// </summary>
        public const int MoveToTarget = 4;

        /// <summary>
        /// 释放新的Cast
        ///
        /// Params:
        ///   - 0: cast config id
        /// </summary>
        public const int CreateCast = 5;

        /// <summary>
        /// 把目标往中心吸引
        ///
        /// Params:
        ///   - 0: speed
        ///   - 1: range
        /// </summary>
        public const int Attract = 6;

        /// <summary>
        /// 击退目标一段距离
        ///
        /// Params:
        ///   - 0: range
        ///   - 1: distance
        ///   - 2: buffId
        /// </summary>
        public const int ApplyKnockbackToTarget = 7;

        /// <summary>
        /// 切换武器
        ///
        /// Params:
        ///   - 0: ArmWeaponMode
        /// </summary>
        public const int ChangeWeapon = 8;
    }
}