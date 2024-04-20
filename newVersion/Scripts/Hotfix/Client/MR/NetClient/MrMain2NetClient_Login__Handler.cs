using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class MrMain2NetClient_Login__Handler: MessageHandler<Scene, MrMain2NetClient_Login, MrNetClient2Main_Login>
    {
        protected override async ETTask Run(Scene root, MrMain2NetClient_Login request, MrNetClient2Main_Login response)
        {
            string account = request.Account;
            string password = request.Password;

            root.RemoveComponent<MrRouterAddressComponent>();
            MrRouterAddressComponent routerAddressComponent =
                    root.AddComponent<MrRouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
            await routerAddressComponent.Init();
            root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily,
                NetworkProtocol.UDP);
            root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

            NetComponent netComponent = root.GetComponent<NetComponent>();

            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

            MrR2C_Login r2CLogin;
            using (Session session = await netComponent.CreateRouterSession(realmAddress, account, password))
            {
                r2CLogin = (MrR2C_Login)await session.Call(new MrC2R_Login() { Account = account, Password = password });
            }

            // 创建一个gate Session,并且保存到SessionComponent中
            Session gateSession = await netComponent.CreateRouterSession(NetworkHelper.ToIPEndPoint(r2CLogin.Address), account, password);
            gateSession.AddComponent<ClientSessionErrorComponent>();
            root.AddComponent<MrSessionComponent>().Session = gateSession;
            MrLobby2C_Login g2CLoginGate = (MrLobby2C_Login)await gateSession.Call(new MrC2Lobby_Login() { Key = r2CLogin.Key });

            Log.Debug("登陆Lobby成功!");

            response.PlayerId = g2CLoginGate.PlayerId;
        }
    }
}