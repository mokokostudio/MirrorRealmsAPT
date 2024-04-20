using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillStart__Handler: MessageHandler<Scene, M2C_SkillStart>
    {
        protected override async ETTask Run(Scene scene, M2C_SkillStart message)
        {
            Log.Console($"Zone: {scene.Zone()} -> unit {message.CasterId} 开始释放技能(id = {message.SkillId}), {message.SkillName} ");

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

            skillComponent.Start(message.SkillId, message.SkillName);

            EventSystem.Instance.Publish(scene.CurrentScene(),
                new SkillStart() { CasterId = message.CasterId, SkillName = message.SkillName, SkillId = message.SkillId });

            await ETTask.CompletedTask;
        }
    }
}