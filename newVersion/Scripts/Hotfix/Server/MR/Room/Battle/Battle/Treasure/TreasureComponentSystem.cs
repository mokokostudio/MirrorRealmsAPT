namespace ET.Server
{
    [EntitySystemOf(typeof (TreasureComponent))]
    [FriendOfAttribute(typeof (TreasureComponent))]
    public static partial class TreasureComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TreasureComponent self, int treasureConfigId)
        {
            self.ConfigId = treasureConfigId;
        }

        [EntitySystem]
        private static void Destroy(this TreasureComponent self)
        {
            self.ConfigId = default;
        }
    }
}