using System;
using System.Collections.Generic;
using DotRecast.Core;
using ET.Server;
using Unity.Mathematics;

namespace ET
{
    [Invoke(TimerInvokeType.Room_PhaseTimer)]
    public class Room_PhaseUpdateTimer__TimerHandler: ATimer<MrRoom>
    {
        protected override void Run(MrRoom mrRoom)
        {
            mrRoom.OnPhaseUpdateTimer();
        }
    }
    //
    // [Invoke(TimerInvokeType.Room_BattleStartTimer)]
    // public class Room_BattleStartTimer__TimerHandler: ATimer<MrRoom>
    // {
    //     protected override void Run(MrRoom mrRoom)
    //     {
    //         Log.Info($"战斗开始");
    //     }
    // }
    //
    // [Invoke(TimerInvokeType.Room_SpwanMonster1Timer)]
    // public class Room_SpwanMonster1Timer__TimerHandler: ATimer<MrRoom>
    // {
    //     protected override void Run(MrRoom mrRoom)
    //     {
    //         Log.Info($"刷新第一波野怪");
    //         MrSpawnMonsterHelper.Spawn(mrRoom.Scene(), 2, 1001, 6);
    //
    //         TrapConfigCategory.Instance.GetAll().Keys.ForEach(trapId => UnitFactory.CreateTrap(mrRoom.Scene(), trapId));
    //     }
    // }
    //
    // [Invoke(TimerInvokeType.Room_SpwanMonster2Timer)]
    // public class Room_SpwanMonster2Timer__TimerHandler: ATimer<MrRoom>
    // {
    //     protected override void Run(MrRoom mrRoom)
    //     {
    //         Log.Info($"刷新第二波野怪");
    //         MrSpawnMonsterHelper.Spawn(mrRoom.Scene(), 3, 1001, 6);
    //     }
    // }
    //
    // [Invoke(TimerInvokeType.Room_SpwanMonster3Timer)]
    // public class Room_SpwanMonster3Timer__TimerHandler: ATimer<MrRoom>
    // {
    //     protected override void Run(MrRoom mrRoom)
    //     {
    //         Log.Info($"刷新第三波野怪");
    //         MrSpawnMonsterHelper.Spawn(mrRoom.Scene(), 4, 3001, 3);
    //         // 临时测试, 创建一个宝箱在场景中
    //         UnitFactory.CreateTreasure(mrRoom.Scene(), 1, new float3(0, 0, 0), quaternion.identity);
    //     }
    // }
    //
    // [Invoke(TimerInvokeType.Room_SpawnEscapDoorTimer)]
    // public class Room_SpawnEscapDoorTimer__TimerHandler: ATimer<MrRoom>
    // {
    //     protected override void Run(MrRoom mrRoom)
    //     {
    //         Log.Info($"刷新逃离门");
    //     }
    // }
    //
    // [Invoke(TimerInvokeType.Room_TimeoutTimer)]
    // public class Room_TimeoutTimer__TimerHandler: ATimer<MrRoom>
    // {
    //     protected override void Run(MrRoom mrRoom)
    //     {
    //         Log.Info($"游戏结束");
    //         //room.Root().GetComponent<UnitComponent>();
    //     }
    // }

    [FriendOf(typeof (MrRoom))]
    [EntitySystemOf(typeof (MrRoom))]
    public static partial class MrRoomSystem
    {
        [EntitySystem]
        private static void Awake(this MrRoom self)
        {
            // self.Room_BattleStartTimer = 0;
            // self.Room_SpwanMonster1Timer = 0;
            // self.Room_SpwanMonster2Timer = 0;
            // self.Room_SpwanMonster3Timer = 0;
            // self.Room_SpwanEscapDoorTimer = 0;
            // self.Room_TimeoutTimer = 0;

            //self.PlayerIds = new List<long>(MrGameConstValue.MatchCount);
            self.PlayerIds = new List<long>(Options.Instance.MatchCount);

            self.Phase = MrRoomPhase.Invalid;
            self.PhaseStartTime = 0;
            self.PhaseRemainingTime = 0;
            self.PhaseUpdateTimerId = 0;
        }

        [EntitySystem]
        private static void Destroy(this MrRoom self)
        {
            TimerComponent timer = self.Root().GetComponent<TimerComponent>();
            // timer.Remove(ref self.Room_BattleStartTimer);
            // timer.Remove(ref self.Room_SpwanMonster1Timer);
            // timer.Remove(ref self.Room_SpwanMonster2Timer);
            // timer.Remove(ref self.Room_SpwanMonster3Timer);
            // timer.Remove(ref self.Room_SpwanEscapDoorTimer);
            // timer.Remove(ref self.Room_TimeoutTimer);
            timer.Remove(ref self.PhaseUpdateTimerId);
            self.Phase = MrRoomPhase.Invalid;
            self.PhaseStartTime = 0;
            self.PhaseRemainingTime = 0;

            self.PlayerIds.Clear();
        }

        private static void BroadcastMsg(this MrRoom self, IMessage message)
        {
            (message as MessageObject).IsFromPool = false;
            MessageLocationSenderComponent messageLocationSenderComponent = self.Root().GetComponent<MessageLocationSenderComponent>();
            foreach (long id in self.PlayerIds)
            {
                messageLocationSenderComponent.Get(LocationType.GateSession).Send(id, message);
            }
        }

        public static void Init(this MrRoom self, List<long> playerIds, long startTime)
        {
            self.StartTime = startTime;

            for (int i = 0; i < playerIds.Count; ++i)
            {
                self.PlayerIds.Add(playerIds[i]);
            }

            TimerComponent timer = self.Root().GetComponent<TimerComponent>();
            self.PhaseUpdateTimerId = timer.NewRepeatedTimer(1000, TimerInvokeType.Room_PhaseTimer, self);
            self.ChangePhase(MrRoomPhase.Ready);
            // 
            // self.Room_BattleStartTimer =
            //         timer.NewOnceTimer(startTime + MrGameConstValue.Room_ReadyTime * 1000, TimerInvokeType.Room_BattleStartTimer, self);
            // self.Room_SpwanMonster1Timer =
            //         timer.NewOnceTimer(startTime + MrGameConstValue.Room_SpwanMonster1 * 1000, TimerInvokeType.Room_SpwanMonster1Timer, self);
            // self.Room_SpwanMonster2Timer =
            //         timer.NewOnceTimer(startTime + MrGameConstValue.Room_SpwanMonster2 * 1000, TimerInvokeType.Room_SpwanMonster2Timer, self);
            // self.Room_SpwanMonster3Timer =
            //         timer.NewOnceTimer(startTime + MrGameConstValue.Room_SpwanMonster3 * 1000, TimerInvokeType.Room_SpwanMonster3Timer, self);
            // self.Room_SpwanEscapDoorTimer =
            //         timer.NewOnceTimer(startTime + MrGameConstValue.Room_SpwanEscapDoor * 1000, TimerInvokeType.Room_SpawnEscapDoorTimer, self);
            // self.Room_TimeoutTimer = timer.NewOnceTimer(startTime + MrGameConstValue.Room_Timeout * 1000, TimerInvokeType.Room_TimeoutTimer, self);
        }

        public static void OnPhaseUpdateTimer(this MrRoom self)
        {
            self.PhaseRemainingTime -= 1;
            if (self.PhaseRemainingTime <= 0)
            {
                self.ChangePhase(self.Phase + 1);
            }

            var msg = MrRoom2C_NotifyPhaseInfo.Create();
            msg.Phase = (int)self.Phase;
            msg.StartTime = self.PhaseStartTime;
            msg.RemainingTime = self.PhaseRemainingTime;
            self.BroadcastMsg(msg);
        }

        private static void ChangePhase(this MrRoom self, MrRoomPhase phase)
        {
            self.Phase = phase;
            self.PhaseStartTime = TimeInfo.Instance.ServerNow();
            self.PhaseRemainingTime = self.Phase switch
            {
                MrRoomPhase.Ready => 10, //60,
                MrRoomPhase.Phase_1 => 10, //120,
                MrRoomPhase.Phase_2 => 10, //120,
                MrRoomPhase.Phase_3 => 10, //120,
                MrRoomPhase.Escap => 10, //120,
                MrRoomPhase.End => 0,
                _ => 0
            };

            switch (self.Phase)
            {
                case MrRoomPhase.Invalid:
                    break;
                case MrRoomPhase.Ready:
                    break;
                case MrRoomPhase.Phase_1:
                    Log.Info($"刷新第一波野怪");
                    MrSpawnMonsterHelper.Spawn(self.Scene(), 2, 1001, 6);
                    TrapConfigCategory.Instance.GetAll().Keys.ForEach(trapId => UnitFactory.CreateTrap(self.Scene(), trapId));
                    break;
                case MrRoomPhase.Phase_2:
                    Log.Info($"刷新第二波野怪");
                    MrSpawnMonsterHelper.Spawn(self.Scene(), 3, 1001, 6);
                    break;
                case MrRoomPhase.Phase_3:
                    Log.Info($"刷新第三波野怪");
                    MrSpawnMonsterHelper.Spawn(self.Scene(), 4, 3001, 3);
                    // 临时测试, 创建一个宝箱在场景中
                    UnitFactory.CreateTreasure(self.Scene(), 1, new float3(0, 0, 0), quaternion.identity);
                    break;
                case MrRoomPhase.Escap:
                    Log.Info($"刷新逃离门");
                    break;
                case MrRoomPhase.End:
                {
                    Log.Info($"游戏结束");
                    TimerComponent timer = self.Root().GetComponent<TimerComponent>();
                    timer.Remove(ref self.PhaseUpdateTimerId);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void GameReadyEnd(this MrRoom self)
        {
            Log.Console($"=== GameRoom Ready End. ===");

            // using var battleStart = MrRoom2C_BattleStart.Create();
            // battleStart.StartTime = TimeInfo.Instance.ServerFrameTime();
            // GameRoomServerComponent gameRoomServer = self.GetComponent<GameRoomServerComponent>();
            // foreach (GameRoomPlayer rp in gameRoomServer.Children.Values)
            // {
            //     battleStart.PlayerIds.Add(rp.Id);
            // }
            //
            // GameRoomMessageHelper.BroadCast(self, battleStart);
            // self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeInfo.Instance.ServerFrameTime() + GameConstValue.MatchTime * 60000,
            //     TimerInvokeType.GameRoomEnd, self);
        }

        public static void GameEnd(this MrRoom self)
        {
            Log.Console($"=== GameRoom GameEnd End. ===");

            // using var battleFinish = MrRoom2C_BattleFinish.Create();
            // GameRoomServerComponent gameRoomServer = self.GetComponent<GameRoomServerComponent>();
            // foreach (GameRoomPlayer rp in gameRoomServer.Children.Values)
            // {
            //     battleFinish.PlayerIds.Add(rp.Id);
            // }
            //
            // GameRoomMessageHelper.BroadCast(self, battleFinish);
        }
    }
}