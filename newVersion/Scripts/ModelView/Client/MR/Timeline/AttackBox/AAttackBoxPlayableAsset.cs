using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;
using UnityEngine.Timeline;

namespace ET.Client {
    [DisplayName("攻击盒子")]
    [Serializable]
    public abstract class AAttackBoxPlayableAsset : PlayableAsset, ITimelineClipAsset {
        public ClipCaps clipCaps => ClipCaps.None;

        [Header("备注")]
        [TextArea(1, 10)]
        public string remark;

        [Header("相对位置")]
        public Vector2 position;

        [Header("伤害类型")]
        public SkillConfig.DamageType DamageType;
        
        [Header("伤害倍率, 一个技能可以有多个攻击盒, 一个攻击盒子只能产生一次伤害, 只在开始时生效")]
        [Range(0, 10)]
        public float DamageMultiplier = 1f;
        
        [Header("击中特效")]
        public int ImpactEffectId;

        [Header("击退目标")]
        public bool knockbackTarget = false;

        [Header("击退优先级")]
        [Range(-100, 100)]
        public int knockbackPriority = 0;

        [Header("击退速度")]
        [Range(0.01f, 10f)]
        public float knockbackSpeed = 1;

        [Header("击退时长")]
        [Range(0.01f, 3f)]
        public float knockbackDuration = 0.1f;
        
        [Header("减速目标")]
        public bool slowTarget = false;
        
        [Header("减速幅度")]
        [Range(0.01f, 1f)]
        public float slowValue = 0.1f;
        
        [Header("减速时长")]
        [Range(0.01f, 10f)]
        public float slowDuration = 0.1f;

        [Header("[调试]显示颜色")]
        public Color DrawColor = Color.magenta;
        
        [NonSerialized]
        public Transform ownerTr;
        [NonSerialized]
        public bool isPlaying;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            ownerTr = owner.transform;
            var pb = ScriptPlayable<Behaviour>.Create(graph);
            pb.GetBehaviour().Set(this);
            return pb;
        }

        private class Behaviour : PlayableBehaviour {
            private AAttackBoxPlayableAsset m_Asset;

            public void Set(AAttackBoxPlayableAsset asset) {
                m_Asset = asset;
            }

            public override void OnBehaviourPlay(Playable playable, FrameData info) {
                m_Asset.isPlaying = true;
            }

            public override void OnBehaviourPause(Playable playable, FrameData info) {
                m_Asset.isPlaying = false;
            }
        }
    }
}