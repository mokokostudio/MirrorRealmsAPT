using System;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrGameObjectComponent))]
    public static partial class MrGameObjectComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this MrGameObjectComponent self)
        {
            UnityEngine.Object.Destroy(self.GameObject);
        }
        
        [EntitySystem]
        private static void Awake(this MrGameObjectComponent self)
        {

        }
    }
}