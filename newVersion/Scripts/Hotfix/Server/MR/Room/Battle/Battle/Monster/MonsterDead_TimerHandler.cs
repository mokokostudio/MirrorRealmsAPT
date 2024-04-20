namespace ET
{
    [Invoke(TimerInvokeType.MosnterDeadTimer)]
    public class MonsterDead_TimerHandler: ATimer<Unit>
    {
        protected override void Run(Unit unit)
        {
            Log.Info($"monster dead timer");
            unit?.Dispose();
        }
    }
}