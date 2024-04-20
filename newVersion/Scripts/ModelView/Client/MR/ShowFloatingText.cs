using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof (ShowFloatingTextComponent))]
    public class ShowFloatingText: Entity, IAwake<GameObject>, ILateUpdate, IDestroy
    {
        public Camera Camera;
        public GameObject GameObject;

        public long ShowFloatingText_DestroyTimerId;
    }
}