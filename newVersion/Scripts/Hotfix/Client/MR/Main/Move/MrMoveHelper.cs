using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public static class MrMoveHelper
    {
        // 可以多次调用，多次调用的话会取消上一次的协程
        public static async ETTask<int> MoveToAsync(this Unit unit, float3 targetPos, ETCancellationToken cancellationToken = null)
        {
            C2M_PathfindingResult msg = new C2M_PathfindingResult() { Position = targetPos };
            unit.Root().GetComponent<MrClientSenderCompnent>().Send(msg);

            ObjectWait objectWait = unit.GetComponent<ObjectWait>();
            
            // 要取消上一次的移动协程
            objectWait.Notify(new MrWait_UnitStop() { Error = WaitTypeError.Cancel });
            
            // 一直等到unit发送stop
            MrWait_UnitStop mrWaitUnitStop = await objectWait.Wait<MrWait_UnitStop>(cancellationToken);
            if (cancellationToken.IsCancel())
            {
                return WaitTypeError.Cancel;
            }
            return mrWaitUnitStop.Error;
        }
        
        public static async ETTask MoveToAsync(this Unit unit, List<float3> path)
        {
            float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            await moveComponent.MoveToAsync(path, speed);
        }
    }
}