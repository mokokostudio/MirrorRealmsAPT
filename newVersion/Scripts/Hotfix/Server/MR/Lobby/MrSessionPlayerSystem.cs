namespace ET.Server
{
    [EntitySystemOf(typeof(MrSessionPlayer))]
    public static partial class MrSessionPlayerSystem
    {
        [EntitySystem]
        private static void Destroy(this MrSessionPlayer self)
        {
            Scene root = self.Root();
            if (root.IsDisposed)
            {
                return;
            }
            // 发送断线消息
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(self.Player.Id, new G2M_SessionDisconnect());
        }
        
        [EntitySystem]
        private static void Awake(this MrSessionPlayer self)
        {

        }
    }
}