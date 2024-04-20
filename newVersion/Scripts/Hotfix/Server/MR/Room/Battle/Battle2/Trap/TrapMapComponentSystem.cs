namespace ET.Server
{
    [EntitySystemOf(typeof (TrapMapComponent))]
    public static partial class TrapMapComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TrapMapComponent self)
        {
            foreach (int trapId in TrapConfigCategory.Instance.GetAll().Keys)
            {
                self.CreateTrap(trapId);
            }
        }

        public static Unit CreateTrap(this TrapMapComponent self, int trapId)
        {
            Unit unit = UnitFactory.CreateTrap(self.Scene(), trapId);
            return unit;
        }

    }
}