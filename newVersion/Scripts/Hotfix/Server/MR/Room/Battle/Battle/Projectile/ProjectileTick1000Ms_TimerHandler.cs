namespace ET.Server
{
    [Invoke(TimerInvokeType.ProjectileTickTimer1000Ms)]
    public class ProjectileTick1000Ms_TimerHandler: ATimer<ProjectileComponent>
    {
        protected override void Run(ProjectileComponent projectileComponent)
        {
            projectileComponent.OnTick1000Ms();
        }
    }
}