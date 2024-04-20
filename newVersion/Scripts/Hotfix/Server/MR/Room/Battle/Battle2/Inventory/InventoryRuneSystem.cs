// using Unity.Mathematics;
//
// namespace ET.Server
// {
//     [Invoke(TimerInvokeType.RuneFlashTimer)]
//     public class AutoPickTickInterval_TimerHandler: ATimer<InventoryRune>
//     {
//         protected override void Run(InventoryRune c)
//         {
//             c.OnFlashTimer();
//         }
//     }
//
//     [EntitySystemOf(typeof (InventoryRune))]
//     [FriendOf(typeof (InventoryRune))]
//     public static partial class InventoryRuneSystem
//     {
//         [EntitySystem]
//         private static void Awake(this InventoryRune self, int configId)
//         {
//             self.ConfigId = configId;
//             self.FlashTimer = 0;
//             self.IsForbidMoveSet = false;
//         }
//
//         [EntitySystem]
//         private static void Destroy(this InventoryRune self)
//         {
//             self.Root().GetComponent<TimerComponent>().Remove(ref self.FlashTimer);
//
//             if (self.IsForbidMoveSet)
//             {
//                 var unit = self.GetParent<Inventory>().GetParent<InventoryComponent>().GetParent<Unit>();
//                 unit.GetComponent<NumericComponent>()[NumericType.ForbidMove]--;
//             }
//
//             self.IsForbidMoveSet = false;
//             self.FlashTimer = default;
//             self.ConfigId = default;
//         }
//
//         public static void Use(this InventoryRune self)
//         {
//             // TODO: 临时做法, 后续改成技能(自带锁定等逻辑, 但是需要新加Timeline支持这些效果)会更好
//
//             var unit = self.GetParent<Inventory>().GetParent<InventoryComponent>().GetParent<Unit>();
//             var runeType = (ItemSubType_RuneType)self.Config.RuneType;
//             switch (runeType)
//             {
//                 case ItemSubType_RuneType.Ghost:
//                     unit.GetComponent<BuffComponent2>().AddMovementSpeedModifyBuff(10f, 1f);
//                     break;
//                 case ItemSubType_RuneType.Heal:
//                 {
//                     var numericComponent = unit.GetComponent<NumericComponent>();
//                     long oldHp = numericComponent[NumericType.Hp];
//                     long tarHp = oldHp + numericComponent[NumericType.MaxHp] / 2;
//                     numericComponent[NumericType.HpBase] = math.clamp(tarHp, 0, numericComponent[NumericType.MaxHp]);
//                     break;
//                 }
//
//                 case ItemSubType_RuneType.Flash:
//                 {
//                     unit.Stop(0);
//                     unit.GetComponent<NumericComponent>()[NumericType.ForbidMove]++;
//                     self.IsForbidMoveSet = true;
//
//                     self.FlashTimer = unit.Root().GetComponent<TimerComponent>()
//                             .NewOnceTimer(TimeInfo.Instance.ServerNow() + 100, TimerInvokeType.RuneFlashTimer, self);
//
//                     break;
//                 }
//             }
//         }
//
//         public static void OnFlashTimer(this InventoryRune self)
//         {
//             var unit = self.GetParent<Inventory>().GetParent<InventoryComponent>().GetParent<Unit>();
//             var position = unit.Position;
//             var direction = unit.Forward;
//             var distance = 6f;
//             var targetPosition = position + direction * distance;
//             targetPosition.y = 0;
//             unit.Position = targetPosition;
//
//             M2C_SetPosition msg = new() { UnitId = unit.Id, Position = unit.Position, Rotation = unit.Rotation };
//             MapMessageHelper.Broadcast(unit, msg);
//
//             unit.GetComponent<NumericComponent>()[NumericType.ForbidMove]--;
//             self.IsForbidMoveSet = false;
//         }
//     }
// }