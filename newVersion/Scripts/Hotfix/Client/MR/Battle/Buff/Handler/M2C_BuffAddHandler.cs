using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_BuffAddHandler: MessageHandler<Scene, M2C_BuffAdd>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffAdd message)
        {
            Log.Console($"Zone: {scene.Zone()} -> Unit {message.UnitId} 添加了 {message.BuffData.ConfigId} Buff {message.BuffData.Id}");

            Unit unit = scene.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            ClientBuff clientBuff = ClientBuffFactory.Create(unit, message.BuffData);
            unit.GetComponent<ClientBuffComponent>().Add(clientBuff);

            EventSystem.Instance.Publish(scene.CurrentScene(),
                new BuffAdd() { Unit = unit, BuffConfigId = message.BuffData.ConfigId, BuffId = message.BuffData.Id, });

            await ETTask.CompletedTask;
        }
    }
}