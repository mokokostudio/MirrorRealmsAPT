using System;
using System.ComponentModel;
using UnityEngine;

namespace ET.Client
{
    [DisplayName("矩形攻击盒子")]
    [Serializable]
    public class RectangleAttackBoxPlayableAsset: AAttackBoxPlayableAsset
    {
        [Header("伤害宽(左右)")]
        [Range(0.01f, 10)]
        public float width = 1;

        [Header("伤害长(距离,前后)")]
        [Range(0.01f, 10)]
        public float length = 1;
    }
}