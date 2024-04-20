using System;
using UnityEngine.Timeline;

namespace ET.Client
{
    [Serializable]
    [TrackColor(1f, .5f, .5f)]
    public class ConfigTrack: TrackAsset
    {
        public bool moveable;
        public float cooldown;
    }
}