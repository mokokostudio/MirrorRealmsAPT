namespace ET.Server
{
    [Behavior(BehaviorType.Damage)]
    [FriendOfAttribute(typeof (ET.Server.Cast))]
    public class Behavior_Damage: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            Cast cast = behavior.CastSelf;

            if (cast == null || cast.IsDisposed || behaviorRunType != BehaviorRunType.CastImpact)
            {
                return;
            }

            if (cast.TargetIds.Count < 1)
            {
                return;
            }

            UnitComponent unitComponent = behavior.Root().GetComponent<UnitComponent>();

            foreach (long targetId in cast.TargetIds)
            {
                Unit unit = unitComponent.Get(targetId);
                if (unit == null || unit.IsDisposed)
                {
                    continue;
                }

                BattleHelper.CalcAttack(cast.Caster, unit, behavior);
            }
        }
    }
}