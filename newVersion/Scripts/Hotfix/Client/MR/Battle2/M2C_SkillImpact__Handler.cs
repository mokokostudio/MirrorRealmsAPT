using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillImpact__Handler: MessageHandler<Scene, M2C_SkillImpact>
    {
        protected override async ETTask Run(Scene scene, M2C_SkillImpact message)
        {
            Log.Console($"Zone: {scene.Zone()} -> unit {message.CasterId} 技能(id = {message.SkillId}) 命中了 {message.TargetIds.ListToString()} ");

            // UnitComponent unitComponent = scene.CurrentScene().GetComponent<UnitComponent>();
            // Unit caster = unitComponent.Get(message.CasterId);
            // if (caster == null)
            // {
            //     return;
            // }
            //
            // var skillComponent = caster.GetComponent<ClientSkillComponent>();
            //
            // ClientSkill clientSkill = skillComponent.Get(message.SkillId);
            // if (clientSkill == null)
            // {
            //     return;
            // }

            EventSystem.Instance.Publish(scene.CurrentScene(),
                new SkillImpact() { CasterId = message.CasterId, SkillId = message.SkillId, TargetIds = message.TargetIds.ToArray() });

            

            await ETTask.CompletedTask;
        }
    }
}