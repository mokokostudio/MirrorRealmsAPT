using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent_RunePanel_Rune))]
    [FriendOf(typeof (UIBattleComponent_RunePanel_Rune))]
    public static partial class UIBattleComponent_RunePanel_RuneSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent_RunePanel_Rune self, int configId, int count, GameObject gameObject)
        {
            self.ConfigId = configId;
            self.Count = count;
            self.GameObject = gameObject;
            self.CooldownTimer = 0;
            self.Cooldown = 1; // 读配置

            self.GameObject.SetActive(true);
            
            var rc = gameObject.GetComponent<ReferenceCollector>();
            self.Button_Use = rc.Get<GameObject>("Button_Use").GetComponent<Button>();
            self.Image_CDMask = rc.Get<GameObject>("Image_CDMask").GetComponent<Image>();
            self.Text_RuneCount = rc.Get<GameObject>("Text_RuneCount").GetComponent<TextMeshProUGUI>();
            self.Image_CDMask.fillAmount = 0;
            self.Image_Icon = rc.Get<GameObject>("Image_Icon").GetComponent<Image>();
            var iconRc = self.Root().GetComponent<UI_IconResourceComponent>();
            self.Image_Icon.sprite = iconRc.Get(self.Config.Icon) ?? iconRc.Get("Default");

            self.Button_Use.onClick.AddListener(() => { self.OnClickUse().Coroutine(); });
            self.UpdateCDMask();
            self.UpdateRuneCountText();
        }

        [EntitySystem]
        private static void Destroy(this UIBattleComponent_RunePanel_Rune self)
        {
            UnityEngine.Object.Destroy(self.GameObject);
            self.GameObject = null;

            self.Button_Use = null;
            self.Image_Icon = null;
            self.Image_CDMask = null;
            self.Text_RuneCount = null;
            self.Image_Icon = null;

            self.ConfigId = 0;
            self.Count = 0;
            self.CooldownTimer = 0;
        }

        [EntitySystem]
        private static void Update(this UIBattleComponent_RunePanel_Rune self)
        {
            self.UpdateCDMask();
        }

        private static void UpdateCDMask(this UIBattleComponent_RunePanel_Rune self)
        {
            if (self.CooldownTimer > 0)
            {
                self.CooldownTimer -= Time.deltaTime;
                if (self.CooldownTimer <= 0)
                {
                    self.CooldownTimer = 0;
                    self.Image_CDMask.fillAmount = 0;
                }
                else
                {
                    self.Image_CDMask.fillAmount = self.CooldownTimer / self.Cooldown;
                }
            }
        }

        private static void UpdateRuneCountText(this UIBattleComponent_RunePanel_Rune self)
        {
            self.Text_RuneCount.text = $"{self.Count}";
            self.Text_RuneCount.color = self.Count > 0? Color.white : Color.red;
        }

        public static void OnIventoryCountChanged(this UIBattleComponent_RunePanel_Rune self, int oldCount, int newCount)
        {
            self.Count = newCount;
            self.UpdateRuneCountText();
        }

        private static async ETTask OnClickUse(this UIBattleComponent_RunePanel_Rune self)
        {
            if (self.Count <= 0)
            {
                return;
            }

            if (self.CooldownTimer > 0)
            {
                return;
            }

            self.CooldownTimer = self.Cooldown;

            var req = new MrC2M_UseItem() { ItemConfigId = self.ConfigId };
            var res = (MrM2C_UseItem)await self.Root().GetComponent<MrClientSenderCompnent>().Call(req);

            if (res.Error != 0)
            {
                Log.Error($"使用符文失败: runeId={self.ConfigId}, error={res.Error}, msg={res.Message}");
                return;
            }
        }
    }
}