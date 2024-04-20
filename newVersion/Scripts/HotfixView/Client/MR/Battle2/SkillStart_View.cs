using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SkillStart_View: AEvent<Scene, SkillStart>
    {
        protected override async ETTask Run(Scene scene, SkillStart a)
        {
            Unit unit = scene.GetComponent<UnitComponent>().Get(a.CasterId);
            if (unit == null)
            {
                return;
            }

            await ETTask.CompletedTask;
        }
    }
}