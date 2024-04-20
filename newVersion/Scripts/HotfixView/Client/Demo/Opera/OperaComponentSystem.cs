// using System.Linq;
// using Cinemachine;
// using Unity.Mathematics;
// using UnityEngine;
//
// namespace ET.Client
// {
//     [EntitySystemOf(typeof (OperaComponent))]
//     [FriendOf(typeof (OperaComponent))]
//     [FriendOfAttribute(typeof (ArmWeaponComponent))]
//     public static partial class OperaComponentSystem
//     {
//         [EntitySystem]
//         private static void Awake(this OperaComponent self)
//         {
//             self.mapMask = LayerMask.GetMask("Map");
//         }
//
//         [EntitySystem]
//         private static void Update(this OperaComponent self)
//         {
//             self.UpdateMovement();
//
//             // if (Input.GetKeyDown(KeyCode.R))
//             // {
//             //     CodeLoader.Instance.Reload();
//             //     return;
//             // }
//
//             if (Input.GetKeyDown(KeyCode.T))
//             {
//                 C2M_TransferMap c2MTransferMap = new();
//                 self.Root().GetComponent<MrClientSenderCompnent>().Call(c2MTransferMap).Coroutine();
//             }
//
//             self.UpdateSkill();
//
//             self.UpdateCamera();
//         }
//
//         private static void UpdateCamera(this OperaComponent self)
//         {
//             if (Input.GetMouseButtonDown(1))
//             {
//                 self.lastMousePosition = Input.mousePosition;
//             }
//
//             if (Input.GetMouseButton(1))
//             {
//                 Vector3 delta = Input.mousePosition - self.lastMousePosition;
//
//                 CinemachineVirtualCamera camera = self.Root().CurrentScene()?.GetComponent<BattleCameraComponent>()?.Camera;
//
//                 if (camera != null)
//                 {
//                     camera.transform.RotateAround(camera.transform.position, Vector3.up, delta.x * 0.1f);
//                 }
//
//                 self.lastMousePosition = Input.mousePosition;
//             }
//
//             if (Input.GetMouseButtonUp(1))
//             {
//                 self.lastMousePosition = Vector3.zero;
//             }
//         }
//
//         private static void UpdateMovement(this OperaComponent self)
//         {
//             float3 moveDir = float3.zero;
//             if (Input.GetKey(KeyCode.W))
//             {
//                 moveDir += new float3(0, 0, 1);
//             }
//             else if (Input.GetKey(KeyCode.S))
//             {
//                 moveDir += new float3(0, 0, -1);
//             }
//
//             if (Input.GetKey(KeyCode.A))
//             {
//                 moveDir += new float3(-1, 0, 0);
//             }
//             else if (Input.GetKey(KeyCode.D))
//             {
//                 moveDir += new float3(1, 0, 0);
//             }
//
//             if (moveDir.Equals(float3.zero))
//             {
//                 return;
//             }
//
//             CinemachineVirtualCamera camera = self.Root().CurrentScene()?.GetComponent<BattleCameraComponent>()?.Camera;
//             if (camera == null)
//             {
//                 return;
//             }
//
//             moveDir = camera.transform.rotation * moveDir;
//
//             moveDir = math.normalize(moveDir);
//
//             var unit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
//             var speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
//             var stepTime = 0.2f;
//             var distance = speed * stepTime;
//             float3 destination = unit.Position + moveDir * distance;
//             MrMoveHelper.MoveToAsync(unit, destination).Coroutine();
//         }
//
//         private static void UpdateSkill(this OperaComponent self)
//         {
//             if (Input.GetKeyDown(KeyCode.F1))
//             {
//                 self.ChangeWeapon();
//             }
//
//             if (Input.GetKeyDown(KeyCode.F2))
//             {
//             }
//
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 self.CastAttakSkill();
//             }
//
//             if (Input.GetKeyDown(KeyCode.Q))
//             {
//                 self.CastWeaponSkill(0);
//             }
//
//             if (Input.GetKeyDown(KeyCode.E))
//             {
//                 self.CastWeaponSkill(1);
//             }
//
//             if (Input.GetKeyDown(KeyCode.R))
//             {
//                 self.CastWeaponSkill(2);
//             }
//
//             if (Input.GetKeyDown(KeyCode.F))
//             {
//                 self.CastSlideSkill();
//             }
//
//             // test
//             for (int i = 1; i < 10; i++)
//             {
//                 if (!Input.GetKeyDown(KeyCode.Alpha0 + i))
//                 {
//                     continue;
//                 }
//
//                 self.CastSkill($"Girl_GreatSword_S_{i}");
//                 break;
//             }
//         }
//
//         private static void ChangeWeapon(this OperaComponent self)
//         {
//             var myUnit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
//             var armWeaponMode = myUnit.GetComponent<ArmWeaponComponent>().Mode;
//
//             // 背包内的所有武器
//             using var clientInventoryItems = ListComponent<ClientInventoryItem>.Create();
//             clientInventoryItems.AddRange(myUnit.GetComponent<ClientInventoryComponent>().Children
//                     .Select(icChild => icChild.Value as ClientInventoryItem)
//                     .Where(v => v.ItemType == InventoryType.Weapon));
//
//             clientInventoryItems.Sort((a, b) => (int)(a.Id - b.Id));
//             // 根据Id大小依次切换
//             var currentWeaponIndex = clientInventoryItems.FindIndex(v => v.Config.SubConfigId == (int)armWeaponMode);
//             var nextWeaponIndex = 0;
//             // 已经是最后一把武器, 切至第一把
//             if (currentWeaponIndex >= clientInventoryItems.Count - 1)
//             {
//                 nextWeaponIndex = 0;
//             }
//             else
//             {
//                 nextWeaponIndex = currentWeaponIndex + 1;
//             }
//
//             var equipItem = clientInventoryItems[nextWeaponIndex];
//             if (equipItem == null)
//             {
//                 return;
//             }
//
//             var weaponConfig = WeaponConfigCategory.Instance.Get(equipItem.Config.SubConfigId);
//             self.CastSkill(weaponConfig.EquipSkill);
//         }
//
//         private static void CastCast(this OperaComponent self, int skillId)
//         {
//             ClientCastHelper.CastCast(self.Root(), skillId).Coroutine();
//         }
//
//         private static void CastSkill(this OperaComponent self, string skillName)
//         {
//             ClientCastHelper.CastSkill(self.Root(), skillName).Coroutine();
//         }
//
//         private static void CastAttakSkill(this OperaComponent self)
//         {
//             var myUnit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
//             if (myUnit == null)
//             {
//                 return;
//             }
//
//             var clientSkillComponent = myUnit.GetComponent<ClientSkillComponent>();
//             if (clientSkillComponent == null)
//             {
//                 return;
//             }
//
//             var armWeaponMode = myUnit.GetComponent<ArmWeaponComponent>().Mode;
//             var weaponConfig = WeaponConfigCategory.Instance.Get((int)armWeaponMode);
//
//             var comboSkills = weaponConfig.Attack;
//
//             var index = 0;
//             var skillCount = comboSkills.Length;
//             while (index < skillCount)
//             {
//                 var skillName = comboSkills[index];
//                 if (clientSkillComponent.IsCasting(skillName))
//                 {
//                     var nextIndex = index + 1;
//
//                     if (nextIndex >= comboSkills.Length)
//                     {
//                         // 如果已经是最后一个技能了, 就不要再切换了
//                         break;
//                     }
//
//                     skillName = comboSkills[nextIndex];
//
//                     self.CastSkill(skillName);
//                     break;
//                 }
//
//                 index++;
//
//                 if (index < skillCount)
//                 {
//                     continue;
//                 }
//
//                 // 没有正在释放的技能, 就释放第一个技能
//                 self.CastSkill(comboSkills[0]);
//                 break;
//             }
//         }
//
//         private static void CastWeaponSkill(this OperaComponent self, int index)
//         {
//             var myUnit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
//             if (myUnit == null)
//             {
//                 return;
//             }
//
//             var armWeaponMode = myUnit.GetComponent<ArmWeaponComponent>().Mode;
//             var weaponConfig = WeaponConfigCategory.Instance.Get((int)armWeaponMode);
//             if (index >= weaponConfig.Skills.Length)
//             {
//                 Log.Error($"没有找到对应的技能: weapon={armWeaponMode}, index={index}");
//                 return;
//             }
//
//             var skillName = weaponConfig.Skills[index];
//             self.CastSkill(skillName);
//         }
//
//         private static void CastSlideSkill(this OperaComponent self)
//         {
//             var myUnit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
//             if (myUnit == null)
//             {
//                 return;
//             }
//
//             var armWeaponMode = myUnit.GetComponent<ArmWeaponComponent>().Mode;
//             var weaponConfig = WeaponConfigCategory.Instance.Get((int)armWeaponMode);
//
//             var skillName = weaponConfig.Slide;
//             self.CastSkill(skillName);
//         }
//     }
// }