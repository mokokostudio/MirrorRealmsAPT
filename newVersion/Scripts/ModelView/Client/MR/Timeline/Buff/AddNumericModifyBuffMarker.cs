using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace ET.Client
{
    [DisplayName("数值改变buff")]
    [Serializable]
    public class AddNumericModifyBuffMarker: Marker
    {
        [Header("变化数值类型")]
        public SkillConfig.NumericModifyBuffType buffType;

        [Header("变化百分比")]
        [Range(-10, 10)]
        public float modifyPercent = 0f;

        [Header("持续时间(单位:秒)")]
        [Range(0.1f, 300)]
        public float buffDuration = 1;
    }
}