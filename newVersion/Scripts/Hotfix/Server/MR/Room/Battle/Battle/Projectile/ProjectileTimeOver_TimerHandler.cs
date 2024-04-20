namespace ET.Server
{
    [Invoke(TimerInvokeType.ProjectileTotalTimer)]
    public class ProjectileTimeOver_TimerHandler: ATimer<ProjectileComponent>
    {
        protected override void Run(ProjectileComponent projectileComponent)
        {
            projectileComponent.OnTimeOver();
        }
    }
}