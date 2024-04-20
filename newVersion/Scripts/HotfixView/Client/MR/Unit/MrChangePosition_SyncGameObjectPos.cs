using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MrChangePosition_SyncGameObjectPos: AEvent<Scene, ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ChangePosition args)
        {
            Unit unit = args.Unit;
            MrGameObjectComponent mrGameObjectComponent = unit.GetComponent<MrGameObjectComponent>();
            if (mrGameObjectComponent == null)
            {
                return;
            }

            Transform transform = mrGameObjectComponent.Transform;
            transform.position = unit.Position;
            await ETTask.CompletedTask;
        }
    }
}