using System;
using UnityEngine.Timeline;

namespace ET.Client 
{
    [Serializable]
    [TrackClipType(typeof(ConsumptionPlayableAsset))]
    [TrackColor(0, 1, 0)]
    public class ConsumptionTrack : TrackAsset
    {
    }
}