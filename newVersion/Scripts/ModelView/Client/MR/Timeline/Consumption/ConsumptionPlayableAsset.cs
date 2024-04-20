using System;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.Timeline;

namespace ET.Client
{
    [Serializable]
    public class ConsumptionPlayableAsset: PlayableAsset, ITimelineClipAsset
    {
        public ClipCaps clipCaps => ClipCaps.None;

        public SkillConfig.ConsumptionType consumptionType;

        [Header("消耗的数值/数量")]
        public int value1;

        [Header("类型为Item时, 表示消耗的物品id")]
        public int value2;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return Playable.Create(graph);
        }
    }
}