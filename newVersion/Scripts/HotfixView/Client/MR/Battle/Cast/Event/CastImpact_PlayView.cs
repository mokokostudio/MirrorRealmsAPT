using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class CastImpact_PlayView: AEvent<Scene, CastImpact>
    {
        protected override async ETTask Run(Scene scene, CastImpact a)
        {
            Unit unit = scene.GetComponent<UnitComponent>().Get(a.TargetId);

            if (unit == null)
            {
                return;
            }

            Unit caster = scene.GetComponent<UnitComponent>().Get(a.CasterId);
            if (caster == null)
            {
                return;
            }

            ClientCast clientCast = caster.GetComponent<ClientCastComponent>().Get(a.CastId);
            if (clientCast == null)
            {
                return;
            }

            CastConfig castConfig = clientCast.Config;

            foreach (int fxId in castConfig.ImpactFXs)
            {
                FXHelper.CreateFX(unit, fxId).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}