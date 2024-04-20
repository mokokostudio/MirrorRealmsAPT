namespace ET
{
    [UniqueId(100, 20000)]
    public static class TimerInvokeType
    {
        // 框架层100-200，逻辑层的timer type从200起
        public const int WaitTimer = 100;
        public const int SessionIdleChecker = 101;
        public const int MessageLocationSenderChecker = 102;
        public const int MessageSenderChecker = 103;

        // 框架层100-200，逻辑层的timer type 200-300
        public const int SessionAcceptTimeout = 201;
        public const int AITimer = 202;
        public const int MoveTimer = 203;

        public const int BuffExpireTimer = 211;
        public const int BuffTickTimer = 212;

        public const int ProjectileTickTimerInterval = 221;
        public const int ProjectileTickTimer100Ms = 222;
        public const int ProjectileTickTimer1000Ms = 223;
        public const int ProjectileTotalTimer = 224;

        public const int SpwanMonsterTimer = 231;
        public const int MosnterDeadTimer = 232;

        public const int SpwanTreasureTimer = 241;
        public const int AutoPickComponent_PickIntervalTimer = 251;

        public const int AttackModifyBuffTimer = 261;
        public const int MovementSpeedModifyBuffTimer = 262;
        public const int DamageReductionModifyBuffTimer = 263;

        public const int TrapTimer = 271;

        public const int SlidePointRecoveryTimer = 291;

        // Room 301起
        public const int RoomUpdate = 301;
        public const int GameRoomReadyEnd = 302;
        public const int GameRoomEnd = 303;

        public const int GameRoomMatchTimeOut = 304;

        //
        public const int Room_PhaseTimer = 305;
        public const int Room_BattleStartTimer = 401;
        public const int Room_SpwanMonster1Timer = 402;
        public const int Room_SpwanMonster2Timer = 403;
        public const int Room_SpwanMonster3Timer = 404; // boss
        public const int Room_SpawnEscapDoorTimer = 405; // 逃离门
        public const int Room_TimeoutTimer = 406; // 

        // view层的timer type从10000起
        public const int ShowFloatingText_DestroyTimer = 10000;
        public const int ShowGetItemTip_DestroyTimer = 10001;

        // UI 11000
        public const int UIBattle_CountDown = 11000;
        public const int UIMain_Match = 11001;
    }
}