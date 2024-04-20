using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_BuffRemoveHandler: MessageHandler<Scene, M2C_BuffRemove>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffRemove message)
        {
            Log.Console($"Zone: {scene.Zone()} -> Unit {message.UnitId} 移除了 Buff {message.BuffId} ");

            Unit unit = scene.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            ClientBuff clientBuff = unit.GetComponent<ClientBuffComponent>().Get(message.BuffId);
            if (clientBuff == null)
            {
                return;
            }

            EventSystem.Instance.Publish(scene.CurrentScene(),
                new BuffRemove() { Unit = unit, BuffId = message.BuffId });

            unit.GetComponent<ClientBuffComponent>().Remove(message.BuffId);

            await ETTask.CompletedTask;
        }
    }
}