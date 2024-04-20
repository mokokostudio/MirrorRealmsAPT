﻿namespace ET.Client
{
    [ChildOf(typeof (ClientBuffComponent))]
    public class ClientBuff: Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public BuffConfig Config => BuffConfigCategory.Instance.Get(this.ConfigId);

        public Unit Owner { get; set; }

        public long CreateTime;

        public long ExpireTime;
    }
}