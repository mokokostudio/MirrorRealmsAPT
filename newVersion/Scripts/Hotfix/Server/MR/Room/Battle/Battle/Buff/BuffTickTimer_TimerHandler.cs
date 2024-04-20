namespace ET.Server
{
    [Invoke(TimerInvokeType.BuffTickTimer)]
    public class BuffTickTimer_TimerHandler: ATimer<Buff>
    {
        protected override void Run(Buff buff)
        {
            buff.ExecuteTickBehaviors();
        }
    }
}