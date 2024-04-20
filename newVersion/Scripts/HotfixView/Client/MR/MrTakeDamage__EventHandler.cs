using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MrTakeDamage__EventHandler: AEvent<Scene, EventType.TakeDamage>
    {
        protected override async ETTask Run(Scene scene, EventType.TakeDamage a)
        {
            var myId = scene.Root().GetComponent<MrPlayerComponent>().MyId;
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            var unit = unitComponent.Get(a.TargetId);
            if (unit == null)
            {
                return;
            }

            if (a.AttackerId == myId)
            {
                var pos = unit.Position + new float3(0, 1.5f, 0);
                var text = $"{math.abs(a.Damage)}";
                var fontSize = 30;
                var color = a.DamageType switch
                {
                    SkillConfig.DamageType.NormalAttackDamage => Color.white,
                    SkillConfig.DamageType.SkillDamage => new Color(0.95f, 0.823f, 0.075f),
                    SkillConfig.DamageType.PoisonDamage => new Color(0.5f, 0, 1),
                    _ => Color.white
                };

                var com = scene.GetComponent<ShowFloatingTextComponent>();
                com.Create(pos, text, fontSize, color);
            }

            await ETTask.CompletedTask;
        }
    }
}