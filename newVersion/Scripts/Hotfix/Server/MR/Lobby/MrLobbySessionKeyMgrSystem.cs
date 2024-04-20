namespace ET.Server
{
    [FriendOf(typeof(MrLobbySessionKeyMgr))]
    public static partial class MrLobbySessionKeyMgrSystem
    {
        public static void Add(this MrLobbySessionKeyMgr self, long key, string account)
        {
            self.sessionKey.Add(key, account);
            self.TimeoutRemoveKey(key).Coroutine();
        }

        public static string Get(this MrLobbySessionKeyMgr self, long key)
        {
            string account = null;
            self.sessionKey.TryGetValue(key, out account);
            return account;
        }

        public static void Remove(this MrLobbySessionKeyMgr self, long key)
        {
            self.sessionKey.Remove(key);
        }

        private static async ETTask TimeoutRemoveKey(this MrLobbySessionKeyMgr self, long key)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(20000);
            self.sessionKey.Remove(key);
        }
    }
}