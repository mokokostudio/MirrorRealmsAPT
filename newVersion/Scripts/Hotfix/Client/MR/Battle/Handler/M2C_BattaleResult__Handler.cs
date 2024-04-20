namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_BattaleResult__Handler: MessageHandler<Scene, M2C_BattleResult>
    {
        protected override async ETTask Run(Scene root, M2C_BattleResult message)
        {
            Log.Info($"M2C_BattleResult: 攻击者({message.AttackerId})对目标({message.TargetId}造成了{message.Damage}点伤害.)");

            // UnitComponent unitComponent = root.CurrentScene().GetComponent<UnitComponent>();
            // if (unitComponent == null)
            // {
            //     return;
            // }
            //
            // Unit unit = unitComponent.Get(message.TargetId);
            //
            // if (unit == null)
            // {
            //     return;
            // }

            if (message.ShouldShowDamageText)
            {
                EventSystem.Instance.Publish(root.CurrentScene(),
                    new ET.EventType.TakeDamage()
                    {
                        AttackerId = message.AttackerId,
                        TargetId = message.TargetId,
                        DamageType = (SkillConfig.DamageType)message.DamageType,
                        Damage = message.Damage
                    });
            }

            await ETTask.CompletedTask;
        }
    }
}