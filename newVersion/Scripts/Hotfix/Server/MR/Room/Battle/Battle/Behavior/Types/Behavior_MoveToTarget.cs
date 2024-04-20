using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [Behavior(BehaviorType.MoveToTarget)]
    [FriendOfAttribute(typeof (ET.Server.Cast))]
    [FriendOfAttribute(typeof (ET.Server.ProjectileComponent))]
    public class Behavior_MoveToTarget: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            Unit unit = null;
            List<long> targetIds = null;

            switch (behaviorRunType)
            {
                case BehaviorRunType.CastImpact:
                {
                    Cast cast = behavior.CastSelf;
                    unit = cast.Caster;
                    targetIds = cast.TargetIds;
                    break;
                }
                case BehaviorRunType.ProjectileTick:
                {
                    ProjectileComponent projectileComponent = behavior.ProjectileSelf;
                    unit = behavior.Caster;
                    targetIds = projectileComponent.TargetIds;
                    break;
                }
                case BehaviorRunType.BuffAdd:
                case BehaviorRunType.BuffTick:
                case BehaviorRunType.BuffRemove:
                case BehaviorRunType.ProjectileSpawn:
                case BehaviorRunType.ProjectileDestruction:
                default:
                    break;
            }

            if (unit == null || targetIds == null)
            {
                return;
            }

            float3 newPos = float3.zero;
            BehaviorConfig config = behavior.Config;

            int speed = int.Parse(config.Params[0]);

            Unit target = null;

            if (targetIds.Count > 0)
            {
                UnitComponent unitComponent = behavior.Scene().GetComponent<UnitComponent>();
                Unit u = unitComponent.Get(targetIds[0]);
                if (u is { IsDisposed: false } && u != unit)
                {
                    target = u;
                }
            }

            if (target != null)
            {
                newPos = unit.Position + math.normalize(target.Position - unit.Position) * speed;
            }
            else
            {
                newPos = unit.Position + math.normalize(unit.Forward) * speed;
            }

            newPos.y = unit.Position.y;
            unit.FindPathMoveToAsync(newPos).Coroutine();

            Log.Console($"unit({unit.Id}) 以{speed}的速度向目标移动, oldPos: {unit.Position} -> newPos: {newPos}");
        }
    }
}