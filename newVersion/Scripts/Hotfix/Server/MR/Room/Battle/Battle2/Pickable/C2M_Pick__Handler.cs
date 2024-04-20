namespace ET.Server
{
    [MessageHandler(SceneType.MrRoom)]
    public class C2M_Pick__Handler: MessageLocationHandler<Unit, MrC2M_Pick, MrM2C_Pick>
    {
        protected override async ETTask Run(Unit unit, MrC2M_Pick request, MrM2C_Pick response)
        {
            var unitComponent = unit.Scene().GetComponent<UnitComponent>();
            Unit target = unitComponent.Get(request.UnitId);
            if (target == null)
            {
                response.Error = ErrorCode.ERR_Pick_UnitIsNull;
                response.Message = $"找不到目标";
                return;
            }

            var pickableComponent = target.GetComponent<PickableComponent>();
            if (pickableComponent == null)
            {
                response.Error = ErrorCode.ERR_Pick_UnitNotPickable;
                response.Message = $"目标不可拾取";
                return;
            }

            var pickableConfig = pickableComponent.Config;
            var ic = unit.GetComponent<InventoryComponent>();
            ic.AddItem(pickableConfig.ItemId, pickableConfig.ItemCount);

            target.Dispose();
            response.Error = ErrorCode.ERR_Success;

            await ETTask.CompletedTask;
        }
    }
}