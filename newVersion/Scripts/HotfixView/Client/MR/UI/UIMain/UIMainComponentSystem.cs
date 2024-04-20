using System.IO;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUIMainComponent))]
    [FriendOf(typeof(MrUIMainComponent))]
    public static partial class UIMainComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrUIMainComponent self)
        {
            GameObject uiObj = self.GetParent<UI>().GameObject;
            ReferenceCollector rc = uiObj.GetComponent<ReferenceCollector>();

            //self.weaponList = rc.Get<GameObject>("WeaponList");
            self.joinRoom = rc.Get<GameObject>("JoinRoom");
            self.joinRoom.GetComponent<Button>().onClick.AddListener(() => {
                self.OnJoinRoomBtnClicked().Coroutine();
            });
            // TODO： 暂时屏蔽CreateRoom按钮
            self.createRoom = rc.Get<GameObject>("CreateRoom");
            self.createRoom.GetComponent<Button>().onClick.AddListener(() => {
                self.OnCreateRoomBtnClicked().Coroutine();
            });

            self.MultiBtnTxtObj = rc.Get<GameObject>("MultiBtnTxt");
            self.matchCntTxt = rc.Get<GameObject>("MatchCntTxt").GetComponent<TMP_Text>();
            self.matchCntTxt.gameObject.SetActive(false);

            self.equipBtn = rc.Get<GameObject>("EquipBtn");
            self.equipBtn.GetComponent<Button>().onClick.AddListener(() => {
                self.OnEquipBtnClicked().Coroutine();
            });

            self.storageBtn = rc.Get<GameObject>("StorageBtn");
            self.storageBtn.GetComponent<Button>().onClick.AddListener(() => {
                self.OnStorageBtnClicked().Coroutine();
            });

            self.rankBtn = rc.Get<GameObject>("RankBtn");
            self.rankBtn.GetComponent<Button>().onClick.AddListener(() => {
                self.OnRankBtnClicked().Coroutine();
            });

            // EOS
            self.player = rc.Get<GameObject>("Player");
            self.playerCamera = rc.Get<GameObject>("PlayerCamera");

            var animator = self.player.GetComponent<Animator>();
            animator.SetInteger("AniState", 0);

            self.selectItem = rc.Get<GameObject>("SelectModeItem").GetComponent<MrWindowMainModeSelectItem>();
            self.selectItem.GetComponentInChildren<Button>().onClick.AddListener(() => {
                self.SetSelectModePanelState(true);
            });
            // Mode
            self.isSingle = true;
            self.selectItem.SetInfo(true, self.isSingle);

            // StartBtn
            self.startBtn = rc.Get<GameObject>("StartBtn");
            self.startBtn.GetComponent<Button>().onClick.AddListener(() => {
                self.OnStartBtnClicked().Coroutine();
            });

            self.startBtnTxtObj = rc.Get<GameObject>("StartBtnTxt");
            self.startMatchCntTxt = rc.Get<GameObject>("StartMatchCntTxt").GetComponent<TMP_Text>();
            self.startMatchCntTxt.gameObject.SetActive(false);

            // SelectModePanel
            self.modeSelectPanel = rc.Get<GameObject>("ModeSelectPanel");
            self.SetSelectModePanelState(false);
            self.modeSelectPanel.GetComponent<Button>().onClick.AddListener(() => {
                self.SetSelectModePanelState(false);
            });

            Scene root = self.Root();
            self.singleItem = rc.Get<GameObject>("SingleItem").GetComponent<MrWindowMainModeSelectItem>();
            self.singleItem.SetInfo(false, true);
            self.singleItem.GetComponentInChildren<Button>().onClick.AddListener(() => {
                self.isSingle = true;
                self.selectItem.SetInfo(true, true);
                self.SetSelectModePanelState(false);
            });
            self.multiItem = rc.Get<GameObject>("MultiItem").GetComponent<MrWindowMainModeSelectItem>();
            self.multiItem.SetInfo(false, false);
            self.multiItem.GetComponentInChildren<Button>().onClick.AddListener(() => {
                self.isSingle = false;
                self.selectItem.SetInfo(true, false);
                self.SetSelectModePanelState(false);
            });
        }

        [EntitySystem]
        private static void Destroy(this MrUIMainComponent self)
        {
            if (self.matchCntTimerId > 0)
            {
                TimerComponent tc = self.Root().GetComponent<TimerComponent>();
                tc.Remove(ref self.matchCntTimerId);
            }
        }

        public static void ResetInfos(this MrUIMainComponent self)
        {
            self.IsBtnClicked = false;
        }

        public static void UpdateSelectItemInfo(this MrUIMainComponent self)
        {
            self.selectItem.SetInfo(true, self.isSingle);
        }

        private static async ETTask OnEquipBtnClicked(this MrUIMainComponent self)
        {
            Debug.Log($"=== OnEquipBtnClicked ===");
            await MrUIHelper.Create(self.Root(), MrUIType.UIEquip, UILayer.Mid);
            self.SetComponentViewState(false);
            //await ETTask.CompletedTask;
        }

        private static async ETTask OnStorageBtnClicked(this MrUIMainComponent self)
        {
            Debug.Log($"=== OnStorageBtnClicked ===");
            await MrUIHelper.Create(self.Root(), MrUIType.UIStorage, UILayer.Mid);
            self.SetComponentViewState(false);
        }

        private static async ETTask OnRankBtnClicked(this MrUIMainComponent self)
        {
            Debug.Log($"=== OnRankBtnClicked ===");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnJoinRoomBtnClicked(this MrUIMainComponent self)
        {
            if (self.IsBtnClicked) return;
            self.IsBtnClicked = true;
            self.createRoom.GetComponent<Button>().interactable = false;
            self.joinRoom.GetComponent<Button>().interactable = false;

            Scene root = self.Root();

            self.MultiBtnTxtObj.SetActive(false);
            self.matchCntTxt.gameObject.SetActive(true);
            self.matchCnt = 0;
            TimerComponent tc = root.GetComponent<TimerComponent>();
            if (tc != null)
            {
                Debug.LogWarning($"=== Add Timer ===");
                self.matchCntTimerId = tc.NewRepeatedTimer(1000, TimerInvokeType.UIMain_Match, self);
            }
            else
            {
                Debug.LogWarning($"=== TimerComponent is null ===");
            }

            await self.Match(false);
            //tc.Remove(ref self.matchCntTimerId);
        }

        private static async ETTask OnCreateRoomBtnClicked(this MrUIMainComponent self)
        {
            self.Match(true).Coroutine();
            await ETTask.CompletedTask;
        }

        private static async ETTask OnStartBtnClicked(this MrUIMainComponent self)
        {
            if (self.IsBtnClicked) return;
            self.IsBtnClicked = true;
            //self.createRoom.GetComponent<Button>().interactable = false;
            //self.joinRoom.GetComponent<Button>().interactable = false;

            if (self.isSingle)
            {
                await self.Match(true);
                return;
            }

            self.startBtn.GetComponent<Button>().interactable = false;
            Scene root = self.Root();

            self.startBtnTxtObj.SetActive(false);
            self.startMatchCntTxt.gameObject.SetActive(true);
            self.matchCnt = 0;
            TimerComponent tc = root.GetComponent<TimerComponent>();
            if (tc != null)
            {
                Debug.LogWarning($"=== Add Timer ===");
                self.matchCntTimerId = tc.NewRepeatedTimer(1000, TimerInvokeType.UIMain_Match, self);
            }
            else
            {
                Debug.LogWarning($"=== TimerComponent is null ===");
            }

            await self.Match(false);
            //tc.Remove(ref self.matchCntTimerId);
        }

        private static async ETTask<bool> Match(this MrUIMainComponent self, bool singlePlay)
        {
            var res = await self.Root().GetComponent<MrClientSenderCompnent>().Call(new MrC2Lobby_Match() { SinglePlay = singlePlay }) as MrLobby2C_Match;

            if (res.Error == ErrorCode.ERR_Success)
            {
                return true;
            }

            Debug.LogError($"匹配失败: {res}");
            return false;
        }

        public static void SetComponentViewState(this MrUIMainComponent self, bool isShow)
        {
            self.GetParent<UI>().GameObject.SetActive(isShow);
        }

        public static void UpdateMatchTime(this MrUIMainComponent self)
        {
            Debug.LogWarning($"=== UpdateMatchTime {self.matchCnt} ===");
            self.startMatchCntTxt.text = $"{++self.matchCnt}";
        }

        public static void SetSelectModePanelState(this MrUIMainComponent self, bool show)
        {
            self.modeSelectPanel.SetActive(show);
        }
    }
}