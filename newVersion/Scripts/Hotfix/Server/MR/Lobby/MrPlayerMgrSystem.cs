namespace ET.Server
{
    [FriendOf(typeof (MrPlayerMgr))]
    public static partial class MrPlayerMgrSystem
    {
        public static void Add(this MrPlayerMgr self, MrPlayer player)
        {
            self.dictionary.Add(player.Account, player);
        }

        public static void Remove(this MrPlayerMgr self, MrPlayer player)
        {
            self.dictionary.Remove(player.Account);
            player.Dispose();
        }

        public static MrPlayer Get(this MrPlayerMgr self, long id)
        {
            foreach (var player in self.dictionary.Values)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public static MrPlayer GetByAccount(this MrPlayerMgr self, string account)
        {
            self.dictionary.TryGetValue(account, out MrPlayer player);
            return player;
        }
    }
}