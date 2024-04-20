// using System;
// using Unity.Mathematics;
//
// namespace ET.Server
// {
//     public static partial class UnitFactory
//     {
//         public static Unit Create(Scene scene, long id, UnitType unitType)
//         {
//             UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
//             switch (unitType)
//             {
//                 case UnitType.Player:
//                 {
//                     Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
//                     unit.AddComponent<MoveComponent>();
//                     unit.Position = new float3(-10, 0, -10);
//
//                     NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
//
//                     numericComponent.Set(NumericType.MaxHpBase, 100);
//                     numericComponent.Set(NumericType.MaxHpAdd, 100);
//                     numericComponent.Set(NumericType.MaxHpPct, 100f);
//                     numericComponent.Set(NumericType.Hp, numericComponent.GetAsInt(NumericType.MaxHp));
//                     numericComponent.Set(NumericType.Speed, 4f);
//                     numericComponent.Set(NumericType.AOI, 15000); // 视野
//
//                     unitComponent.Add(unit);
//                     // 加入aoi
//                     unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
//                     unit.AddComponent<CastComponent>();
//                     unit.AddComponent<BuffComponent>();
//                     return unit;
//                 }
//                 default:
//                     throw new Exception($"not such unit type: {unitType}");
//             }
//         }
//     }
// }