using ET.EventType;

namespace ET.Server
{
    [Event(SceneType.MrRoom)]
    public class BuffTimeOut_RemoveBuff: AEvent<Scene, EventType.BuffTimeOut>
    {
        protected override async ETTask Run(Scene scene, BuffTimeOut buffTimeOut)
        {
            Unit unit = buffTimeOut.Unit;
            if (unit == null)
            {
                return;
            }

            BuffComponent buffComponent = unit.GetComponent<BuffComponent>();
            if (buffComponent == null)
            {
                return;
            }

            buffComponent.Remove(buffTimeOut.BuffId);

            await ETTask.CompletedTask;
        }
    }
}