namespace ET.Server
{
    public static class MrTransferHelper
    {
        public static async ETTask TransferAtFrameFinish(Unit unit, ActorId sceneInstanceId)
        {
            await unit.Fiber().WaitFrameFinish();

            await Transfer(unit, sceneInstanceId);
        }

        private static async ETTask Transfer(Unit unit, ActorId sceneInstanceId)
        {
            Scene root = unit.Root();

            // location加锁
            long unitId = unit.Id;

            M2M_UnitTransferRequest request = M2M_UnitTransferRequest.Create();
            request.OldActorId = unit.GetActorId();
            request.Unit = unit.ToBson();
            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity.ToBson());
                }
            }

            unit.Dispose();

            await root.GetComponent<LocationProxyComponent>().Lock(LocationType.Unit, unitId, request.OldActorId);
            await root.GetComponent<MessageSender>().Call(sceneInstanceId, request);
        }
    }
}