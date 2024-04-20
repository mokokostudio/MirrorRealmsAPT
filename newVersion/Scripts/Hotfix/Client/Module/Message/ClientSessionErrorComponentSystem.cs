﻿namespace ET.Client
{
    [EntitySystemOf(typeof(ClientSessionErrorComponent))]
    public static partial class ClientSessionErrorComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientSessionErrorComponent self)
        {

        }
        
        [EntitySystem]
        private static void Destroy(this ClientSessionErrorComponent self)
        {
            Fiber fiber = self.Fiber();
            if (fiber.IsDisposed)
            {
                return;
            }
            MrNetClient2Main_SessionDispose message = MrNetClient2Main_SessionDispose.Create();
            message.Error = self.GetParent<Session>().Error;
            fiber.Root.GetComponent<ProcessInnerSender>().Send(new ActorId(fiber.Process, ConstFiberId.Main), message);
        }
    }
}