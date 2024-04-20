using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class HpBar: Entity, IAwake, ILateUpdate, IDestroy
    {
        public Camera Camera;
        public GameObject GameObject;
        public Slider HPSlider;
    }
}