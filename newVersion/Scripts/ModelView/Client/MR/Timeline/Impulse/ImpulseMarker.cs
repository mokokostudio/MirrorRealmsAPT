using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

namespace ET.Client
{
    [DisplayName("屏幕抖动")]
    [Serializable]
    public class ImpulseMarker: Marker
    {
        public bool onlySelf;
        public Vector3 power;
    }
}