namespace ET.Server
{
    [EntitySystemOf(typeof(MrPlayer))]
    [FriendOf(typeof(MrPlayer))]
    public static partial class MrPlayerSystem
    {
        [EntitySystem]
        private static void Awake(this MrPlayer self, string a)
        {
            self.Account = a;
        }
    }
}