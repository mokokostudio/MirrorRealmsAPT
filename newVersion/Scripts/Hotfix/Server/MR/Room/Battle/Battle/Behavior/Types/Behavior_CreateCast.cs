namespace ET.Server
{
    [Behavior(BehaviorType.CreateCast)]
    public class Behavior_CreateCast: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            RunAsync(behavior, behaviorRunType).Coroutine();
        }

        private async ETTask RunAsync(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            Cast cast = behavior.CastSelf;
            if (cast == null)
            {
                return;
            }

            if (behaviorRunType != BehaviorRunType.CastFinish)
            {
                Log.Error($"Behavior_CreateCast Run Error: behaviorRunType != BehaviorRunType.CastFinish");
                return;
            }

            BehaviorConfig config = behavior.Config;
            int castConfigId = int.Parse(config.Params[0]);
            EntityRef<Unit> unitRef = cast.Caster;
            await behavior.Scene().GetComponent<TimerComponent>().WaitFrameAsync();
            ((Unit)unitRef)?.CreateAndCast(castConfigId);
        }
    }
}