namespace ET.Client
{
    public static class MrLoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password)
        {
            root.RemoveComponent<MrClientSenderCompnent>();
            MrClientSenderCompnent clientSenderCompnent = root.AddComponent<MrClientSenderCompnent>();

            long playerId = await clientSenderCompnent.LoginAsync(account, password);

            root.GetComponent<MrPlayerComponent>().MyId = playerId;

            // TODO: MrPlayerInfoComponent 2024.02.29
            MrPlayerInfoComponent playerInfoComp = root.GetComponent<MrPlayerInfoComponent>();
            playerInfoComp.InitPlayerInfos(new int[] { 8, 9, 10 }, new int[] { 2, 10, 5}, new int[] { 1000001301, 1000002301, 1000003301 });

            await EventSystem.Instance.PublishAsync(root, new MrLoginFinish());
        }
    }
}