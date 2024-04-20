namespace ET.Client
{
    public static class MrSceneChangeHelper
    {
        // 场景切换协程
        public static async ETTask SceneChangeTo(Scene root, string sceneName, long sceneInstanceId)
        {
            root.RemoveComponent<AIComponent>();

            CurrentScenesComponent currentScenesComponent = root.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = MrCurrentSceneFactory.Create(sceneInstanceId, sceneName, currentScenesComponent);
            // TODO:  2024.01.18
            currentScene.AddComponent<ObjectWait>();

            UnitComponent unitComponent = currentScene.AddComponent<UnitComponent>();

            // 可以订阅这个事件中创建Loading界面
            EventSystem.Instance.Publish(root, new MrSceneChangeStart());

            // 等待CreateMyUnit的消息
            MrWait_CreateMyUnit mrWaitCreateMyUnit = await root.GetComponent<ObjectWait>().Wait<MrWait_CreateMyUnit>();

            Unit unit = MrUnitFactory.Create(currentScene, mrWaitCreateMyUnit.Message.Unit);
            unitComponent.Add(unit);
            root.RemoveComponent<AIComponent>();

            EventSystem.Instance.Publish(currentScene, new MrSceneChangeFinish());
            // 通知等待场景切换的协程
            root.GetComponent<ObjectWait>().Notify(new MrWait_SceneChangeFinish());
        }

        public static async ETTask ExitCurrentScene(Scene root)
        {
            //CurrentScenesComponent currentScenesComponent = root.GetComponent<CurrentScenesComponent>();
            //currentScenesComponent?.Scene?.Dispose(); // 删除CurrentScene

            // 加载推出战斗的loading（有必要的话）
            EventSystem.Instance.Publish(root, new MrEnterLobbySceneStart());
            await ETTask.CompletedTask;

            EventSystem.Instance.Publish(root, new MrEnterLobbySceneFinish());
            // 通知等待场景切换的协程
            root.GetComponent<ObjectWait>().Notify(new WaitType.Wait_ExitCurrentSceneFinish());
        }
    }
}