using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CastBreakHandler: MessageHandler<Scene, M2C_CastBreak>
    {
        protected override async ETTask Run(Scene scene, M2C_CastBreak message)
        {
            Log.Console($"Zone: {scene.Zone()} -> 施法者 {message.CasterId} 的技能 {message.CastId} 被打断了");

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
                new CastBreak() { CasterId = message.CasterId, CastId = message.CastId });

            caster.GetComponent<ClientCastComponent>().Remove(message.CastId);

            await ETTask.CompletedTask;
        }
    }
}