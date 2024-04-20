using System;
using UnityEngine.Timeline;

namespace ET.Client 
{
    [Serializable]
    [TrackClipType(typeof(MovePlayableAsset))]
    [TrackColor(.5f, 1f, .5f)]
    public class MoveTrack : TrackAsset
    {
    }
}