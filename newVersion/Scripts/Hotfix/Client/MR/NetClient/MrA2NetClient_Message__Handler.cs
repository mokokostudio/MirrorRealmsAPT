namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class MrA2NetClient_Message__Handler: MessageHandler<Scene, MrA2NetClient_Message>
    {
        protected override async ETTask Run(Scene root, MrA2NetClient_Message message)
        {
            root.GetComponent<MrSessionComponent>().Session.Send(message.MessageObject);
            await ETTask.CompletedTask;
        }
    }
}