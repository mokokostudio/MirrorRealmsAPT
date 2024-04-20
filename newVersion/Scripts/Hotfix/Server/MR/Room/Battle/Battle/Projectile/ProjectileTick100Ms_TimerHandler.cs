namespace ET.Server
{
    [Invoke(TimerInvokeType.ProjectileTickTimer100Ms)]
    public class ProjectileTick100Ms_TimerHandler: ATimer<ProjectileComponent>
    {
        protected override void Run(ProjectileComponent projectileComponent)
        {
            projectileComponent.OnTick100Ms();
        }
    }
}