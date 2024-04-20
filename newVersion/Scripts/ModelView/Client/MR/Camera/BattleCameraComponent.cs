using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class BattleCameraComponent: Entity, IAwake, ILateUpdate
    {
        private CinemachineVirtualCamera camera;

        public Transform Transform;

        public CinemachineVirtualCamera Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                this.camera = value;
                this.Transform = this.camera.transform;
            }
        }
    }
}