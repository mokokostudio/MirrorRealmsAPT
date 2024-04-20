// namespace ET.Server
// {
//     [MessageLocationHandler(SceneType.Map)]
//     public class C2M_PathfindingResultHandler: MessageLocationHandler<Unit, C2M_PathfindingResult>
//     {
//         protected override async ETTask Run(Unit unit, C2M_PathfindingResult message)
//         {
//             Log.Info($"客户端({unit.Id})申请移动位置到: {message.Position}");
//
//             var num = unit.GetComponent<NumericComponent>();
//             if (num != null)
//             {
//                 if (num[NumericType.ForbidMove] > 0)
//                 {
//                     Log.Info($"当前无法移动");
//                     return;
//                 }
//             }
//
//             var skillComponent = unit.GetComponent<SkillComponent>();
//             if (skillComponent != null)
//             {
//                 skillComponent.OnPlayerMoved();
//             }
//
//             unit.FindPathMoveToAsync(message.Position).Coroutine();
//             await ETTask.CompletedTask;
//         }
//     }
// }