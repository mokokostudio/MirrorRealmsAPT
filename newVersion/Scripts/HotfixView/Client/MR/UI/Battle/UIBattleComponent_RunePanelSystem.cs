using System.Linq;
using DotRecast.Core;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent_RunePanel))]
    [FriendOf(typeof (UIBattleComponent_RunePanel))]
    [FriendOf(typeof (ClientInventoryItem))]
    [FriendOf(typeof (UIBattleComponent_RunePanel_Rune))]
    public static partial class UIBattleComponent_RunePanelSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent_RunePanel self, GameObject go)
        {
            var rc = go.GetComponent<ReferenceCollector>();

            self.Rune_Template = rc.Get<GameObject>("Rune_Template");
            self.Rune_Template.SetActive(false);

            self.Init();
        }

        [EntitySystem]
        private static void Destroy(this UIBattleComponent_RunePanel self)
        {
            self.Rune_Template = null;
        }

        public static void Init(this UIBattleComponent_RunePanel self)
        {
            // 初始化为0个
            foreach (int configId in self.ShowRuneConfigIds)
            {
                self.OnIventoryCountChanged(configId, 0, 0);
            }

            self.SyncWithInventory();
        }

        /// <summary>
        /// 同步背包里的实际数量
        /// </summary>
        /// <param name="self"></param>
        private static void SyncWithInventory(this UIBattleComponent_RunePanel self)
        {
            MrUnitHelper.GetMyUnitFromClientScene(self.Root())
                    ?.GetComponent<ClientInventoryComponent>()
                    ?.Children
                    .Select(x => x.Value as ClientInventoryItem)
                    .Where(x => x.ItemType == MrInventoryType.Rune)
                    .ForEach(x => self.OnIventoryCountChanged(x.ConfigId, 0, x.Count));
        }

        public static void OnIventoryCountChanged(this UIBattleComponent_RunePanel self, int itemConfigId, int oldCount, int newCount)
        {
            if (!self.ShowRuneConfigIds.Contains(itemConfigId))
            {
                return;
            }

            var itemConfig = ItemConfigCategory.Instance.Get(itemConfigId);
            if ((MrInventoryType)itemConfig.ItemType != MrInventoryType.Rune)
            {
                return;
            }

            var rune = self.Children.Select(x => x.Value as UIBattleComponent_RunePanel_Rune)
                    .FirstOrDefault(x => x.ConfigId == itemConfigId);
            if (rune == null)
            {
                var go = UnityEngine.Object.Instantiate(self.Rune_Template, self.Rune_Template.transform.parent);
                rune = self.AddChild<UIBattleComponent_RunePanel_Rune, int, int, GameObject>(itemConfigId, newCount, go);
            }
            else
            {
                rune.OnIventoryCountChanged(oldCount, newCount);
            }
        }
    }
}