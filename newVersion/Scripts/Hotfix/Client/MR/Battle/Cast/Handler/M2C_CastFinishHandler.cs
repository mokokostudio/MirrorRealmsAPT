using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CastFinishHandler: MessageHandler<Scene, M2C_CastFinish>
    {
        protected override async ETTask Run(Scene scene, M2C_CastFinish message)
        {
            Log.Console($"Zone: {scene.Zone()} -> 施法者 {message.CasterId} 的技能 {message.CastId} 结束了");

            UnitComponent unitComponent = scene.CurrentScene().GetComponent<UnitComponent>();
            Unit caster = unitComponent.Get(message.CasterId);
            if (caster == null)
            {
                return;
            }

            ClientCast clientCast = caster.GetComponent<ClientCastComponent>().Get(message.CastId);
            if (clientCast == null)
            {
                return;
            }

            EventSystem.Instance.Publish(scene.CurrentScene(),
                new CastFinish() { CasterId = message.CasterId, CastId = message.CastId });

            caster.GetComponent<ClientCastComponent>().Remove(message.CastId);

            await ETTask.CompletedTask;
        }
    }
}