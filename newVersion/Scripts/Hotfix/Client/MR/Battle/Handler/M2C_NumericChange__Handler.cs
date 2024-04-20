namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_NumericChange__Handler: MessageHandler<Scene, M2C_NumericChange>
    {
        protected override async ETTask Run(Scene root, M2C_NumericChange message)
        {
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

            NumericComponent numCom = unit.GetComponent<NumericComponent>();
            foreach ((int numericType, long newValue) in message.KV)
            {
                var oldValue = numCom[numericType];
#if UNITY_EDITOR
                Log.Info($"{message.UnitId} NumericChange: [{numericType}] | {oldValue} -> {newValue}");
#endif
                numCom.Set(numericType, newValue);

                switch (numericType)
                {
                    case NumericType.Attack:
                    case NumericType.DamageReduction:
                    case NumericType.Speed:
                    {
                        var e = new EventType.NumericChanged()
                        {
                            UnitId = message.UnitId, NumericType = numericType, OldValue = oldValue, NewValue = newValue
                        };
                        EventSystem.Instance.PublishAsync(root.CurrentScene(), e).Coroutine();
                        break;
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}