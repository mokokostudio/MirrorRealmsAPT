using System;
using System.Collections.Generic;
using UnityEngine.Timeline;
using UnityEngine.VFX;
using static ET.Client.CharacterAnimationDataClip;

namespace ET.Client 
{
    [Serializable]
    [TrackClipType(typeof(DefensePlayableAsset))]
    [TrackColor(0, 1, 0)]
    public class DefenseTrack : TrackAsset
    {
    }
}