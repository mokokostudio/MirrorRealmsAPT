using System;
using TrueSync;
using UnityEngine;

namespace ET
{
    public struct FX: IEquatable<FX>
    {
        public FP start;
        public FP end;
        public GameObject target;
        public bool follow;
        public float speed;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        public bool Equals(FX other)
        {
            return start == other.start
                    && end == other.end
                    && follow == other.follow
                    && speed == other.speed
                    && position == other.position
                    && rotation == other.rotation
                    && scale == other.scale;
        }
    }
}