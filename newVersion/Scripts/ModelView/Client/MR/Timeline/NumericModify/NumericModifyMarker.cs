using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace ET.Client
{
    [DisplayName("数值改变")]
    [Serializable]
    public class NumericModifyMarker: Marker
    {
        [Header("变化数值类型")]
        public SkillConfig.NumericModifyType numericModifyType;

        [Header("变化百分比")]
        [Range(-1, 1)]
        public float modifyPercent = 0f;
    }
}