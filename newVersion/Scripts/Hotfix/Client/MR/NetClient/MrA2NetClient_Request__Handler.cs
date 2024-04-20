namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class MrA2NetClient_Request__Handler: MessageHandler<Scene, MrA2NetClient_Request, MrA2NetClient_Response>
    {
        protected override async ETTask Run(Scene root, MrA2NetClient_Request request, MrA2NetClient_Response response)
        {
            response.MessageObject = await root.GetComponent<MrSessionComponent>().Session.Call(request.MessageObject);
        }
    }
}