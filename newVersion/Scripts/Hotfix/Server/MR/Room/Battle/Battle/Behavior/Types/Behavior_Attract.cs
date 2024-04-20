using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [Behavior(BehaviorType.Attract)]
    [FriendOfAttribute(typeof (ET.Server.ProjectileComponent))]
    public class Behavior_Attract: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            if (behaviorRunType != BehaviorRunType.ProjectileTick)
            {
                return;
            }

            Unit unit = behavior.Caster;
            List<long> TargetIds = behavior.ProjectileSelf.TargetIds;

            if (TargetIds.Count < 1)
            {
                return;
            }

            BehaviorConfig config = behavior.Config;

            float speed = float.Parse(config.Params[0]);
            float range = float.Parse(config.Params[1]);
            UnitComponent unitComponent = behavior.Scene().GetComponent<UnitComponent>();

            foreach (long targetId in TargetIds)
            {
                Unit u = unitComponent.Get(targetId);
                if (u == null || u.IsDisposed)
                {
                    continue;
                }

                if (math.distance(u.Position, unit.Position) < range)
                {
                    continue;
                }

                float3 dir = math.normalize(unit.Position - u.Position);
                float3 newPos = u.Position + dir * speed;
                Log.Console($"吸引目标{u.Id}, {u.Position} => {newPos}");
                u.ForceSetPosition(newPos, true);
            }
        }
    }
}