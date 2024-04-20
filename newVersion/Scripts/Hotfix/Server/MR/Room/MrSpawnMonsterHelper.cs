namespace ET.Server
{
    public static class MrSpawnMonsterHelper
    {
        public static void Spawn(Scene scene, int spawnConfigId, int monsterId, int count)
        {
            using var positionList = ListComponent<int>.Create();
            positionList.AddRange(SpawnConfigCategory.Instance.Get(spawnConfigId).PositionList);

            if (positionList.Count < count)
            {
                Log.Error($"刷新点({spawnConfigId})数量({positionList.Count})低于要求的个数({count}), 怪物刷新的数量将被限制");
            }

            for (int i = 0; i < count && positionList.Count > 0; ++i)
            {
                var index = RandomGenerator.RandomNumber(0, positionList.Count);
                var posisitonId = positionList[index];
                var positionConfig = PositionConfigCategory.Instance.Get(posisitonId);
                var monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
                var unit = UnitFactory.CreateMonster(scene, monsterConfig.UnitConfigId, monsterId, positionConfig.Position);
                unit.AddComponent<MonsterComponent, int, int>(monsterId, monsterConfig.MonsterGroupConfigId);

                positionList.RemoveAt(index);
            }
        }
    }
}