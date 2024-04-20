namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        public const int ERR_CastComponentNotFound = 110000;

        public const int ERR_Cast_ArgsError = 200101;
        public const int ERR_Cast_CasterIsNull = 200102;
        public const int ERR_Cast_TargetIsNull = 200103;

        /// <summary>
        /// 复活失败，目标存活
        /// </summary>
        public const int ERR_Relive_Alive = 200104;

        public const int ERR_Caster_NotAlive = 200105;

        public const int ERR_Cast_UnitIsNull = 200107;

        public const int ERR_Cast_NumComIsNull = 200108;

        public const int ERR_Cast_ForbidSkill = 200109;

        public const int ERR_Cast_SkillCDDown = 200110;

        public const int ERR_Pick_UnitIsNull = 200201;

        public const int ERR_Pick_UnitNotPickable = 200202;

        public const int ERR_UseItem_InventoryIsNull = 200301;
        public const int ERR_UseItem_IdError = 200302;
        public const int ERR_UseItem_CountError = 200302;
        public const int ERR_UseItem_NotEnough = 200303;
        public const int ERR_UseItem_TypeError = 200304;
        
        public const int ERR_RemoveItem_InventoryIsNull = 200401;
        public const int ERR_RemoveItem_CountError = 200402;
        public const int ERR_RemoveItem_NotEnough = 200403;

        public const int ERR_Skill_Casting = 200501;
        public const int ERR_Skill_Coolingdown = 200502;
        public const int ERR_Skill_ConsumptionNotEnough_HealPoint = 200503;
        public const int ERR_Skill_ConsumptionNotEnough_SkillPoint = 200504;
        public const int ERR_Skill_ConsumptionNotEnough_SlidePoint = 200505;
        public const int ERR_Skill_NameError = 200506;
    }
}