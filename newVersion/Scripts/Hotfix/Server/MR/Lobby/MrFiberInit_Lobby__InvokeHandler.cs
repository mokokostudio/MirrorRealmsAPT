using System.Net;

namespace ET.Server
{
    [Invoke((long)SceneType.MrLobby)]
    public class MrFiberInit_Lobby__InvokeHandler: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Log.Info($"FiberInit_Lobby");
            
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            
            root.AddComponent<MrLobbySessionKeyMgr>();
            root.AddComponent<MrPlayerMgr>();
            root.AddComponent<MrMatch>();

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get((int)root.Id);
            root.AddComponent<NetComponent, IPEndPoint, NetworkProtocol>(startSceneConfig.InnerIPPort, NetworkProtocol.UDP);
            await ETTask.CompletedTask;
        }
    }
}