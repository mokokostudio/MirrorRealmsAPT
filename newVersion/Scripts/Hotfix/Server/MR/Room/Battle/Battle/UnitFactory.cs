using System;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOfAttribute(typeof (ProjectileComponent))]
    public static partial class UnitFactory
    {
        public static Unit CreatePlayer(Scene scene, long id)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
            //
            unit.AddComponent<MrPlayerInfo, string>($"Player{id}");
            //
            unit.AddComponent<MoveComponent>();
            unit.Position = new float3(0, 0, 0);

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

            numericComponent.Set(NumericType.MaxHpBase, 100);
            numericComponent.Set(NumericType.HpBase, numericComponent.GetAsInt(NumericType.MaxHp));

            numericComponent.Set(NumericType.SpeedBase, 4f);

            numericComponent.Set(NumericType.AOI, 15000); // 视野

            numericComponent.Set(NumericType.AttackBase, 0);

            numericComponent.Set(NumericType.DamageReduction, 0);
            // skill point
            numericComponent.Set(NumericType.MaxSpBase, 100);
            numericComponent.Set(NumericType.SpBase, numericComponent.GetAsInt(NumericType.MaxSp));
            // slide point
            numericComponent.Set(NumericType.MaxSlidePointBase, 200);
            numericComponent.Set(NumericType.SlidePointBase, numericComponent.GetAsInt(NumericType.MaxSlidePoint));

            // 先设置为无武器
            var armWeapon = unit.AddComponent<MrArmWeaponComponent, ArmWeaponMode>(ArmWeaponMode.Unarmed);
            // 切换武器, 应用武器的属性
            armWeapon.ChangeWeapon(ArmWeaponMode.GreatSword, false);

            unitComponent.Add(unit);
            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            //
            unit.AddComponent<CastComponent>();
            unit.AddComponent<BuffComponent>();
            unit.AddComponent<SkillStatusComponent>();
            //
            unit.AddComponent<SkillComponent>();
            unit.AddComponent<BuffComponent2>();
            //
            unit.AddComponent<InventoryComponent>();
            //
            unit.AddComponent<SlidePointRecovery>();

            return unit;
        }

        public static Unit CreateProjectile(Scene scene, long ownerId, int unitConfigId, int projectileId, float3 pos, quaternion rotation)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, int>(unitConfigId);
            unit.Position = pos;
            unit.Rotation = rotation;

            unit.AddComponent<CastComponent>();
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<PathfindingComponent, string>(scene.Name);

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.Speed, 6f);
            numericComponent.Set(NumericType.AOI, 15000);

            ProjectileComponent projectileComponent = unit.AddComponent<ProjectileComponent, int>(projectileId);
            projectileComponent.OwnerId = ownerId;
            unitComponent.Add(unit);

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            return unit;
        }

        public static Unit CreateMonster(Scene scene, int unitConfigId, int monsterId, float3 pos)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, int>(unitConfigId);
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<PathfindingComponent, string>(scene.Name);
            unit.Position = pos;

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.Speed, 6.0f);
            numericComponent.Set(NumericType.AOI, 15000);

            var maxHp = MonsterConfigCategory.Instance.Get(monsterId).HP;
            numericComponent.Set(NumericType.MaxHpBase, maxHp);
            numericComponent.Set(NumericType.HpBase, numericComponent.GetAsInt(NumericType.MaxHp));

            unit.AddComponent<ReliveComponent>();
            unit.AddComponent<CastComponent>();
            unit.AddComponent<BuffComponent>();
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            //
            unit.AddComponent<SkillComponent>();
            unit.AddComponent<BuffComponent2>();

            unitComponent.Add(unit);
            return unit;
        }

        public static Unit CreatePickable(Scene scene, int pickableConfigId, float3 pos)
        {
            var pickableConfig = PickableConfigCategory.Instance.Get(pickableConfigId);

            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, int>(pickableConfig.UnitId);
            unit.Position = pos;

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            unitComponent.Add(unit);

            unit.AddComponent<PickableComponent, int>(pickableConfigId);
            return unit;
        }

        public static Unit CreateTrap(Scene scene, int trapId)
        {
            var trapConfig = TrapConfigCategory.Instance.Get(trapId);

            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, int>(trapConfig.UnitConfigId);
            unit.AddComponent<Trap, int>(trapId);

            unit.Position = new float3(trapConfig.x, 0, trapConfig.z);
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            unitComponent.Add(unit);
            return unit;
        }

        public static Unit CreateTreasure(Scene scene, int treasureConfigId, float3 pos, quaternion rotation)
        {
            TreasureConfig config = TreasureConfigCategory.Instance.Get(treasureConfigId);
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, int>(config.UnitConfigId);
            unit.Position = pos;
            unit.Rotation = rotation;

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.MaxHpBase, 1);
            numericComponent.Set(NumericType.HpBase, numericComponent.GetAsInt(NumericType.MaxHp));
            numericComponent.Set(NumericType.AOI, 15000);

            unit.AddComponent<TreasureComponent, int>(treasureConfigId);

            unitComponent.Add(unit);

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            return unit;
        }
    }
}