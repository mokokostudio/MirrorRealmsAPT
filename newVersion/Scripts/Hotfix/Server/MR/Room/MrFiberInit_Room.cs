namespace ET.Server
{
    [Invoke((long)SceneType.MrRoom)]
    public class MrFiberInit_Room: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            
            root.AddComponent<UnitComponent>();
            root.AddComponent<AOIManagerComponent>();
            
            root.AddComponent<MrRoom>();

            await ETTask.CompletedTask;
        }
    }
}