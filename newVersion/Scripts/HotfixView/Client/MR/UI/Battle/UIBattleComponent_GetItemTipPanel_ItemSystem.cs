using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.ShowGetItemTip_DestroyTimer)]
    public class ShowGetItemTip_DestroyTimer__Handler: ATimer<UIBattleComponent_GetItemTipPanel_Item>
    {
        protected override void Run(UIBattleComponent_GetItemTipPanel_Item t)
        {
            t.On__ShowGetItemTip_DestroyTimer();
        }
    }

    [EntitySystemOf(typeof (UIBattleComponent_GetItemTipPanel_Item))]
    [FriendOf(typeof (UIBattleComponent_GetItemTipPanel_Item))]
    public static partial class UIBattleComponent_GetItemTipPanel_ItemSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent_GetItemTipPanel_Item self, GameObject go, int itemConfigId, int count)
        {
            self.GameObject = go;
            self.GameObject.SetActive(true);

            var itemConfig = ItemConfigCategory.Instance.Get(itemConfigId);

            var rc = go.GetComponent<ReferenceCollector>();

            var iconRc = self.Root().GetComponent<UI_IconResourceComponent>();
            rc.Get<GameObject>("Img_Icon").GetComponent<Image>().sprite = iconRc.Get(itemConfig.Icon) ?? iconRc.Get("Default");
            rc.Get<GameObject>("Img_QualityBorder").GetComponent<Image>().color = QualityColor.GetColor((MrItemQuality)itemConfig.Quality);
            rc.Get<GameObject>("Txt").GetComponent<TextMeshProUGUI>().text = $"{itemConfig.ShowName} x {count}";

            var showTime = 2f;
            var delayToDestroy = showTime + 0.2f;
            var destroyTime = TimeInfo.Instance.ServerFrameTime() + (long)(delayToDestroy * 1000);
            self.ShowGetItemTip_DestroyTimerId = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(destroyTime, TimerInvokeType.ShowGetItemTip_DestroyTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this UIBattleComponent_GetItemTipPanel_Item self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.ShowGetItemTip_DestroyTimerId);

            UnityEngine.Object.Destroy(self.GameObject);
            self.GameObject = null;
        }

        public static void On__ShowGetItemTip_DestroyTimer(this UIBattleComponent_GetItemTipPanel_Item self)
        {
            self.Dispose();
        }
    }
}