using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (MonsterMapComponent))]
    public static partial class MonsterMapComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MonsterMapComponent self)
        {
            // foreach (int monsterId in MonsterConfigCategory.Instance.GetAll().Keys)
            // {
            //     self.CreateMonster(monsterId);
            // }

            // 临时测试, 创建一个宝箱在场景中
            UnitFactory.CreateTreasure(self.Scene(), 1, new float3(0, 0, 0), quaternion.identity);
        }

        public static Unit CreateMonster(this MonsterMapComponent self, int monsterId)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            MonsterGroupConfig monsterGroupConfig = MonsterGroupConfigCategory.Instance.Get(monsterConfig.MonsterGroupConfigId);

            int halfRange = monsterGroupConfig.Range / 2;

            float x = monsterGroupConfig.PosX + RandomGenerator.RandomNumber(-halfRange, halfRange);
            float y = monsterGroupConfig.PosY;
            float z = monsterGroupConfig.PosZ + RandomGenerator.RandomNumber(-halfRange, halfRange);
            float3 pos = new(x, y, z);

            Unit unit = UnitFactory.CreateMonster(self.Scene(), monsterConfig.UnitConfigId, monsterId, pos);
            unit.AddComponent<MonsterComponent, int, int>(monsterId, monsterConfig.MonsterGroupConfigId);
            return unit;
        }

        public static void OnMonsterDead(this MonsterMapComponent self, int monsterConfigId, int monsterGroupConfigId)
        {
            if (self == null || self.IsDisposed)
            {
                return;
            }

            long spawnTime = TimeInfo.Instance.ServerNow() + MonsterGroupConfigCategory.Instance.Get(monsterGroupConfigId).ReliveTime;
            CreateMonsterInfo createMonsterInfo = self.AddChild<CreateMonsterInfo, int>(monsterConfigId);
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();

            timerComponent.NewOnceTimer(spawnTime, TimerInvokeType.SpwanMonsterTimer, createMonsterInfo);
        }
    }
}