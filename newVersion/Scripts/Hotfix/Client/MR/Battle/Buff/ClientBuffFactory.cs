namespace ET.Client
{
    [FriendOfAttribute(typeof (ET.Client.ClientBuff))]
    public static class ClientBuffFactory
    {
        public static ClientBuff Create(Unit owner, BuffProto buffData)
        {
            ClientBuff clientBuff = owner.GetComponent<ClientBuffComponent>().AddChildWithId<ClientBuff, int>(buffData.Id, buffData.ConfigId);
            clientBuff.Owner = owner;
            clientBuff.CreateTime = buffData.CreateTime;
            clientBuff.ExpireTime = buffData.ExpireTime;
            return clientBuff;
        }
    }
}