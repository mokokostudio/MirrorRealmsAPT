using System;
using UnityEngine.Timeline;

namespace ET.Client
{
    [Serializable]
    [TrackClipType(typeof(RectangleAttackBoxPlayableAsset))]
    [TrackClipType(typeof(CircleAttackBoxPlayableAsset))]
    [TrackColor(0, 1, 0)]
    public class AttackBoxTrack : TrackAsset
    {
    }
}