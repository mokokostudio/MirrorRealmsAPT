using System;
using UnityEngine.Timeline;

namespace ET.Client
{
    [Serializable]
    [TrackClipType(typeof (AddNumericModifyBuffMarker))]
    [TrackColor(0, 1, 0)]
    public class BuffTrack: TrackAsset
    {
    }
}