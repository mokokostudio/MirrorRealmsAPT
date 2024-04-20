using System;
using UnityEngine.Playables;
using UnityEngine;

namespace ET.Client {
    [Serializable]
    public class LookTargetPlayableAsset : PlayableAsset {
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            return Playable.Create(graph);
        }
    }
}