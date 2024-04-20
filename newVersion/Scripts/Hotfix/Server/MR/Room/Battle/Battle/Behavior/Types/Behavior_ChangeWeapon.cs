namespace ET.Server
{
    [Behavior(BehaviorType.ChangeWeapon)]
    [FriendOfAttribute(typeof (Cast))]
    [FriendOfAttribute(typeof (MrArmWeaponComponent))]
    [FriendOfAttribute(typeof (NumericComponent))]
    public class Behavior_ChangeWeapon: IBehavior
    {
        public void Run(Behavior behavior, BehaviorRunType behaviorRunType)
        {
            Cast cast = behavior.CastSelf;

            if (cast == null || cast.IsDisposed || behaviorRunType != BehaviorRunType.CastImpact)
            {
                return;
            }

            Unit caster = cast.Caster;
            if (caster == null || caster.IsDisposed)
            {
                return;
            }

            MrArmWeaponComponent mrArmWeaponComponent = caster.GetComponent<MrArmWeaponComponent>();
            mrArmWeaponComponent?.ChangeWeapon((ArmWeaponMode)uint.Parse(behavior.Config.Params[0]));
        }
    }
}