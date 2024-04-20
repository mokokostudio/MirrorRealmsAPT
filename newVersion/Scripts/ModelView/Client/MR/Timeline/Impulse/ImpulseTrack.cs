using System;
using UnityEngine.Timeline;
using static ET.Client.CharacterAnimationDataClip;
using System.Collections.Generic;

namespace ET.Client {
    [Serializable]
    [TrackClipType(typeof(ImpulseMarker))]
    [TrackColor(1f, .5f, .5f)]
    public class ImpulseTrack : TrackAsset {
       
    }
}