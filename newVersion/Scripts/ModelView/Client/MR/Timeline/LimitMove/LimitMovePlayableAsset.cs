using System;
using UnityEngine;
using UnityEngine.Playables;

namespace ET.Client {
    [Serializable]
    public class LimitMovePlayableAsset : PlayableAsset {
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            return Playable.Create(graph);
        }
    }
}