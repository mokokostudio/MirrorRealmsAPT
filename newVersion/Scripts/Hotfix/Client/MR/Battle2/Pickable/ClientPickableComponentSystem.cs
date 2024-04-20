namespace ET.Client
{
    [EntitySystemOf(typeof (ClientPickableComponent))]
    [FriendOf(typeof (ClientPickableComponent))]
    public static partial class ClientPickableComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientPickableComponent self, long createTime)
        {
            self.CreateTime = createTime;
        }

        [EntitySystem]
        private static void Destroy(this ClientPickableComponent self)
        {
            self.CreateTime = default;
        }
    }
}