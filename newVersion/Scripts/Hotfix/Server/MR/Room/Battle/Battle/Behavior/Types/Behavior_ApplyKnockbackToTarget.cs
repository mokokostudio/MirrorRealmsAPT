using Unity.Mathematics;

namespace ET.Server
{
    [Behavior(BehaviorType.ApplyKnockbackToTarget)]
    public class Behavior_ApplyKnockbackToTarget: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            Unit caster = behaviorRunType switch
            {
                BehaviorRunType.BuffTick => behavior.BuffSelf.Owner,
                BehaviorRunType.CastImpact => behavior.CastSelf.Caster,
                _ => null
            };

            if (caster == null)
            {
                Log.Warning($"Behavior_ApplyKnockbackToTarget: caster is null, behavior={behavior.ConfigId}");
                return;
            }

            BehaviorConfig config = behavior.Config;
            float range = float.Parse(config.Params[0]);
            float distance = float.Parse(config.Params[1]);
            int buffId = int.Parse(config.Params[2]);

            foreach (AOIEntity aoiEntity in caster.GetSeeUnits().Values)
            {
                Unit unit = aoiEntity.GetParent<Unit>();
                if (unit.UnitType() != UnitType.Player && unit.UnitType() != UnitType.Monster)
                {
                    continue;
                }

                if (unit == caster)
                {
                    continue;
                }

                if (math.distance(unit.Position, caster.Position) >= range)
                {
                    continue;
                }

                float3 unitPos = new(unit.Position.x, 0, unit.Position.z);

#if true
                float3 casterPos = new(caster.Position.x, 0, caster.Position.z);
                float3 dir = math.normalize(unitPos - casterPos);
#else
                float3 dir = new(caster.Forward.x, 0, caster.Forward.z);
#endif
                float3 newPos = unitPos + (dir * distance);


                unit.FindPathMoveToAsync(newPos).Coroutine();

                if (buffId > 0)
                {
                    unit.GetComponent<BuffComponent>()?.CreateAndAdd(buffId);
                }
            }
        }
    }
}