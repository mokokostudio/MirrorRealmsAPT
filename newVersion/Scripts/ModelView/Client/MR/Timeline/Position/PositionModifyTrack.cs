using System;
using UnityEngine.Timeline;

namespace ET.Client
{
    [Serializable]
    [TrackClipType(typeof (PositionModifyMarker))]
    [TrackColor(0, 1, 0)]
    public class PositionModifyTrack: TrackAsset
    {
    }
}