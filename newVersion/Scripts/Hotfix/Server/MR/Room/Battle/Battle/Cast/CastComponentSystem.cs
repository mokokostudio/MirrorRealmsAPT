namespace ET.Server
{
    [EntitySystemOf(typeof (CastComponent))]
    [FriendOfAttribute(typeof (ET.Server.Cast))]
    public static partial class CastComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CastComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this CastComponent self)
        {
        }

        public static Cast Create(this CastComponent self, int configId)
        {
            return self.AddChild<Cast, int>(configId);
        }
    }
}