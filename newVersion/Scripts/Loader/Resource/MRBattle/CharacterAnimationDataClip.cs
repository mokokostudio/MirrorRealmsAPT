using System;
using TrueSync;
using UnityEngine;

namespace ET.Client
{
    public class CharacterAnimationDataClip: ScriptableObject
    {
        /// <summary>
        /// 纯逻辑部分
        /// </summary>
        public SkillConfig skillConfig;

        public AnimationClip clip;
        public CustomAnim[] customAnims = { };
        public ImpulseConfig[] impulseConfigs = { };
        public EffectConfig[] effectConfigs = { };
        public AudioConfig[] audioConfigs = { };

        [Serializable]
        public class CustomAnim
        {
            public AnimationClip clip;
            public float start;
            public float startBlend;
            public float endBlend;
            public float end;
            public float animStart;
            public float animSpeed;
        }

        [Serializable]
        public class EffectConfig
        {
            public FP startPoint;
            public FP endPoint;
            public GameObject target;
            public bool follow;
            public float speed;
            public Vector3 position;
            public Vector3 rotation;
            public Vector3 scale;
        }

        [Serializable]
        public class AudioConfig
        {
            public FP startPoint;
            public FP endPoint;
            public AudioClip audioClip;
            public FP volume;
        }

        [Serializable]
        public class ImpulseConfig
        {
            public double startPoint;
            public bool onlySelf;
            public Vector3 power;
        }
    }
}