namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class MrRoom2C_NotifyPhaseInfo__Handler: MessageHandler<Scene, MrRoom2C_NotifyPhaseInfo>
    {
        protected override async ETTask Run(Scene entity, MrRoom2C_NotifyPhaseInfo message)
        {
            MrRoomPhaseInfoChange e = new()
            {
                Phase = (MrRoomPhase)message.Phase, StartTime = message.StartTime, RemainingTime = message.RemainingTime
            };

            EventSystem.Instance.PublishAsync(entity.CurrentScene(), e).Coroutine();

            await ETTask.CompletedTask;
        }
    }
}