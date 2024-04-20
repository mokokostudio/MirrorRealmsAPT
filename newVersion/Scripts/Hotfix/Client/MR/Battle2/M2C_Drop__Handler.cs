using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_Drop__Handler: MessageHandler<Scene, MrM2C_Drop>
    {
        protected override async ETTask Run(Scene scene, MrM2C_Drop message)
        {
            Log.Console($"Zone: {scene.Zone()} -> 掉落物品 {message.UintId} 产生在 {message.SpawnPosition} -> {message.TargetPosition}");

            var e = new DropCreated()
            {
                UnitId = message.UintId, SpawnPosition = message.SpawnPosition, TargetPosition = message.TargetPosition
            };
            EventSystem.Instance.PublishAsync(scene.CurrentScene(), e).Coroutine();

            await ETTask.CompletedTask;
        }
    }
}