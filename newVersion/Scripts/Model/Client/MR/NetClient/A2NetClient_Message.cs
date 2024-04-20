namespace ET
{
    [Message]
    public class MrA2NetClient_Message: MessageObject, IMessage
    {
        public static MrA2NetClient_Message Create()
        {
            return ObjectPool.Instance.Fetch(typeof(MrA2NetClient_Message)) as MrA2NetClient_Message;
        }

        public override void Dispose()
        {
            this.MessageObject = default;
            ObjectPool.Instance.Recycle(this);
        }
        
        public IMessage MessageObject;
    }
    
    [Message]
    [ResponseType(nameof(MrA2NetClient_Response))]
    public class MrA2NetClient_Request: MessageObject, IRequest
    {
        public static MrA2NetClient_Request Create()
        {
            return ObjectPool.Instance.Fetch(typeof(MrA2NetClient_Request)) as MrA2NetClient_Request;
        }

        public override void Dispose()
        {
            this.RpcId = default;
            this.MessageObject = default;
            ObjectPool.Instance.Recycle(this);
        }
     
        public int RpcId { get; set; }
        public IRequest MessageObject;
    }
    
    [Message]
    public class MrA2NetClient_Response: MessageObject, IResponse
    {
        public static MrA2NetClient_Response Create()
        {
            return ObjectPool.Instance.Fetch(typeof(MrA2NetClient_Response)) as MrA2NetClient_Response;
        }

        public override void Dispose()
        {
            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MessageObject = default;
            ObjectPool.Instance.Recycle(this);
        }

        public int RpcId { get; set; }
        public int Error { get; set; }
        public string Message { get; set; }
        
        public IResponse MessageObject;
    }
    
    [Message]
    public class MrNetClient2Main_SessionDispose: MessageObject, IMessage
    {
        public static MrNetClient2Main_SessionDispose Create()
        {
            return ObjectPool.Instance.Fetch(typeof(MrNetClient2Main_SessionDispose)) as MrNetClient2Main_SessionDispose;
        }

        public override void Dispose()
        {
            ObjectPool.Instance.Recycle(this);
        }
        
        public int Error { get; set; }
    }
}