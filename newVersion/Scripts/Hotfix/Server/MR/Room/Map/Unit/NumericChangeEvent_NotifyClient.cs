namespace ET.Server
{
    [Event(SceneType.All)]
    public class NumericChangeEvent_NotifyClient: AEvent<Scene, NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange a)
        {
            M2C_NumericChange msg = new() { UnitId = a.Unit.Id, KV = new() };
            msg.KV.Add(a.NumericType, a.New);
            MrMapMessageHelper.SendClient(a.Unit, msg, NoticeClientType.Broadcast);

            await ETTask.CompletedTask;
        }
    }
}