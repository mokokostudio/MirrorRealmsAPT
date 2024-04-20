using System;
using UnityEngine.Timeline;

namespace ET.Client 
{
    [Serializable]
    [TrackClipType(typeof(RunModePlayableAsset))]
    [TrackColor(1f, .5f, .5f)]
    public class RunModeTrack : TrackAsset
    {
    }
}