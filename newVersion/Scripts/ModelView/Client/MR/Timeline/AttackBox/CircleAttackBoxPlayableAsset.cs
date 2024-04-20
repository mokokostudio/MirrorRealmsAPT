using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace ET.Client
{
    [DisplayName("圆形攻击盒子")]
    [Serializable]
    public class CircleAttackBoxPlayableAsset: AAttackBoxPlayableAsset
    {
        [Header("伤害半径")]
        [Range(0.01f, 10)]
        public float radius = 1f;
    }
}