using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ET.Server
{
    [HttpHandler(SceneType.RouterManager, "/get_router")]
    public class MrHttpGetRouterHandler : IHttpHandler
    {
        public async ETTask Handle(Scene scene, HttpListenerContext context)
        {
            HttpGetRouterResponse response = new();
            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Realms)
            {
                response.Realms.Add(startSceneConfig.InnerIPPort.ToString());
            }
            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Routers)
            {
                response.Routers.Add($"{startSceneConfig.StartProcessConfig.OuterIP}:{startSceneConfig.Port}");
            }
            MrHttpHelper.Response(context, response);
            await ETTask.CompletedTask;
        }
    }
}