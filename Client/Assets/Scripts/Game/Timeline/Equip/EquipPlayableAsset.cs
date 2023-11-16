﻿using System;
using UnityEngine;
using UnityEngine.Playables;

namespace MR.Battle.Timeline {
    [Serializable]
    public class EquipPlayableAsset : PlayableAsset {
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            return Playable.Create(graph);
        }
    }
}