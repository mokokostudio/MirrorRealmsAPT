namespace ET.Client
{
    public struct MrAppStartInitFinish
    {
    
    }
    public struct MrAfterUnitCreate
    {
        public Unit Unit;
    }
    
    public struct MrSceneChangeStart
    {
    }

    public struct MrSceneChangeFinish
    {
    }

    public struct MrAfterCreateClientScene
    {
    }

    public struct MrAfterCreateCurrentScene
    {
    }

    public struct MrLoginFinish
    {
    }

    public struct MrBattleEnd
    {
        public bool IsVictory;
    }

    /// <summary>
    /// 进入大厅场景开始
    /// </summary>
    public struct MrEnterLobbySceneStart
    {

    }

    /// <summary>
    /// 进入大厅场景完成
    /// </summary>
    public struct MrEnterLobbySceneFinish
    {

    }

    public struct GameReadyStart
    {
        public long serverFrameTime;
    }
    public struct GameBattleStart
    {
        public long serverFrameTime;
    }
    public struct GameBattleFinish
    {

    }

    public struct UIWeaponChange
    {
        public int index;
        public ulong weaponId;
        public string weaponName1;
        public string weaponName2;
    }
    
    public struct MrRoomPhaseInfoChange
    {
        public MrRoomPhase Phase;
        public long StartTime;
        public long RemainingTime;
    }
}