using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public static class MrMapMessageHelper
    {
        public static void NoticeUnitAdd(Unit unit, Unit sendUnit)
        {
            M2C_CreateUnits createUnits = M2C_CreateUnits.Create();
            createUnits.Units.Add(UnitHelper.CreateUnitInfo(sendUnit, false));
            SendToClient(unit, createUnits);
        }

        public static void NoticeUnitRemove(Unit unit, Unit sendUnit)
        {
            M2C_RemoveUnits removeUnits = M2C_RemoveUnits.Create();
            removeUnits.Units.Add(sendUnit.Id);
            SendToClient(unit, removeUnits);
        }

        public static void Broadcast(Unit unit, IMessage message, bool exceptSelf = false)
        {
            (message as MessageObject).IsFromPool = false;
            Dictionary<long, AOIEntity> dict = unit.GetBeSeePlayers();
            // 网络底层做了优化，同一个消息不会多次序列化
            MessageLocationSenderOneType oneTypeMessageLocationType =
                    unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession);
            foreach (AOIEntity u in dict.Values)
            {
                if (exceptSelf && u.Id == unit.Id)
                    continue;
                oneTypeMessageLocationType.Send(u.Unit.Id, message);
            }
        }

        public static void SendToClient(Unit unit, IMessage message)
        {
            unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(unit.Id, message);
        }

        /// <summary>
        /// 发送协议给Actor
        /// </summary>
        public static void Send(Scene root, ActorId actorId, IMessage message)
        {
            root.GetComponent<MessageSender>().Send(actorId, message);
        }

        public static void SendClient(Unit unit, IMessage message, NoticeClientType noticeClientType)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            switch (noticeClientType)
            {
                case NoticeClientType.NoNotice:
                    break;
                case NoticeClientType.Self:
                    MrMapMessageHelper.SendToClient(unit, message);
                    break;
                case NoticeClientType.Broadcast:
                    if (unit.GetComponent<AOIEntity>() != null)
                    {
                        MrMapMessageHelper.Broadcast(unit, message);
                    }

                    break;
                case NoticeClientType.BroadcastExceptSelf:
                    if (unit.GetComponent<AOIEntity>() != null)
                    {
                        MrMapMessageHelper.Broadcast(unit, message, true);
                    }

                    break;
            }
        }

        public static void ForceSetPosition(this Unit unit, float3 newPos, bool sendMsg = false)
        {
            unit.Position = unit.GetComponent<PathfindingComponent>().RecastFindNearestPoint(newPos);

            if (!sendMsg)
            {
                return;
            }

            M2C_SetPosition msg = new() { UnitId = unit.Id, Position = unit.Position, Rotation = unit.Rotation };
            SendClient(unit, msg, NoticeClientType.Broadcast);
        }
    }
}