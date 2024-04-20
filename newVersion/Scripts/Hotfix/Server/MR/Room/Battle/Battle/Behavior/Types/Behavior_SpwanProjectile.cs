using Unity.Mathematics;

namespace ET.Server
{
    [Behavior(BehaviorType.SpawnProjectile)]
    [FriendOfAttribute(typeof (Cast))]
    public class Behavior_SpwanProjectile: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            Cast cast = behavior.CastSelf;
            if (cast == null || behaviorRunType != BehaviorRunType.CastImpact)
            {
                return;
            }

            if (cast.TargetIds.Count < 1)
            {
                return;
            }

            BehaviorConfig config = behavior.Config;
            UnitComponent unitComponent = behavior.Root().GetComponent<UnitComponent>();
            foreach (long targetId in cast.TargetIds)
            {
                Unit unit = unitComponent.Get(targetId);
                if (unit == null || unit.IsDisposed)
                {
                    continue;
                }

                int unitId = int.Parse(config.Params[0]);
                int projectileId = int.Parse(config.Params[1]);
                float x = float.Parse(config.Params[2]);
                float y = float.Parse(config.Params[3]);
                float z = float.Parse(config.Params[4]);
                
                float3 offset = new float3(x, y, z);
                float3 localOffset = new float3(math.dot(offset, unit.Right),
                    math.dot(offset, unit.Up),
                    math.dot(offset, unit.Forward));

                float3 startPos = unit.Position + localOffset;

                Unit projectile = UnitFactory.CreateProjectile(behavior.Root(), cast.Caster.Id, unitId, projectileId, startPos, unit.Rotation);
                projectile.GetComponent<ProjectileComponent>().Start();
            }
        }
    }
}