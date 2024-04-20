using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class CastFinish_PlayView: AEvent<Scene, CastFinish>
    {
        protected override async ETTask Run(Scene scene, CastFinish a)
        {
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
            
            //FIXME
            // caster.GetComponent<AnimatorComponent>()?.Play(MotionType.Idle);
            
            

            await ETTask.CompletedTask;
        }
    }
}