using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.ShowFloatingText_DestroyTimer)]
    public class MrShowFloatingText_DestroyTimer__Handler: ATimer<ShowFloatingText>
    {
        protected override void Run(ShowFloatingText t)
        {
            t.OnDamageTextDestroyTimer();
        }
    }

    [EntitySystemOf(typeof (ShowFloatingText))]
    [FriendOf(typeof (ShowFloatingText))]
    [FriendOf(typeof (MrPlayerInfo))]
    public static partial class MrShowFloatingTextSystem
    {
        [EntitySystem]
        private static void Awake(this ShowFloatingText self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            self.Camera = Camera.main;

            var animationLength = 1f;
            var delayToDestroy = animationLength + 0.2f;
            var destroyTime = TimeInfo.Instance.ServerFrameTime() + (long)(delayToDestroy * 1000);
            self.ShowFloatingText_DestroyTimerId = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(destroyTime, TimerInvokeType.ShowFloatingText_DestroyTimer, self);
        }

        public static void Init(this ShowFloatingText self, int sortingOrder, string text, int fontSize, Color color)
        {
            self.GameObject.Get<GameObject>("Canvas").GetComponent<Canvas>().sortingOrder = 922300 + sortingOrder;

            var textMeshProUGUI = self.GameObject.Get<GameObject>("Text").GetComponent<TextMeshProUGUI>();
            textMeshProUGUI.text = text;
            textMeshProUGUI.fontSize = fontSize;
            textMeshProUGUI.color = color;
        }

        public static void OnDamageTextDestroyTimer(this ShowFloatingText self)
        {
            self.Dispose();
        }

        [EntitySystem]
        private static void Destroy(this ShowFloatingText self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.ShowFloatingText_DestroyTimerId);
            UnityEngine.Object.Destroy(self.GameObject);
            self.GameObject = null;
            self.Camera = null;
        }

        [EntitySystem]
        private static void LateUpdate(this ShowFloatingText self)
        {
            self.UpdateRotation();
        }

        private static void UpdateRotation(this ShowFloatingText self)
        {
            self.Camera ??= Camera.main;
            if (self.Camera == null)
            {
                return;
            }

            self.GameObject.transform.rotation = self.Camera.transform.rotation;
        }
    }
}