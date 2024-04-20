namespace ET.Server
{
    [FriendOf(typeof (Behavior))]
    [FriendOf(typeof (Cast))]
    [FriendOf(typeof (Buff))]
    public static class BehaviorHelper
    {
        public static Behavior CreateBehavior(this BehaviorTempComponent self, int behaviorId)
        {
            return self.AddChild<Behavior, int>(behaviorId);
        }

        public static Behavior CreateBehavior(this ProjectileComponent self, int behaviorId, Unit owner, Unit caster, BehaviorRunType behaviorRunType,
        bool autoRun = true, bool autoDispose = true)
        {
            Behavior behavior = self.GetComponent<BehaviorTempComponent>().CreateBehavior(behaviorId);
            behavior.Owner = owner;
            behavior.Caster = caster;

            RunBehavior(behavior, behaviorRunType, autoRun, autoDispose);

            if (behavior.IsDisposed)
            {
                return null;
            }

            return behavior;
        }

        public static Behavior CreateBehavior(this Buff self, int behaviorId, BehaviorRunType behaviorRunType, bool autoRun = true,
        bool autoDispose = true)
        {
            Behavior behavior = self.GetComponent<BehaviorTempComponent>().CreateBehavior(behaviorId);
            behavior.Owner = self.Owner;

            RunBehavior(behavior, behaviorRunType, autoRun, autoDispose);

            if (behavior.IsDisposed)
            {
                return null;
            }

            return behavior;
        }

        public static Behavior CreateBehavior(this Cast self, int behaviorId, Unit onwer, BehaviorRunType behaviorRunType,
        bool autoRun = true, bool autoDispose = true)
        {
            Behavior behavior = self.GetComponent<BehaviorTempComponent>().CreateBehavior(behaviorId);
            behavior.Caster = self.Caster;
            behavior.Owner = onwer;

            RunBehavior(behavior, behaviorRunType, autoRun, autoDispose);

            if (behavior.IsDisposed)
            {
                return null;
            }

            return behavior;
        }

        public static void RunBehavior(Behavior behavior, BehaviorRunType behaviorRunType, bool autoRun = true, bool autoDispose = true)
        {
            if (autoRun)
            {
                if (autoDispose)
                {
                    using (behavior)
                    {
                        RunBehaviorInner(behavior, behaviorRunType);
                    }
                }
                else
                {
                    RunBehaviorInner(behavior, behaviorRunType);
                }
            }
        }

        private static void RunBehaviorInner(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            IBehavior behaviorHandle = BehaviorDispatcher.Instance.Get(behavior.Config.Type);
            if (behaviorHandle == null)
            {
                Log.Error(
                    $"behavior type not found, unitId: {behavior.Owner?.Id}, behaviorConfigId: {behavior.ConfigId},  behaviorType: {behavior.Config.Type}");
                behavior.Dispose();
                return;
            }

            behaviorHandle.Run(behavior, behaviorRunType);
        }
    }
}