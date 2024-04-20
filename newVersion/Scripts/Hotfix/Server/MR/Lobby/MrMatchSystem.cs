namespace ET.Server
{
    [EntitySystemOf(typeof (MrMatch))]
    [FriendOf(typeof (MrMatch))]
    public static partial class MrMatchSystem
    {
        [EntitySystem]
        private static void Awake(this MrMatch self)
        {
            self.waitMatchPlayers = new();
        }

        public static void Match(this MrMatch self, long playerId, bool singlePlay)
        {
            if (singlePlay)
            {
                CreateRoom(self.Root(), new[] { playerId }).Coroutine();
            }
            else
            {
                if (self.waitMatchPlayers.Contains(playerId))
                {
                    return;
                }

                self.waitMatchPlayers.Add(playerId);

                //if (self.waitMatchPlayers.Count < MrGameConstValue.MatchCount)
                if (self.waitMatchPlayers.Count < Options.Instance.MatchCount)
                {
                    return;
                }

                CreateRoom(self.Root(), self.waitMatchPlayers.ToArray()).Coroutine();
                self.waitMatchPlayers.Clear();
            }
        }

        private static async ETTask CreateRoom(Scene lobbyScene, long[] playerIds)
        {
            var createRoomReq = MrLobby2RoomRoot_CreateRoom.Create();
            createRoomReq.PlayerIds.AddRange(playerIds);
            var actorId = RandomGenerator.RandomArray(StartSceneConfigCategory.Instance.MrRoomRoots).ActorId;
            var createRoomRes = await lobbyScene.GetComponent<MessageSender>().Call(actorId, createRoomReq) as MrRoomRoot2Lobby_CreateRoom;

            using var mrLobby2CNotifyMatchSuccess = MrLobby2C_NotifyMatchSuccess.Create();
            MessageLocationSenderComponent messageLocationSenderComponent = lobbyScene.GetComponent<MessageLocationSenderComponent>();

            foreach (long id in playerIds)
            {
                messageLocationSenderComponent.Get(LocationType.Player).Send(id, mrLobby2CNotifyMatchSuccess);
            }

            // 确认匹配?

            // 创建玩家角色并传送到房间
            foreach (long id in playerIds)
            {
                var player = lobbyScene.GetComponent<MrPlayerMgr>().Get(id);
                var lobbyMap = player.AddComponent<MrLobbyMap>();
                lobbyMap.Scene = await MrLobbyMapFactory.Create(lobbyMap, id, IdGenerater.Instance.GenerateInstanceId(), "LobbyMap");

                Unit unit = UnitFactory.CreatePlayer(lobbyMap.Scene, id);

                MrTransferHelper.TransferAtFrameFinish(unit, createRoomRes.ActorId).Coroutine();
            }
        }
    }
}