using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (MrUILoadingComponent))]
    [FriendOf(typeof (MrUILoadingComponent))]
    public static partial class MrUILoadingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrUILoadingComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.slider = rc.Get<GameObject>("Slider").GetComponent<Slider>();
            self.slider.value = 1;
        }
    }
}