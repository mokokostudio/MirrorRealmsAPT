using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent_NavigatePanel))]
    [FriendOfAttribute(typeof (UIBattleComponent_NavigatePanel))]
    public static partial class UIBattleComponent_NavigatePanelSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent_NavigatePanel self, GameObject go)
        {
            self.GameObject = go;
            self.GameObject.SetActive(true);

            var rc = go.GetComponent<ReferenceCollector>();
            self.RawImg_HUD = rc.Get<GameObject>("RawImg_HUD").GetComponent<RawImage>();
            self.RectTransform_Target_Template = rc.Get<GameObject>("Cursor_Template");
            self.RectTransform_Target_Template.SetActive(false);

            self.RawImg_HUD_WidthPixel = self.RawImg_HUD.rectTransform.sizeDelta.x;
        }

        [EntitySystem]
        private static void LateUpdate(this UIBattleComponent_NavigatePanel self)
        {
            var myUnit = MrUnitHelper.GetMyUnitFromClientScene(self.Root());
            float angle = 0;
            if (myUnit != null)
            {
                angle = Mathf.Atan2(myUnit.Forward.x, myUnit.Forward.z) * Mathf.Rad2Deg;
            }

            angle = (angle + 360) % 360;

            self.RawImg_HUD.uvRect = new Rect((angle / 360f) - .5f, 0f, 1f, 1f);
        }

        public static UIBattleComponent_NavigatePanel_Cursor AddCursor(this UIBattleComponent_NavigatePanel self, float3 destination)
        {
            var go = UnityEngine.Object.Instantiate(self.RectTransform_Target_Template, self.RectTransform_Target_Template.transform.parent, false);
            var c = self.AddChild<UIBattleComponent_NavigatePanel_Cursor, GameObject, float>(go, self.RawImg_HUD_WidthPixel);
            return c.SetDestination(destination);
        }

        public static UIBattleComponent_NavigatePanel_Cursor AddCursor(this UIBattleComponent_NavigatePanel self, float3 destination, Color color)
        {
            return self.AddCursor(destination).SetColor(color);
        }

        public static void RemoveCursor(this UIBattleComponent_NavigatePanel self, long id)
        {
            self.RemoveChild(id);
        }
    }
}