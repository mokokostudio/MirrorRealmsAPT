namespace ET.Server
{
    public interface IBehavior
    {
        void Run(Behavior behavior, BehaviorRunType behaviorRunType);
    }
}
