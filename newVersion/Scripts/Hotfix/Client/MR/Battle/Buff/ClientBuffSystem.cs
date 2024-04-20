namespace ET.Client
{
    [EntitySystemOf(typeof (ClientBuff))]
    [FriendOfAttribute(typeof (ET.Client.ClientBuff))]
    public static partial class ClientBuffSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ClientBuff self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ClientBuff self)
        {
            self.ConfigId = default;
            self.Owner = default;
            self.CreateTime = default;
            self.ExpireTime = default;
        }
    }
}