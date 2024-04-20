using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof (Scene))]
    public class MrRoom: Entity, IAwake, IDestroy
    {
        public string Name = "MR Fight!";
        public long StartTime;

        // 玩家id列表
        public List<long> PlayerIds;

        // public long Room_BattleStartTimer;
        // public long Room_SpwanMonster1Timer;
        // public long Room_SpwanMonster2Timer;
        // public long Room_SpwanMonster3Timer;
        // public long Room_SpwanEscapDoorTimer;
        // public long Room_TimeoutTimer;

        public MrRoomPhase Phase;
        public long PhaseStartTime;
        public long PhaseRemainingTime;// 本阶段剩余时间, 单位:秒
        public long PhaseUpdateTimerId;
    }
}