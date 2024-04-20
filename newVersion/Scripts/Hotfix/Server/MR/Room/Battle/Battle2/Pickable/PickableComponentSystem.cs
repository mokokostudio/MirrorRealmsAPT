namespace ET.Server
{
    [EntitySystemOf(typeof (PickableComponent))]
    [FriendOf(typeof (PickableComponent))]
    public static partial class PickableComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PickableComponent self, int pickableConfigId)
        {
            self.ConfigId = pickableConfigId;
        }

        [EntitySystem]
        private static void Destroy(this PickableComponent self)
        {
            self.ConfigId = default;
        }
    }
}