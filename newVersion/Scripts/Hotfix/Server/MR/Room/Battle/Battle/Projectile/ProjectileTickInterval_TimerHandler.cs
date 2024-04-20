namespace ET.Server
{
    [Invoke(TimerInvokeType.ProjectileTickTimerInterval)]
    public class ProjectileTickInterval_TimerHandler: ATimer<ProjectileComponent>
    {
        protected override void Run(ProjectileComponent projectileComponent)
        {
            projectileComponent.OnTickInterval();
        }
    }
}