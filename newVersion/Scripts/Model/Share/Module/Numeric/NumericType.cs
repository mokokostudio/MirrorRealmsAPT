namespace ET
{
    // 这个可弄个配置表生成
    public static class NumericType
    {
        public const int Unknown = 0;
        
        public const int Max = 10000;

        public const int Speed = 1000;
        public const int SpeedBase = Speed * 10 + 1;
        public const int SpeedAdd = Speed * 10 + 2;
        public const int SpeedPct = Speed * 10 + 3;
        public const int SpeedFinalAdd = Speed * 10 + 4;
        public const int SpeedFinalPct = Speed * 10 + 5;

        public const int Hp = 1001;
        public const int HpBase = Hp * 10 + 1;

        public const int MaxHp = 1002;
        public const int MaxHpBase = MaxHp * 10 + 1;
        public const int MaxHpAdd = MaxHp * 10 + 2;
        public const int MaxHpPct = MaxHp * 10 + 3;
        public const int MaxHpFinalAdd = MaxHp * 10 + 4;
        public const int MaxHpFinalPct = MaxHp * 10 + 5;

        public const int AOI = 1003;
        public const int AOIBase = AOI * 10 + 1;
        public const int AOIAdd = AOI * 10 + 2;
        public const int AOIPct = AOI * 10 + 3;
        public const int AOIFinalAdd = AOI * 10 + 4;
        public const int AOIFinalPct = AOI * 10 + 5;

        public const int ForbidMove = 1004;
        public const int ForbidSkill = 1005;
        public const int ForbidRotation = 1006;

        public const int Attack = 2001;
        public const int AttackBase = Attack * 10 + 1;
        public const int AttackAdd = Attack * 10 + 2;
        public const int AttackPct = Attack * 10 + 3;
        public const int AttackFinalAdd = Attack * 10 + 4;
        public const int AttackFinalPct = Attack * 10 + 5;

        public const int DamageReduction = 2002;

        // skill point
        public const int Sp = 3001;
        public const int SpBase = Sp * 10 + 1;

        public const int MaxSp = 3002;
        public const int MaxSpBase = MaxSp * 10 + 1;
        public const int MaxSpAdd = MaxSp * 10 + 2;
        public const int MaxSpPct = MaxSp * 10 + 3;
        public const int MaxSpFinalAdd = MaxSp * 10 + 4;
        public const int MaxSpFinalPct = MaxSp * 10 + 5;

        public const int SlidePoint = 3003;
        public const int SlidePointBase = SlidePoint * 10 + 1;

        public const int MaxSlidePoint = 3004;
        public const int MaxSlidePointBase = MaxSlidePoint * 10 + 1;
        public const int MaxSlidePointAdd = MaxSlidePoint * 10 + 2;
        public const int MaxSlidePointPct = MaxSlidePoint * 10 + 3;
        public const int MaxSlidePointFinalAdd = MaxSlidePoint * 10 + 4;
        public const int MaxSlidePointFinalPct = MaxSlidePoint * 10 + 5;
    }
}