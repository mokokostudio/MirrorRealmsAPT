using System;
using UnityEngine.Timeline;

namespace ET.Client
{
    [Serializable]
    [TrackClipType(typeof (NumericModifyMarker))]
    [TrackColor(0, 1, 0)]
    public class NumericModifyTrack: TrackAsset
    {
    }
}