// 各种room的event

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class GameRoom_GameReadyStart : AEvent<Scene, GameReadyStart>
    {
        protected override async ETTask Run(Scene scene, GameReadyStart args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIBattleComponent battleComp = uiComponent.Get(MrUIType.UIBattle).GetComponent<UIBattleComponent>();
            if (battleComp == null)
            {
                Log.Console($"=== GameRoom_GameReadyStart: uibattlecomponet is null. ===");
                return;
            }

            Log.Console($"=== GameRoom_GameReadyStart. ===");
            battleComp.ShowReadyTime(args.serverFrameTime, MrGameConstValue.MatchReadyTime);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    public class GameRoom_GameBattleStart : AEvent<Scene, GameBattleStart>
    {
        protected override async ETTask Run(Scene scene, GameBattleStart args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIBattleComponent battleComp = uiComponent.Get(MrUIType.UIBattle).GetComponent<UIBattleComponent>();
            if (battleComp == null)
            {
                Log.Console($"=== GameRoom_GameBattleStart: uibattlecomponet is null. ===");
                return;
            }

            Log.Console($"=== GameRoom_GameBattleStart. ===");
            battleComp.ShowReadyTime(args.serverFrameTime, MrGameConstValue.MatchTime);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    public class GameRoom_GameBattleFinish : AEvent<Scene, GameBattleFinish>
    {
        protected override async ETTask Run(Scene scene, GameBattleFinish args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIBattleComponent battleComp = uiComponent.Get(MrUIType.UIBattle).GetComponent<UIBattleComponent>();
            if (battleComp == null)
            {
                Log.Console($"=== GameRoom_GameBattleFinish: uibattlecomponet is null. ===");
                return;
            }

            Log.Console($"=== GameRoom_GameBattleFinish. ===");
            // Show result UI
            battleComp.ShowResult();

            await ETTask.CompletedTask;
        }
    }

}