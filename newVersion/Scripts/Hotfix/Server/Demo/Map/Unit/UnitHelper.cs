// using System.Collections.Generic;
// using System.Linq;
// using Unity.Mathematics;
//
// namespace ET.Server
// {
//     [FriendOf(typeof (MoveComponent))]
//     [FriendOf(typeof (NumericComponent))]
//     [FriendOf(typeof (PlayerInfo))]
//     [FriendOf(typeof (ArmWeaponComponent))]
//     [FriendOf(typeof (InventoryItem))]
//     [FriendOf(typeof (InventoryComponent))]
//     public static partial class UnitHelper
//     {
//         public static UnitInfo CreateUnitInfo(Unit unit, bool isMyUnit)
//         {
//             UnitInfo unitInfo = new();
//
//             var playerInfo = unit.GetComponent<PlayerInfo>();
//             if (playerInfo != null)
//             {
//                 unitInfo.PlayerInfo = new() { PlayerName = playerInfo.Name, ArmWeaponMode = (uint)unit.GetComponent<ArmWeaponComponent>().Mode, };
//
//                 if (isMyUnit)
//                 {
//                     unitInfo.PlayerInfo.InventoryItems = new();
//
//                     var inventoryComponent = unit.GetComponent<InventoryComponent>();
//                     var inventories = inventoryComponent.Children.Select(child => child.Value as InventoryItem);
//                     foreach (var inventory in inventories)
//                     {
//                         unitInfo.PlayerInfo.InventoryItems.Add(new() { ConfigId = inventory.ConfigId, Count = inventory.Count });
//                     }
//                 }
//             }
//
//             unitInfo.UnitId = unit.Id;
//             unitInfo.ConfigId = unit.ConfigId;
//             unitInfo.Type = (int)unit.UnitType();
//             unitInfo.Position = unit.Position;
//             unitInfo.Forward = unit.Forward;
//
//             MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
//             if (moveComponent != null)
//             {
//                 if (!moveComponent.IsArrived())
//                 {
//                     unitInfo.MoveInfo = new MoveInfo();
//                     unitInfo.MoveInfo.Points.Add(unit.Position);
//                     for (int i = moveComponent.N; i < moveComponent.Targets.Count; ++i)
//                     {
//                         float3 pos = moveComponent.Targets[i];
//                         unitInfo.MoveInfo.Points.Add(pos);
//                     }
//                 }
//             }
//
//             NumericComponent nc = unit.GetComponent<NumericComponent>();
//             if (nc != null)
//             {
//                 foreach ((int key, long value) in nc.NumericDic)
//                 {
//                     unitInfo.KV.Add(key, value);
//                 }
//             }
//
//             return unitInfo;
//         }
//
//         // 获取看见unit的玩家，主要用于广播
//         public static Dictionary<long, AOIEntity> GetBeSeePlayers(this Unit self)
//         {
//             return self.GetComponent<AOIEntity>().GetBeSeePlayers();
//         }
//
//         public static Dictionary<long, AOIEntity> GetSeeUnits(this Unit self)
//         {
//             return self.GetComponent<AOIEntity>().GetSeeUnits();
//         }
//     }
// }