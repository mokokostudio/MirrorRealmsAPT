namespace ET.Server
{
    [EntitySystemOf(typeof (ReliveComponent))]
    [FriendOfAttribute(typeof (ET.Server.ReliveComponent))]
    public static partial class ReliveComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ReliveComponent self)
        {
            self.Alive = true;
        }

        [EntitySystem]
        private static void Destroy(this ReliveComponent self)
        {
            self.Alive = default;
        }
    }
}