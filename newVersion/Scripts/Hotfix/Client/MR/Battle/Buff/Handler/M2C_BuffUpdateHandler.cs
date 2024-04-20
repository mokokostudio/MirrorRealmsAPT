using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_BuffUpdateHandler: MessageHandler<Scene, M2C_BuffUpdate>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffUpdate message)
        {
            Log.Console($"Zone: {scene.Zone()} -> Unit {message.UnitId} Buff 更新 {message.BuffData.ConfigId} Buff {message.BuffData.Id}");

            Unit unit = scene.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            ClientBuff clientBuff = unit.GetComponent<ClientBuffComponent>().Get(message.BuffData.Id);
            if (clientBuff == null)
            {
                return;
            }

            unit.GetComponent<ClientBuffComponent>().Update(message.BuffData);

            EventSystem.Instance.Publish(scene.CurrentScene(),
                new BuffUpdate() { Unit = unit, BuffId = message.BuffData.Id, BuffConfigId = message.BuffData.ConfigId });

            await ETTask.CompletedTask;
        }
    }
}