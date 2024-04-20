using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent_NavigatePanel_Cursor))]
    [FriendOfAttribute(typeof (UIBattleComponent_NavigatePanel_Cursor))]
    public static partial class UIBattleComponent_NavigatePanel_CursorSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent_NavigatePanel_Cursor self, GameObject gameObject, float parentWidthPixel)
        {
            self.GameObject = gameObject;
            self.ParentHalfWidthPixel = (int)(parentWidthPixel / 2f);
            self.RectTransform = self.GameObject.GetComponent<RectTransform>();
            self.Destination = float3.zero;

            self.GameObject.SetActive(true);
        }

        [EntitySystem]
        private static void Destroy(this UIBattleComponent_NavigatePanel_Cursor self)
        {
            UnityEngine.Object.Destroy(self.GameObject);
            self.GameObject = null;
            self.RectTransform = null;
            self.Destination = default;
        }

        [EntitySystem]
        private static void LateUpdate(this UIBattleComponent_NavigatePanel_Cursor self)
        {
            var myUnit = MrUnitHelper.GetMyUnitFromClientScene(self.Root());
            if (myUnit == null)
            {
                return;
            }

            var selfForward = math.normalize(myUnit.Forward);
            var directionToP = math.normalize(self.Destination - myUnit.Position);
            float relativeDirection = math.dot(directionToP, selfForward);

            // 将-1~1的值转换到0~1的区间
            float normalizedValue = (relativeDirection + 1f) / 2f;

            float v = 1 - normalizedValue;
            if (math.cross(selfForward, directionToP).y < 0)
            {
                v *= -1;
            }

            var localPosition = self.RectTransform.localPosition;
            localPosition.x = v * self.ParentHalfWidthPixel;
            self.RectTransform.localPosition = localPosition;
        }

        public static UIBattleComponent_NavigatePanel_Cursor SetDestination(this UIBattleComponent_NavigatePanel_Cursor self, float3 destination)
        {
            self.Destination = destination;
            return self;
        }

        public static UIBattleComponent_NavigatePanel_Cursor SetColor(this UIBattleComponent_NavigatePanel_Cursor self, Color color)
        {
            self.GameObject.GetComponent<Image>().color = color;
            return self;
        }
    }
}