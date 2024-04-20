using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrRouterAddressComponent))]
    [FriendOf(typeof(MrRouterAddressComponent))]
    public static partial class MrRouterAddressComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrRouterAddressComponent self, string address, int port)
        {
            self.RouterManagerHost = address;
            self.RouterManagerPort = port;
        }
        
        public static async ETTask Init(this MrRouterAddressComponent self)
        {
            self.RouterManagerIPAddress = NetworkHelper.GetHostAddress(self.RouterManagerHost);
            await self.GetAllRouter();
        }

        private static async ETTask GetAllRouter(this MrRouterAddressComponent self)
        {
            string url = $"http://{self.RouterManagerHost}:{self.RouterManagerPort}/get_router?v={RandomGenerator.RandUInt32()}";
            Log.Debug($"start get router info: {url}");
            string routerInfo = await MrHttpClientHelper.Get(url);
            Log.Debug($"recv router info: {routerInfo}");
            HttpGetRouterResponse httpGetRouterResponse = MongoHelper.FromJson<HttpGetRouterResponse>(routerInfo);
            self.Info = httpGetRouterResponse;
            Log.Debug($"start get router info finish: {MongoHelper.ToJson(httpGetRouterResponse)}");
            
            // 打乱顺序
            RandomGenerator.BreakRank(self.Info.Routers);
            
            self.WaitTenMinGetAllRouter().Coroutine();
        }
        
        // 等10分钟再获取一次
        public static async ETTask WaitTenMinGetAllRouter(this MrRouterAddressComponent self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(5 * 60 * 1000);
            if (self.IsDisposed)
            {
                return;
            }
            await self.GetAllRouter();
        }

        public static IPEndPoint GetAddress(this MrRouterAddressComponent self)
        {
            if (self.Info.Routers.Count == 0)
            {
                return null;
            }

            string address = self.Info.Routers[self.RouterIndex++ % self.Info.Routers.Count];
            Log.Info($"get router address: {self.RouterIndex - 1} {address}");
            string[] ss = address.Split(':');
            IPAddress ipAddress = IPAddress.Parse(ss[0]);
            if (self.RouterManagerIPAddress.AddressFamily == AddressFamily.InterNetworkV6)
            { 
                ipAddress = ipAddress.MapToIPv6();
            }
            return new IPEndPoint(ipAddress, int.Parse(ss[1]));
        }
        
        public static IPEndPoint GetRealmAddress(this MrRouterAddressComponent self, string account)
        {
            int v = account.Mode(self.Info.Realms.Count);
            string address = self.Info.Realms[v];
            string[] ss = address.Split(':');
            IPAddress ipAddress = IPAddress.Parse(ss[0]);
            //if (self.IPAddress.AddressFamily == AddressFamily.InterNetworkV6)
            //{ 
            //    ipAddress = ipAddress.MapToIPv6();
            //}
            return new IPEndPoint(ipAddress, int.Parse(ss[1]));
        }
    }
}