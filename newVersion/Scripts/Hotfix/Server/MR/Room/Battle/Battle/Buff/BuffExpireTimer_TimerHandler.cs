namespace ET.Server
{
    [Invoke(TimerInvokeType.BuffExpireTimer)]
    public class BuffExpireTimer_TimerHandler: ATimer<Buff>
    {
        protected override void Run(Buff buff)
        {
            buff.TimeOUt();
        }
    }
}