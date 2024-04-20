using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace ET.Client
{
    public enum PlayerAnimatorState
    {
        Idle,
        Run,
        Skill
    }

    public class PlayerAnimatorRunData
    {
        public AnimationClip[] clips;
        public float[] moveDistance;

        public PlayerAnimatorRunData(int len)
        {
            clips = new AnimationClip[len];
            moveDistance = new float[len];
        }

        public CharacterAnimationDataClip this[int idx]
        {
            set
            {
                clips[idx] = value.clip;
                moveDistance[idx] = (float)value.skillConfig.offset;
            }
        }
    }

    public class Audio
    {
        public float Time;
        public AudioClip Clip;
    }

    public class Impulse
    {
        public double Time;
        public Vector3 power;
    }

    [ComponentOf(typeof (Unit))]
    public class PlayerAnimationComponent: Entity, IAwake, IUpdate, IDestroy
    {
        public EntityRef<Unit> UnitRef;
        public Unit Unit => UnitRef;

        public bool IsCastingSkill;

        public EntityRef<ClientSkill> CastingSkillRef;
        public ClientSkill CastingSkill => this.CastingSkillRef;

        public float SkillTime;

        public AuAnimator2 Animator;
        public string Posture;
        public ArmWeaponMode ArmWeaponMode;

        public AnimationClip IdleClip;
        public PlayerAnimatorRunData RunGroup;

        public PlayerAnimatorState PlayerAnimatorState;

        public List<Material> Materials = new();

        public Color DefRimLasColor;
        public Color DefRimCurColor;
        public Color DefRimTarColor;
        public float DefRimColorLerp;

        public float SplashLerp;
        public float SplashValue;

        public float IdleOrMoveAnimationSpeed;
        public float AnimationSpeed;
        public float Face;

        public readonly List<GameObject> WeaponObjects = new();

        public CharacterAnimationDataClip CurrentClip;

        public List<FX> FXToCreate;
        public List<FX> FXToRemove;
        public Dictionary<FX, PlayableDirector> FXDirectors;

        public Queue<Audio> AudioToCreate;
        public Queue<Impulse> ImpulseToCreate;
    }
}