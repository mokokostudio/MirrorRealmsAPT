namespace ET.Client
{
    public static partial class MrUnitHelper
    {
        public static Unit GetMyUnitFromClientScene(Scene root)
        {
            Scene currentScene = root.GetComponent<CurrentScenesComponent>().Scene;
            return GetMyUnitFromCurrentScene(currentScene);
        }

        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            MrPlayerComponent playerComponent = currentScene.Root().GetComponent<MrPlayerComponent>();
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }
    }
}