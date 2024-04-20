using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class UnitWeaponChanged_ChangeView: AEvent<Scene, UnitWeaponChanged>
    {
        protected override async ETTask Run(Scene scene, UnitWeaponChanged a)
        {
            a.Unit.GetComponent<PlayerAnimationComponent>()?.ChangeWeapon(a.ArmWeaponMode);
            
            await ETTask.CompletedTask;
        }
    }
}