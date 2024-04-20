namespace ET
{
    [ComponentOf(typeof (Unit))]
    public class MrArmWeaponComponent: Entity, IAwake<ArmWeaponMode>, ISerializeToEntity
    {
        public ArmWeaponMode Mode;
    }
}