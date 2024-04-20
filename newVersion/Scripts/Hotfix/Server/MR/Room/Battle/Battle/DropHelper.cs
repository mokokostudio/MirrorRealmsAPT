using System;
using System.Collections.Generic;
using System.Linq;
using DotRecast.Core;
using Unity.Mathematics;

namespace ET.Server
{
    public static class DropHelper
    {
        public static void Drop(Unit unit)
        {
            switch (unit.UnitType())
            {
                case UnitType.Monster:
                {
                    var monsterComponent = unit.GetComponent<MonsterComponent>();
                    DropByGroup(unit.Scene(), monsterComponent.Config.DropGroupId, unit.Position);
                    break;
                }
                case UnitType.Player:
                {
                    break;
                }
                case UnitType.Treasure:
                {
                    var treasureComponent = unit.GetComponent<TreasureComponent>();
                    DropByGroup(unit.Scene(), treasureComponent.Config.DropGroupId, unit.Position);
                    break;
                }
            }
        }

        private static void DropByGroup(Scene scene, int dropGroupId, float3 spawnPosition)
        {
            var dropGroup = DropGroupConfigCategory.Instance.Get(dropGroupId);

            // <itemId, count>
            var droppedItems = ListComponent<Tuple<int, int>>.Create();
            dropGroup.DropIdList.ForEach(dropConfigId =>
            {
                var config = DropConfigCategory.Instance.Get(dropConfigId);

                var randomValue = RandomGenerator.RandFloat01();
                var change = float.Parse(config.Change);
                if (randomValue < change)
                {
                    droppedItems.Add(new Tuple<int, int>(config.ItemId, config.Count));
                }
            });

            var offsetGenerator = GetOffsetGenerator();
            foreach (var tuple in droppedItems)
            {
                for (int i = 0; i < tuple.Item2; ++i)
                {
                    offsetGenerator.MoveNext();
                    var offset = offsetGenerator.Current;
                    var pos = spawnPosition + offset;
                    var unit = UnitFactory.CreatePickable(scene, tuple.Item1, pos);
                    var message = new MrM2C_Drop() { UintId = unit.Id, SpawnPosition = spawnPosition, TargetPosition = pos, };

                    MrMapMessageHelper.Broadcast(unit, message, true);
                }
            }

            // 生成掉落坐标, 只能处理单次掉落不重叠的情况
            IEnumerator<float3> GetOffsetGenerator()
            {
                using var records = ListComponent<float3>.Create();

                // 最多可以生成 (pi * range^2 ) / ( minDistance^2) 个坐标
                // range = 3, minDistance = 1, 可以生成约 28 个坐标
                // range = 3, minDistance = 1.2, 可以生成约 20 个坐标
                const float range = 3f;
                const float minDistance = 0.75f;
                const float minDistanceSqr = minDistance * minDistance;
                const int maxAttempts = 100;

                while (true)
                {
                    records.Clear();
                    int tryCount = 0;
                    while (tryCount < maxAttempts)
                    {
                        tryCount++;
                        
                        float3 pos = GenRandomPos(range);

                        var isTooClose = records.Any(record => math.distancesq(record, pos) < minDistanceSqr);
                        if (isTooClose)
                        {
                            continue;
                        }

                        records.Add(pos);
                        yield return pos;
                        break;
                    }
                }
            }
        }

        private static float3 GenRandomPos(float range)
        {
            var distance = RandomGenerator.RandFloat01() * range; // 随机偏移距离
            var angle = RandomGenerator.RandFloat01() * 2 * math.PI; // 随机角度

            var x = distance * math.cos(angle);
            var z = distance * math.sin(angle);

            var pos = new float3(x, 0, z);
            return pos;
        }
    }
}