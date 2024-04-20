namespace ET.Server
{
    [MessageHandler(SceneType.MrRoomRoot)]
    public class MrLobby2RoomRoot_CreateRoom__Handler : MessageHandler<Scene, MrLobby2RoomRoot_CreateRoom, MrRoomRoot2Lobby_CreateRoom>
    {
        protected override async ETTask Run(Scene root, MrLobby2RoomRoot_CreateRoom request, MrRoomRoot2Lobby_CreateRoom response)
        {
            Fiber fiber = root.Fiber();
            int fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, fiber.Zone, SceneType.MrRoom, "MrRoom");
            ActorId roomActorId = new(fiber.Process, fiberId);

            var msg = MrRoomRoot2Map_Init.Create();
            msg.PlayerIds.AddRange(request.PlayerIds);
            await root.GetComponent<MessageSender>().Call(roomActorId, msg);

            response.ActorId = roomActorId;
            await ETTask.CompletedTask;
        }
    }
}