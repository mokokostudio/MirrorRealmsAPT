using ET.Client.WaitType;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIBattleComponent))]
    [FriendOf(typeof (UIBattleComponent))]
    public static partial class UIBatleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIBattleComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.waitDraw = rc.Get<GameObject>("WaitDraw");
            self.moveFG = rc.Get<GameObject>("MoveFG");
            self.btnAttack = rc.Get<GameObject>("BtnAttack");
            self.btnDodge = rc.Get<GameObject>("BtnDodge");
            self.btnDefence = rc.Get<GameObject>("BtnDefense");
            self.btnDiscard = rc.Get<GameObject>("BtnDiscard");
            self.btnWeapon1 = rc.Get<GameObject>("BtnWeapon1");
            self.btnWeapon2 = rc.Get<GameObject>("BtnWeapon2");
            self.btnWeapon3 = rc.Get<GameObject>("BtnWeapon3");
            self.countDownText = rc.Get<GameObject>("CountDownText").GetComponent<Text>();
            self.countDownText.text = "N/A";
            self.MyHpBar_Slider = rc.Get<GameObject>("MyHpBar_Slider").GetComponent<Slider>();
            self.Btn_Inventory = rc.Get<GameObject>("Btn_Inventory").GetComponent<Button>();

            var runePanel_go = rc.Get<GameObject>("RunePanel");
            self.AddComponent<UIBattleComponent_RunePanel, GameObject>(runePanel_go);

            var inventoryPanel_go = rc.Get<GameObject>("InventoryPanel");
            self.AddComponent<UIBattleComponent_InventoryPanel, GameObject>(inventoryPanel_go);
            self.Btn_Inventory.onClick.AddListener(() => { self.GetComponent<UIBattleComponent_InventoryPanel>().Toggle(); });

            var tipPanel_go = rc.Get<GameObject>("GetItemTipPanel");
            self.AddComponent<UIBattleComponent_GetItemTipPanel, GameObject>(tipPanel_go);

            var navigate_go = rc.Get<GameObject>("NavigatePanel");
            self.AddComponent<UIBattleComponent_NavigatePanel, GameObject>(navigate_go);

            // test
            self.GetComponent<UIBattleComponent_NavigatePanel>().AddCursor(new float3(0, 0, 0), Color.red);
            self.GetComponent<UIBattleComponent_NavigatePanel>().AddCursor(new float3(5, 0, 5), Color.blue);
            self.GetComponent<UIBattleComponent_NavigatePanel>().AddCursor(new float3(5, 0, -5), Color.green);
            self.GetComponent<UIBattleComponent_NavigatePanel>().AddCursor(new float3(-5, 0, -5), Color.magenta);
            self.GetComponent<UIBattleComponent_NavigatePanel>().AddCursor(new float3(-5, 0, 5), Color.yellow);

            self.waitDraw.SetActive(false);

            //LSClientUpdaterMR lsClientUpdaterMR = self.GetParent<RoomMR>().GetComponent<LSClientUpdaterMR>();
            WindowBattleBehaviour wbb = self.GetParent<UI>().GameObject.GetComponent<WindowBattleBehaviour>();
            // Move Action
            //InputAction moveAction = wbb.GetInputAction("Player/Move");
            //moveAction.started += (obj) => {
            //    self.DebugWarning($"=== moveAction.started ===");
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.MoveStart;
            //    self.moveFG.SetActive(true);
            //};
            //moveAction.performed += (obj) => {
            //    self.DebugWarning($"=== moveAction.performed ===");
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.Moving;
            //    var f = moveAction.ReadValue<Vector2>();
            //    TSVector2 toward = new TSVector2(f.x, f.y);
            //    //lsClientUpdaterMR.Input.Toward = toward;
            //    FP a = TSMath.Atan2(toward.y, toward.x);
            //    self.moveFG.transform.localEulerAngles = new Vector3(0, 0, (float)a * Mathf.Rad2Deg - 90);
            //};
            //moveAction.canceled += (obj) => {
            //    self.DebugWarning($"=== moveAction.canceled ===");
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.MoveEnd;
            //    self.moveFG.SetActive(false);
            //};

            //// Attack Action
            //InputAction dodgeAction = wbb.GetInputAction("Player/Dodge");
            //dodgeAction.started += (obj) => {
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.DodgeStart;
            //};
            //dodgeAction.canceled += (obj) => {
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.DodgeEnd;
            //};

            //// Defense Action
            //InputAction defenseAction = wbb.GetInputAction("Player/Defense");
            //defenseAction.started += (obj) => {
            //    if (self.btnDefense.activeInHierarchy)
            //    {
            //        //lsClientUpdaterMR.Input.OperateType = InputOperateType.Defense;
            //    }
            //};

            //InputAction attackAction = wbb.GetInputAction("Player/Fire");
            //attackAction.started += (obj) => {
            //    if (self.btnDefense.activeInHierarchy)
            //    {
            //        //lsClientUpdaterMR.Input.OperateType = InputOperateType.Attack;
            //    }
            //};

            //// Skill1-3 (weapon button == skill in codes)
            //InputAction skill1Action = wbb.GetInputAction("Player/Skill1");
            //skill1Action.started += (obj) => {
            //    self.DebugWarning($"=== skill1Action.started ===");
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.WeaponChange1;
            //};
            //InputAction skill2Action = wbb.GetInputAction("Player/Skill2");
            //skill2Action.started += (obj) => {
            //    self.DebugWarning($"=== skill2Action.started ===");
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.WeaponChange2;
            //};
            //InputAction skill3Action = wbb.GetInputAction("Player/Skill3");
            //skill3Action.started += (obj) => {
            //    self.DebugWarning($"=== skill3Action.started ===");
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.WeaponChange3;
            //};

            // Discard Action
            //InputAction discardAction = wbb.GetInputAction("Player/Discard");
            //discardAction.started += (obj) => {
            //    //lsClientUpdaterMR.Input.OperateType = InputOperateType.Discard;
            //};

            self.btnAttack.GetComponent<Button>().onClick.AddListener(() => { self.DebugWarning($"=== BtnAttack clicked. ==="); });
            self.btnDefence.GetComponent<Button>().onClick.AddListener(() => { self.DebugWarning($"=== BtnDefense clicked. ==="); });
            self.btnDiscard.GetComponent<Button>().onClick.AddListener(() => { self.DebugWarning($"=== BtnDiscard clicked. ==="); });
            self.btnDodge.GetComponent<Button>().onClick.AddListener(() => { self.DebugWarning($"=== BtnDodge clicked. ==="); });

            self.btnWeapon1.GetComponent<Button>().onClick.AddListener(() => { self.DebugWarning($"=== BtnWeapon1 clicked. ==="); });
            self.btnWeapon2.GetComponent<Button>().onClick.AddListener(() => { self.DebugWarning($"=== BtnWeapon2 clicked. ==="); });
            self.btnWeapon3.GetComponent<Button>().onClick.AddListener(() => { self.DebugWarning($"=== BtnWeapon3 clicked. ==="); });

            self.isMatchFinish = false;
            self.Root().GetComponent<ObjectWait>().Notify(new Wait_BattleUI());
        }

        [EntitySystem]
        private static void Update(this UIBattleComponent self)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                self.ShowResult();
            }
        }

        private static async ETTask TestResultUI(this UIBattleComponent self)
        {
            Scene s = self.Scene();
            await EventSystem.Instance.PublishAsync(s, new MrBattleEnd() { IsVictory = true });
            await MrUIHelper.Remove(s, MrUIType.UIBattle);
        }

        public static void ShowResult(this UIBattleComponent self)
        {
            self.isMatchFinish = true;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.countDownTimerId);
            self.TestResultUI().Coroutine();
        }

        [EntitySystem]
        private static void LateUpdate(this UIBattleComponent self)
        {
            float hpPercent = 0;

            Unit myUnit = MrUnitHelper.GetMyUnitFromCurrentScene(self.Scene());
            if (myUnit != null)
            {
                NumericComponent numericComponent = myUnit.GetComponent<NumericComponent>();
                if (numericComponent != null)
                {
                    float hp = numericComponent.GetAsInt(NumericType.Hp);
                    float maxHp = math.max(1, numericComponent.GetAsInt(NumericType.MaxHp));
                    hpPercent = hp / maxHp;
                }
            }

            self.MyHpBar_Slider.value = hpPercent;
        }

        /// <summary>
        /// 临时用用
        /// </summary>
        /// <param name="self"></param>
        /// <param name="content"></param>
        private static void DebugWarning(this UIBattleComponent self, string content)
        {
            Debug.LogWarning(content);
        }

        public static void ShowReadyTime(this UIBattleComponent self, long currentTime, int time)
        {
            Debug.LogWarning($"=== UIBattleComponent->ShowReadyTime ===");
            self.countDown = time * 60;
            self.countDownText.text = $"{self.countDown}";
            TimerComponent timer = self.Root().GetComponent<TimerComponent>();
            if (timer == null)
            {
                self.DebugWarning($"=== ShowReadyTime TimerComponent is null. ===");
                return;
            }

            // 添加UI的计时器，不用每秒从server同步
            bool res = self.Root().GetComponent<TimerComponent>().Remove(ref self.countDownTimerId);
            self.DebugWarning($"=== UIBattleComponent ShowReadyTime {self.countDownTimerId} result={res}. ===");
            self.countDownTimerId = timer.NewRepeatedTimer(1000, TimerInvokeType.UIBattle_CountDown, self);
        }

        public static void CountDown(this UIBattleComponent self)
        {
            if (self.isMatchFinish)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.countDownTimerId);
                return;
            }

            self.countDown--;
            self.countDownText.text = $"{self.countDown}";
            if (self.countDown <= 0)
            {
                if (self.Root().GetComponent<TimerComponent>().Remove(ref self.countDownTimerId))
                {
                    self.DebugWarning($"=== UIBattleComponent countdown timer is remove successs. ===");
                }
                else
                {
                    self.DebugWarning($"=== UIBattleComponent countdown timer is remove failure. ===");
                }
            }
        }

        public static void OnRoomPhaseInfoChange(this UIBattleComponent self, MrRoomPhase phase, long startTime, long remainingTime)
        {
            self.countDownText.text = $"{phase} : {remainingTime}";
        }
    }
}