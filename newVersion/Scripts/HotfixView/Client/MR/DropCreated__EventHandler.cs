using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class DropCreated__EventHandler: AEvent<Scene, EventType.DropCreated>
    {
        protected override async ETTask Run(Scene scene, DropCreated a)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            var unit = unitComponent.Get(a.UnitId);
            if (unit == null)
            {
                return;
            }

            var go = unit.GetComponent<MrGameObjectComponent>().GameObject;
            //
            var drop = go.AddComponent<Drop>();
            drop.spawnPos = a.SpawnPosition;
            drop.targetPos = a.TargetPosition;
            drop.jumpDuration = 0.5f + 0.5f * RandomGenerator.RandFloat01();
            drop.height = 1f + 0.5f * RandomGenerator.RandFloat01();
            drop.count = 3;
            //
            go.SetActive(true);

            await ETTask.CompletedTask;
        }
    }
}