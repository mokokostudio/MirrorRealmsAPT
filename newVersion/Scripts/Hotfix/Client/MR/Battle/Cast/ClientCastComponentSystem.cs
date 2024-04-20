namespace ET.Client
{
    [EntitySystemOf(typeof (ClientCastComponent))]
    [FriendOfAttribute(typeof (ET.Client.ClientCastComponent))]
    public static partial class ClientCastComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ClientCastComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ClientCastComponent self)
        {
            foreach (ClientCast cast in self.Casts.Values)
            {
                cast?.Dispose();
            }

            self.Casts.Clear();
        }

        public static void Add(this ClientCastComponent self, ClientCast clientCast)
        {
            if (self.Casts.ContainsKey(clientCast.Id))
            {
                return;
            }

            self.Casts.Add(clientCast.Id, clientCast);
        }

        public static ClientCast Get(this ClientCastComponent self, long id)
        {
            if (self.Casts.TryGetValue(id, out ClientCast cast))
            {
                return cast;
            }

            return null;
        }

        public static void Remove(this ClientCastComponent self, long id)
        {
            ClientCast clientCast = self.Get(id);
            if (clientCast == null)
            {
                return;
            }

            self.Casts.Remove(id);
            clientCast.Dispose();
        }
    }
}