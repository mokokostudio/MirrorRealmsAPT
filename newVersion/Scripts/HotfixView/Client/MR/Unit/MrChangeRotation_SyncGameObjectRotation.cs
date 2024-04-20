using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MrChangeRotation_SyncGameObjectRotation: AEvent<Scene, ChangeRotation>
    {
        protected override async ETTask Run(Scene scene, ChangeRotation args)
        {
            Unit unit = args.Unit;
            MrGameObjectComponent mrGameObjectComponent = unit.GetComponent<MrGameObjectComponent>();
            if (mrGameObjectComponent == null)
            {
                return;
            }
            Transform transform = mrGameObjectComponent.GameObject.transform;
            transform.rotation = unit.Rotation;
            await ETTask.CompletedTask;
        }
    }
}
