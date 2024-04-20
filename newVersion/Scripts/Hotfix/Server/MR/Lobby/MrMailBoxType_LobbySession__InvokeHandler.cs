namespace ET.Server
{
    [Invoke((long)MailBoxType.GateSession)]
    public class MrMailBoxType_LobbySession__InvokeHandler: AInvokeHandler<MailBoxInvoker>
    {
        public override void Handle(MailBoxInvoker args)
        {
            MailBoxComponent mailBoxComponent = args.MailBoxComponent;
            
            // 这里messageObject要发送出去，不能回收
            IMessage messageObject = args.MessageObject;
            
            if (mailBoxComponent.Parent is MrPlayerSession playerSessionComponent)
            {
                playerSessionComponent.Session?.Send(messageObject);
            }
        }
    }
}