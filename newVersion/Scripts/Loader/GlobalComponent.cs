using UnityEngine;

namespace ET
{
    [FriendOf(typeof (GlobalComponent))]
    public static partial class GlobalComponentSystem
    {
        [EntitySystem]
        public static void Awake(this GlobalComponent self)
        {
            var globalGo = GameObject.Find("/Global");
            self.Global = globalGo.transform;

            var rc = globalGo.GetComponent<ReferenceCollector>();
            self.UnitRoot = rc.Get<GameObject>("UnitRoot").transform;
            self.UIRoot = rc.Get<GameObject>("UIRoot").transform;
            self.FloatingTextRoot = rc.Get<GameObject>("FloatingTextRoot").transform;

            self.GlobalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
        }
    }

    [ComponentOf(typeof (Scene))]
    public class GlobalComponent: Entity, IAwake
    {
        public Transform Global;
        public Transform UnitRoot { get; set; }
        public Transform UIRoot;
        public Transform FloatingTextRoot { get; set; }

        public GlobalConfig GlobalConfig { get; set; }
    }
}