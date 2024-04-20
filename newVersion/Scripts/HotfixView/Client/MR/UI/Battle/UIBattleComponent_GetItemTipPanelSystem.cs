using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent_GetItemTipPanel))]
    [FriendOfAttribute(typeof (UIBattleComponent_GetItemTipPanel))]
    public static partial class UIBattleComponent_GetItemTipPanelSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent_GetItemTipPanel self, GameObject go)
        {
            self.GameObject = go;
            self.GameObject.SetActive(true);

            var rc = self.GameObject.GetComponent<ReferenceCollector>();
            self.Template = rc.Get<GameObject>("Template");
            self.Template.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this UIBattleComponent_GetItemTipPanel self)
        {
            self.GameObject = null;
            self.Template = null;
        }

        public static void Create(this UIBattleComponent_GetItemTipPanel self, int itemConfigId, int count)
        {
            var go = UnityEngine.Object.Instantiate(self.Template, self.Template.transform.parent, false);
            self.AddChild<UIBattleComponent_GetItemTipPanel_Item, GameObject, int, int>(go, itemConfigId, count);
        }
    }
}