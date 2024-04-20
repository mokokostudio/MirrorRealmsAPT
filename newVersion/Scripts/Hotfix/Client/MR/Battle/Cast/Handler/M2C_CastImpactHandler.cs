using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    [FriendOfAttribute(typeof (ClientCast))]
    public class M2C_CastImpactHandler: MessageHandler<Scene, M2C_CastImpact>
    {
        protected override async ETTask Run(Scene scene, M2C_CastImpact message)
        {
            Log.Console($"Zone: {scene.Zone()} -> 施法者 {message.CasterId} 技能 {message.CastId} 命中了 {message.TargetIds.ListToString()} ");

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

            clientCast.TargetIds.Clear();
            
            foreach (long targetId in message.TargetIds)
            {
                Unit target = unitComponent.Get(targetId);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                clientCast.TargetIds.Add(targetId);
            }

            foreach (long targetId in message.TargetIds)
            {
                EventSystem.Instance.Publish(scene.CurrentScene(),
                    new CastImpact() { CasterId = message.CasterId, CastId = message.CastId, TargetId = targetId });
            }

            await ETTask.CompletedTask;
        }
    }
}