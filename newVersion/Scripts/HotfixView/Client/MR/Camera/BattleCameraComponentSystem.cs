using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (BattleCameraComponent))]
    [FriendOf(typeof (BattleCameraComponent))]
    public static partial class BattleCameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BattleCameraComponent self)
        {
            self.Camera = GameObject.Find("Global/BattleCamera").GetComponent<CinemachineVirtualCamera>();
            if (self.Camera == null)
            {
                Log.Error($"没有找到BattleCamera");
            }
        }

        [EntitySystem]
        private static void LateUpdate(this BattleCameraComponent self)
        {
            if (self.Camera == null)
            {
                return;
            }

            if (self.Camera.Follow != null)
            {
                return;
            }

            var unit = MrUnitHelper.GetMyUnitFromCurrentScene(self.Scene());
            if (unit == null)
            {
                return;
            }

            var gameObjectComponent = unit.GetComponent<MrGameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }

            self.Camera.Follow = gameObjectComponent.GameObject.transform;
        }
    }
}