using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    [FriendOfAttribute(typeof (ET.MrArmWeaponComponent))]
    public class M2C_ChangeWeapon__Handler: MessageHandler<Scene, M2C_ChangeWeapon>
    {
        protected override async ETTask Run(Scene entity, M2C_ChangeWeapon message)
        {
            Log.Info($"切换武器: {message.UnitId} {message.ArmWeaponMode}");
            UnitComponent unitComponent = entity.CurrentScene().GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return;
            }

            Unit unit = unitComponent.Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            unit.GetComponent<MrArmWeaponComponent>().Mode = (ArmWeaponMode)message.ArmWeaponMode;

            EventSystem.Instance.Publish(entity.CurrentScene(),
                new UnitWeaponChanged() { Unit = unit, ArmWeaponMode = (ArmWeaponMode)message.ArmWeaponMode, });

            await ETTask.CompletedTask;
        }
    }
}