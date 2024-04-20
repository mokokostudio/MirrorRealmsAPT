namespace ET
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SetPosition__Handler: MessageHandler<Scene, M2C_SetPosition>
    {
        protected override async ETTask Run(Scene root, M2C_SetPosition message)
        {
            Log.Info($"M2C_SetPositionHandler: {message.UnitId} , pos={message.Position}, rotation={message.Rotation}");
            
            UnitComponent unitComponent = root.CurrentScene().GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return;
            }

            Unit unit = unitComponent.Get(message.UnitId);

            if (unit == null)
            {
                return;
            }

            unit.Position = message.Position;
            unit.Rotation = message.Rotation;


            await ETTask.CompletedTask;
        }
    }
}