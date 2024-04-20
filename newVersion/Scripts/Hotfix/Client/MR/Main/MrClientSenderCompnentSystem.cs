
namespace ET.Client
{
    [EntitySystemOf(typeof(MrClientSenderCompnent))]
    [FriendOf(typeof(MrClientSenderCompnent))]
    public static partial class MrClientSenderCompnentSystem
    {
        [EntitySystem]
        private static void Awake(this MrClientSenderCompnent self)
        {

        }
        
        [EntitySystem]
        private static void Destroy(this MrClientSenderCompnent self)
        {
            self.RemoveFiberAsync().Coroutine();
        }

        private static async ETTask RemoveFiberAsync(this MrClientSenderCompnent self)
        {
            if (self.fiberId == 0)
            {
                return;
            }

            int fiberId = self.fiberId;
            self.fiberId = 0;
            await FiberManager.Instance.Remove(fiberId);
        }

        public static async ETTask<long> LoginAsync(this MrClientSenderCompnent self, string account, string password)
        {
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);

            var response = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId,
                new MrMain2NetClient_Login() { OwnerFiberId = self.Fiber().Id, Account = account, Password = password }) as MrNetClient2Main_Login;
            return response.PlayerId;
        }

        public static void Send(this MrClientSenderCompnent self, IMessage message)
        {
            MrA2NetClient_Message a2NetClientMessage = MrA2NetClient_Message.Create();
            a2NetClientMessage.MessageObject = message;
            self.Root().GetComponent<ProcessInnerSender>().Send(self.netClientActorId, a2NetClientMessage);
        }

        public static async ETTask<IResponse> Call(this MrClientSenderCompnent self, IRequest request, bool needException = true)
        {
            MrA2NetClient_Request a2NetClientRequest = MrA2NetClient_Request.Create();
            a2NetClientRequest.MessageObject = request;
            MrA2NetClient_Response a2NetClientResponse = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, a2NetClientRequest) as MrA2NetClient_Response;
            IResponse response = a2NetClientResponse.MessageObject;
                        
            if (response.Error == ErrorCore.ERR_MessageTimeout)
            {
                throw new RpcException(response.Error, $"Rpc error: request, 注意Actor消息超时，请注意查看是否死锁或者没有reply: {request}, response: {response}");
            }

            if (needException && ErrorCore.IsRpcNeedThrowException(response.Error))
            {
                throw new RpcException(response.Error, $"Rpc error: {request}, response: {response}");
            }
            return response;
        }

    }
}