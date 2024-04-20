namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIBattle: AEvent<Scene, MrSceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, MrSceneChangeFinish args)
        {
            scene.AddComponent<BattleCameraComponent>();
            await MrUIHelper.Create(scene, MrUIType.UIBattle, UILayer.Mid);
        }
    }
}