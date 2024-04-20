namespace ET.Server
{
    [Behavior(BehaviorType.NumbericChange)]
    [FriendOf(typeof (Behavior))]
    public class Behavior_NumbericChange: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            Unit owner = behavior.Owner;

            if (owner == null || owner.IsDisposed)
            {
                return;
            }

            int numbericType = int.Parse(behavior.Config.Params[0]);
            int numbericValue = int.Parse(behavior.Config.Params[1]);

            switch (behaviorRunType)
            {
                case BehaviorRunType.CastImpact:
                case BehaviorRunType.BuffAdd:
                { 
                    owner.GetComponent<NumericComponent>()[numbericType] += numbericValue;
                }
                    break;

                case BehaviorRunType.BuffRemove:
                {
                    owner.GetComponent<NumericComponent>()[numbericType] -= numbericValue;
                }
                    break;
            }
        }
    }
}