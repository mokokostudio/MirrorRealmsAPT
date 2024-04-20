using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillFinish__Handler: MessageHandler<Scene, M2C_SkillFinish>
    {
        protected override async ETTask Run(Scene scene, M2C_SkillFinish message)
        {
            Log.Console($"Zone: {scene.Zone()} -> unit {message.CasterId} 技能(id = {message.SkillId})释放结束 ");

            Unit caster = scene.CurrentScene().GetComponent<UnitComponent>().Get(message.CasterId);
            if (caster == null)
            {
                return;
            }

            var skillComponent = caster.GetComponent<ClientSkillComponent>();
            if (skillComponent == null)
            {
                return;
            }

            if (skillComponent.IsCasting(message.SkillId))
            {
                EventSystem.Instance.Publish(scene.CurrentScene(),
                    new SkillFinish() { CasterId = message.CasterId, SkillId = message.SkillId });

                skillComponent.Finish(message.SkillId);
            }

            await ETTask.CompletedTask;
        }
    }
}