namespace ET.Server
{
    [FriendOfAttribute(typeof (MrArmWeaponComponent))]
    public static class ArmWeaponHelper
    {
        public static void ChangeWeapon(this MrArmWeaponComponent self, ArmWeaponMode armWeapon, bool publishEvent = true)
        {
            var unit = self.GetParent<Unit>();
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            var oldModifyPercent = WeaponConfigCategory.Instance.Get((int)self.Mode).MovementSpeedModifier;
            numericComponent[NumericType.SpeedPct] -= oldModifyPercent * 10000;

            self.Mode = armWeapon;
            var newModifyPercent = WeaponConfigCategory.Instance.Get((int)self.Mode).MovementSpeedModifier;
            numericComponent[NumericType.SpeedPct] += newModifyPercent * 10000;

            numericComponent.Set(NumericType.AttackBase, WeaponConfigCategory.Instance.Get((int)self.Mode).Damage);

            if (publishEvent)
            {
                M2C_ChangeWeapon msg = new() { UnitId = unit.Id, ArmWeaponMode = (uint)self.Mode };
                MrMapMessageHelper.SendClient(unit, msg, NoticeClientType.Broadcast);
            }
        }
    }
}