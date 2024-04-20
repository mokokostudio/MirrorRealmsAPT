namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MrRoomPhaseInfoChange__Handler: AEvent<Scene, MrRoomPhaseInfoChange>
    {
        protected override async ETTask Run(Scene scene, MrRoomPhaseInfoChange args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIBattleComponent battleComp = uiComponent.Get(MrUIType.UIBattle).GetComponent<UIBattleComponent>();
            battleComp?.OnRoomPhaseInfoChange(args.Phase, args.StartTime, args.RemainingTime);

            await ETTask.CompletedTask;
        }
    }
}