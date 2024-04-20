using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_BuffTickHandler: MessageHandler<Scene, M2C_BuffTick>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffTick message)
        {
            Log.Console($"Zone: {scene.Zone()} -> Unit {message.UnitId} Buff {message.BuffId} Tick");

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
                new BuffTick() { Unit = unit, BuffId = message.BuffId });


            await ETTask.CompletedTask;
        }
    }
}