using System;

namespace ET.Server
{
    [EntitySystemOf(typeof (Buff))]
    [FriendOfAttribute(typeof (Buff))]
    public static partial class BuffSystem
    {
        [EntitySystem]
        private static void Awake(this Buff self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<BehaviorTempComponent>();

            self.CreateTime = TimeInfo.Instance.ServerNow();

            if (self.Config.TotalTime <= 0)
            {
                self.SetExpireTime(0);
            }
            else
            {
                self.SetExpireTime(self.CreateTime + self.Config.TotalTime);
            }

            self.SetTickTIme(self.Config.TickInterval);
        }

        [EntitySystem]
        private static void Deserialize(this Buff self)
        {
            self.AddComponent<BehaviorTempComponent>();
            self.Owner = self.Parent.GetParent<Unit>();
        }

        [EntitySystem]
        private static void Destroy(this Buff self)
        {
            self.ConfigId = default;
            self.Owner = default;
            self.CreateTime = default;
            self.TickTime = default;
            self.TickBeginTime = default;
            self.ExpireTime = default;

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.TickTimer);
            timerComponent.Remove(ref self.waitTickTimer);
            timerComponent.Remove(ref self.ExpireTimer);
        }

        public static void SetExpireTime(this Buff self, long expireTime, bool noticeClient = false)
        {
            if (expireTime <= 0)
            {
                self.ExpireTime = 0;
                if (noticeClient)
                {
                    self.NoticeClientUpdateInfo();
                }

                return;
            }

            if (self.ExpireTime == expireTime)
            {
                return;
            }

            self.ExpireTime = expireTime;
            if (noticeClient)
            {
                self.NoticeClientUpdateInfo();
            }

            if (self.ExpireTime > 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.ExpireTimer);
            }

            self.ExpireTimer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(self.ExpireTime, TimerInvokeType.BuffExpireTimer, self);
        }

        public static void SetTickTIme(this Buff self, int tickTime)
        {
            if (tickTime > 0)
            {
                self.TickBeginTime = TimeInfo.Instance.ServerNow();
                self.TickTime = tickTime;

                self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer);

                self.TickTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(tickTime, TimerInvokeType.BuffTickTimer, self);
            }
        }

        public static void NoticeClientUpdateInfo(this Buff self)
        {
            M2C_BuffUpdate msg = new() { UnitId = self.Owner.Id, BuffData = self.ToBuffAddProto() };
            MrMapMessageHelper.SendClient(self.Owner, msg, (NoticeClientType)self.Config.NoticeClientType);
        }

        public static void ExecuteAdditionBehaviors(this Buff self)
        {
            EntityRef<Buff> buffRef = self;// buff 可能在执行过程中被移除

            foreach (int id in self.Config.AdditionBehaviors)
            {
                try
                {
                    self.CreateBehavior(id, BehaviorRunType.BuffAdd);

                    if ((Buff)buffRef == null)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Log.Error(
                        $"Buff::AddBehaviors error, OwnerId: {self.Owner?.Id ?? 0}, buffId: {self.Id}, buffConfigId: {self.ConfigId}, behaviorId: {id}, exception: {e}");
                }
            }
        }

        public static void ExecuteRemovalBehaviors(this Buff self)
        {
            EntityRef<Buff> buffRef = self;// buff 可能在执行过程中被移除

            foreach (int id in self.Config.RemovalBehaviors)
            {
                try
                {
                    self.CreateBehavior(id, BehaviorRunType.BuffRemove);

                    if ((Buff)buffRef == null)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Log.Error(
                        $"Buff::RemoveBehaviors error, OwnerId: {self.Owner?.Id ?? 0}, buffId: {self.Id}, buffConfigId: {self.ConfigId}, behaviorId: {id}, exception: {e}");
                }
            }
        }

        public static BuffProto ToBuffAddProto(this Buff self)
        {
            BuffProto buffProto = new()
            {
                Id = self.Id, ConfigId = self.ConfigId, CreateTime = self.CreateTime, ExpireTime = self.ExpireTime,
            };
            // buffProto.ExtraData = self.ExtraData.ToByteArray();

            return buffProto;
        }

        public static void ExecuteTickBehaviors(this Buff self)
        {
            if (self.IsDisposed)
            {
                return;
            }

            EntityRef<Buff> buffRef = self;// buff 可能在执行过程中被移除
            foreach (int id in self.Config.TickBehaviors)
            {
                try
                {
                    self.CreateBehavior(id, BehaviorRunType.BuffTick);

                    if ((Buff)buffRef == null)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    if ((Buff)buffRef == null)
                    {
                        Log.Error(
                            $"Buff::TickBehaviors error, OwnerId: {self.Owner?.Id ?? 0}, buffId: {self.Id}, buffConfigId: {self.ConfigId}, behaviorId: {id}, exception: {e}");
                    }
                    else
                    {
                        Log.Error($"Buff::TickBehaviors error, OwnerId: {self.Owner?.Id ?? 0}, buffId: {self.Id},  behaviorId: {id}, exception: {e}");
                    }
                }

                if ((Buff)buffRef == null)
                {
                    return;
                }

                if (self.Config.TickBehaviors.Length < 1)
                {
                    continue;
                }

                if (self.Owner == null)
                {
                    return;
                }

                M2C_BuffTick msg = new() { UnitId = self.Owner.Id, BuffId = self.Id };
                MrMapMessageHelper.SendClient(self.Owner, msg, (NoticeClientType)self.Config.NoticeClientType);
            }
        }

        public static void TimeOUt(this Buff self)
        {
            EventSystem.Instance.Publish(self.Root(), new EventType.BuffTimeOut() { Unit = self.Owner, BuffId = self.Id });
        }
    }
}