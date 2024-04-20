namespace ET.Server
{
    [EntitySystemOf(typeof (MonsterComponent))]
    [FriendOfAttribute(typeof (MonsterComponent))]
    public static partial class MonsterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MonsterComponent self, int configId, int monsterGroupConfigId)
        {
            self.ConfigId = configId;
            self.GroupConfigId = monsterGroupConfigId;
        }

        [EntitySystem]
        private static void Destroy(this MonsterComponent self)
        {
            self.ConfigId = default;
            self.GroupConfigId = default;
            // self.Root().GetComponent<MonsterMapComponent>().OnMonsterDead(self.ConfigId, self.GroupConfigId);
        }
    }
}