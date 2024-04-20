// using System.Collections.Generic;
// using UnityEngine;
//
// namespace ET.Client
// {
//     public enum MotionType
//     {
//         None = 0,
//         Idle = 1,
//         Run = 2,
//         Attack = 3,
//         Hit = 4,
//     }
//
//     [ComponentOf]
//     public class AnimatorComponent: Entity, IAwake, IUpdate, ILateUpdate, IDestroy
//     {
//         public Dictionary<string, AnimationClip> animationClips = new();
//         public HashSet<string> Parameter = new();
//
//         public MotionType MotionType;
//         public float MontionSpeed;
//         public bool isStop;
//         public float stopSpeed;
//         public Animator Animator;
//     }
// }