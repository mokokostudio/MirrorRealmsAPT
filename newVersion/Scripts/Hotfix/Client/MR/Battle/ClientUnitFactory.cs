namespace ET.Client
{
    public static partial class ClientUnitFactory
    {
        public static Unit CreateFXUnit(Scene scene)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, int>(5001);
            unitComponent.Add(unit);
            unit.AddComponent<ObjectWait>();

            return unit;
        }
    }
} 