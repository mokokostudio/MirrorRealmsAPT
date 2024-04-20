namespace ET.Server
{
    [MessageHandler(SceneType.MrRoom)]
    public class MrRoomRoot2Map_Init__Handler: MessageHandler<Scene, MrRoomRoot2Map_Init, MrMap2RoomRoot_Init>
    {
        protected override async ETTask Run(Scene scene, MrRoomRoot2Map_Init request, MrMap2RoomRoot_Init response)
        {
            Log.Info($"房间初始化");

            var room = scene.GetComponent<MrRoom>();
            room.Init(request.PlayerIds, TimeInfo.Instance.ServerNow());
            await ETTask.CompletedTask;
        }
    }
}