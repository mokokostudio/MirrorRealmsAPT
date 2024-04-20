namespace ET.Server
{
    [EntitySystemOf(typeof (Behavior))]
    public static partial class BehaviorSystem
    {
        [EntitySystem]
        private static void Awake(this Behavior self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this Behavior self)
        {
            self.ConfigId = default;
            self.Caster = default;
            self.Owner = default;
        }
    }
}