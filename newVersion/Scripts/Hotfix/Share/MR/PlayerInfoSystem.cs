namespace ET
{
    [EntitySystemOf(typeof (MrPlayerInfo))]
    [FriendOfAttribute(typeof (ET.MrPlayerInfo))]
    public static partial class PlayerInfoSystem
    {
        [EntitySystem]
        private static void Awake(this ET.MrPlayerInfo self, string name)
        {
            self.Name = name;
        }
    }
}