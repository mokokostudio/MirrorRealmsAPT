using System;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrPingComponent))]
    public static partial class MrPingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrPingComponent self)
        {
            self.PingAsync().Coroutine();
        }
        
        [EntitySystem]
        private static void Destroy(this MrPingComponent self)
        {
            self.Ping = default;
        }
        
        private static async ETTask PingAsync(this MrPingComponent self)
        {
            Session session = self.GetParent<Session>();
            long instanceId = self.InstanceId;
            Fiber fiber = self.Fiber();
            
            while (true)
            {
                if (self.InstanceId != instanceId)
                {
                    return;
                }

                long time1 = TimeInfo.Instance.ClientNow();
                try
                {
                    var req = MrC2Lobby_Ping.Create(true);
                    var res = await session.Call(req) as MrLobby2C_Ping;

                    if (self.InstanceId != instanceId)
                    {
                        return;
                    }

                    long time2 = TimeInfo.Instance.ClientNow();
                    self.Ping = time2 - time1;
                    
                    TimeInfo.Instance.ServerMinusClientTime = res.Time + (time2 - time1) / 2 - time2;
                    
                    await fiber.Root.GetComponent<TimerComponent>().WaitAsync(2000);
                }
                catch (RpcException e)
                {
                    // session断开导致ping rpc报错，记录一下即可，不需要打成error
                    Log.Debug($"session disconnect, ping error: {self.Id} {e.Error}");
                    return;
                }
                catch (Exception e)
                {
                    Log.Error($"ping error: \n{e}");
                }
            }
        }
    }
}