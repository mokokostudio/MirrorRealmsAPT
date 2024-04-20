﻿namespace ET.Server
{
    [ChildOf(typeof (BuffComponent2))]
    public class MovementSpeedModifyBuff: Entity, IAwake<float, float>, IDestroy
    {
        public long TimerId;
        public float DurationSecond;
        public float ModifyPercent;
    }
}