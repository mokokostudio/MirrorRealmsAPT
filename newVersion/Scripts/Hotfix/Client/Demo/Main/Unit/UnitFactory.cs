// using System.Collections.Generic;
// using Unity.Mathematics;
//
// namespace ET.Client
// {
//     public static partial class UnitFactory
//     {
//         public static Unit Create(Scene currentScene, UnitInfo unitInfo)
//         {
//             UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
//             Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
//             unitComponent.Add(unit);
//
//             unit.Position = unitInfo.Position;
//             unit.Forward = unitInfo.Forward;
//
//             if ((UnitType)unitInfo.Type == UnitType.Pickable)
//             {
//                 unit.AddComponent<ClientPickableComponent, long>(TimeInfo.Instance.ServerNow());
//             }
//             else
//             {
//                 NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
//
//                 foreach (var kv in unitInfo.KV)
//                 {
//                     numericComponent.Set(kv.Key, kv.Value);
//                 }
//
//                 unit.AddComponent<MoveComponent>();
//                 if (unitInfo.MoveInfo != null)
//                 {
//                     if (unitInfo.MoveInfo.Points.Count > 0)
//                     {
//                         unitInfo.MoveInfo.Points[0] = unit.Position;
//                         unit.MoveToAsync(unitInfo.MoveInfo.Points).Coroutine();
//                     }
//                 }
//
//                 unit.AddComponent<ObjectWait>();
//
//                 unit.AddComponent<XunLuoPathComponent>();
//                 unit.AddComponent<ClientCastComponent>();
//                 unit.AddComponent<ClientBuffComponent>();
//                 //
//                 unit.AddComponent<ClientSkillComponent>();
//                 //
//                 bool isMyUnit = unitInfo.UnitId == currentScene.Root().GetComponent<PlayerComponent>().MyId;
//                 if (unitInfo.PlayerInfo != null)
//                 {
//                     unit.AddComponent<PlayerInfo, string>(unitInfo.PlayerInfo.PlayerName);
//                     unit.AddComponent<ArmWeaponComponent, ArmWeaponMode>((ArmWeaponMode)unitInfo.PlayerInfo.ArmWeaponMode);
//                     unit.AddComponent<AutoPickComponent, float>(1f);
//
//                     if (isMyUnit)
//                     {
//                         unit.AddComponent<ClientInventoryComponent, List<InventoryItemProto>>(unitInfo.PlayerInfo.InventoryItems);
//                     }
//                 }
//                 else
//                 {
//                     // 暂时用玩家的模型来做演示
//                     unit.AddComponent<ArmWeaponComponent, ArmWeaponMode>(ArmWeaponMode.SwordShield);
//                 }
//             }
//
//             EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
//             return unit;
//         }
//     }
// }