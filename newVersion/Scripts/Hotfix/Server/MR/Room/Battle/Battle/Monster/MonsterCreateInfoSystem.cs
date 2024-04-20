namespace ET.Server
{
    [EntitySystemOf(typeof (CreateMonsterInfo))]
    [FriendOfAttribute(typeof (ET.Server.CreateMonsterInfo))]
    public static partial class MonsterCreateInfoSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.CreateMonsterInfo self, int monsterId)
        {
            self.MonsterId = monsterId;
        }
    }
}