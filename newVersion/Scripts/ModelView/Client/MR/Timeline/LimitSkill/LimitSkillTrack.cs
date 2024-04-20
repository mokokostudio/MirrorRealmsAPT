using System;
using UnityEngine.Timeline;

namespace ET.Client 
{
    [Serializable]
    [TrackClipType(typeof(LimitSkillPlayableAsset))]
    [TrackColor(1f, .5f, .5f)]
    public class LimitSkillTrack : TrackAsset
    {
    }
}