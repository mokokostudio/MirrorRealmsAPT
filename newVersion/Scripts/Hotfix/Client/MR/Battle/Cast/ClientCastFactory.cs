namespace ET.Client
{
    [FriendOfAttribute(typeof (ET.Client.ClientCast))]
    public static class ClientCastFactory
    {
        public static ClientCast Create(Unit caster, long id, int configId)
        {
            ClientCast clientCast = caster.GetComponent<ClientCastComponent>().AddChildWithId<ClientCast, int>(id, configId);
            clientCast.CasterId = caster.Id;
            return clientCast;
        }
    }
}