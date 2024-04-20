namespace ET
{
    [EntitySystemOf(typeof (MrArmWeaponComponent))]
    [FriendOfAttribute(typeof (MrArmWeaponComponent))]
    public static partial class ArmWeaponSystem
    {
        [EntitySystem]
        private static void Awake(this MrArmWeaponComponent self, ArmWeaponMode armWeaponMode)
        {
            self.Mode = armWeaponMode;
        }

    }
}