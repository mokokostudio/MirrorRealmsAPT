using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace ET.Client
{
    [DisplayName("位置改变")]
    [Serializable]
    public class PositionModifyMarker: Marker
    {
        [Header("相对位置")]
        public Vector3 relativePosition;
    }
}