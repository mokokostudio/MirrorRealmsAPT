using System;

namespace ET.Server
{
    [EntitySystemOf(typeof (BuffComponent))]
    [FriendOfAttribute(typeof (BuffComponent))]
    public static partial class BuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BuffComponent self)
        {
            self.AddComponent<BuffTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this BuffComponent self)
        {
            self.CongfigBuffs.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this BuffComponent self)
        {
            self.AddComponent<BuffTempComponent>();

            foreach (Buff buff in self.Children.Values)
            {
                self.CongfigBuffs.Add(buff.ConfigId, buff);
            }
        }

        public static BuffCreateInfo Create(this BuffComponent self, int configId)
        {
            return self.GetComponent<BuffTempComponent>().AddChild<BuffCreateInfo, int>(configId);
        }

        public static bool CreateAndAdd(this BuffComponent self, int configId)
        {
            using (BuffCreateInfo buffCreateInfo = self.Create(configId))
            {
                return self.Add((buffCreateInfo));
            }
        }

        public static bool Add(this BuffComponent self, BuffCreateInfo buffCreateInfo)
        {
            if (self == null || self.IsDisposed)
            {
                return false;
            }

            if (buffCreateInfo == null || buffCreateInfo.IsDisposed)
            {
                return false;
            }

            Buff buff = self.AddChild<Buff, int>(buffCreateInfo.ConfigId);
            buff.Owner = self.GetParent<Unit>();

            if (buff.Owner == null)
            {
                buff.Dispose();
                return false;
            }

            int configId = buff.ConfigId;
            if (self.CongfigBuffs.ContainsKey(configId))
            {
                // 顶掉相同buff
                self.Remove(self.CongfigBuffs[configId].Id);
            }

            self.CongfigBuffs.Add(configId, buff);

            if ((NoticeClientType)buff.Config.NoticeClientType != NoticeClientType.NoNotice)
            {
                M2C_BuffAdd msg = new() { UnitId = buff.Owner.Id, BuffData = buff.ToBuffAddProto() };
                MrMapMessageHelper.SendClient(buff.Owner, msg, (NoticeClientType)buff.Config.NoticeClientType);
            }

            buff.ExecuteAdditionBehaviors();

            return true;
        }

        public static void Remove(this BuffComponent self, long buffId)
        {
            if (!self.Children.TryGetValue(buffId, out Entity entity))
            {
                return;
            }

            Buff buff = entity as Buff;

            try
            {
                self.CongfigBuffs.Remove(buff.ConfigId);

                if ((NoticeClientType)buff.Config.NoticeClientType != NoticeClientType.NoNotice)
                {
                    M2C_BuffRemove msg = new() { BuffId = buff.Id, UnitId = buff.Owner.Id };
                    MrMapMessageHelper.SendClient(buff.Owner, msg, (NoticeClientType)buff.Config.NoticeClientType);
                }

                buff.ExecuteRemovalBehaviors();

                buff.Dispose();
            }
            catch (Exception e)
            {
                Log.Error($"Buff Remove error! buffComponentId: {self.Id}, buffId: {buff.Id}, buffConfigId: {buff.Config?.Id ?? 0}, {e}");
            }
        }
    }
}