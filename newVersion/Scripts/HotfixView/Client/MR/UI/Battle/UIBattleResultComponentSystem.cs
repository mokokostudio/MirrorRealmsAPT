using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUIBattleResultComponent))]
    [FriendOf(typeof(MrUIBattleResultComponent))]
    public static partial class UIBattleResultComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrUIBattleResultComponent self)
        {
            self.isEnd = false;

            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.victoryIcon = rc.Get<GameObject>("VictoryIcon");
            self.defeatIcon = rc.Get<GameObject>("DefeatIcon");
        }

        [EntitySystem]
        private static void Update(this MrUIBattleResultComponent self)
        {
            if (self.isEnd) return;
            if (Input.GetKeyDown(KeyCode.R))
            {
                self.isEnd = true;
                // Test exit battle
                // EnterMapHelperMR.ExitMapMRAsync(self.Scene()).Coroutine();
                MrUIHelper.Remove(self.Scene(), MrUIType.UIBattleResult).Coroutine();
            }
        }

        public static void SetUIArgs(this MrUIBattleResultComponent self, MrBattleEnd args)
        {
            self.victoryIcon.SetActive(args.IsVictory);
            self.defeatIcon.SetActive(!args.IsVictory);
        }
    }
}

// EOF