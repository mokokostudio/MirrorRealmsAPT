namespace ET.Client
{
    [EntitySystemOf(typeof (ClientBuffComponent))]
    [FriendOfAttribute(typeof (ClientBuffComponent))]
    [FriendOfAttribute(typeof (ClientBuff))]
    public static partial class ClientBuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientBuffComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ClientBuffComponent self)
        {
            foreach (ClientBuff buff in self.Buffs.Values)
            {
                buff?.Dispose();
            }

            self.Buffs.Clear();
        }

        public static void Add(this ClientBuffComponent self, ClientBuff clientBuff)
        {
            if (self.Buffs.ContainsKey(clientBuff.Id))
            {
                return;
            }

            self.Buffs.Add(clientBuff.Id, clientBuff);
            clientBuff.Owner = self.GetParent<Unit>();
        }

        public static ClientBuff Get(this ClientBuffComponent self, long buffId)
        {
            if (self.Buffs.TryGetValue(buffId, out ClientBuff buff))
            {
                return buff;
            }

            return null;
        }

        public static void Remove(this ClientBuffComponent self, long buffId)
        {
            ClientBuff clientBuff = self.Get(buffId);
            if (clientBuff == null)
            {
                return;
            }

            self.Buffs.Remove(buffId);
            clientBuff.Dispose();
        }

        public static void Update(this ClientBuffComponent self, BuffProto buffProto)
        {
            ClientBuff clientBuff = self.Get(buffProto.Id);
            if (clientBuff == null)
            {
                return;
            }

            clientBuff.CreateTime = buffProto.CreateTime;
            clientBuff.ExpireTime = buffProto.ExpireTime;
        } 
    }
}