namespace ET.Client
{
    [Invoke(TimerInvokeType.UIBattle_CountDown)]
    public class GameRoomEnd_TimerHandler : ATimer<UIBattleComponent>
    {
        protected override void Run(UIBattleComponent uiBattleComp)
        {
            uiBattleComp.CountDown();
        }
    }

    [Invoke(TimerInvokeType.UIMain_Match)]
    public class UIMainMatchPlayer_TimerHandler : ATimer<MrUIMainComponent>
    {
        protected override void Run(MrUIMainComponent uiMainComp)
        {
            uiMainComp.UpdateMatchTime();
        }
    }
}