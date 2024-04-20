using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Main)]
    public class MrEntryEvent3_InitClient: AEvent<Scene, EntryEvent3>
    {
        protected override async ETTask Run(Scene root, EntryEvent3 args)
        {
            GlobalComponent globalComponent = root.AddComponent<GlobalComponent>();
            root.AddComponent<UIGlobalComponent>();
            root.AddComponent<UIComponent>();
            ResourcesLoaderComponent resourcesLoaderComponent = root.AddComponent<ResourcesLoaderComponent>();
            root.AddComponent<MrPlayerComponent>();
            root.AddComponent<CurrentScenesComponent>();

            root.AddComponent<MrPlayerInfoComponent>();

            // 根据配置修改掉Main Fiber的SceneType
            SceneType sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
            root.SceneType = sceneType;
            //
            await root.AddComponent<PlayerAnimationResourceComponent>().InitAsync();
            await root.AddComponent<PlayerWeaponResourceComponent>().InitAsync();
            await root.AddComponent<UI_IconResourceComponent>().InitAsync();


            await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/MRMainScene.unity", LoadSceneMode.Single);

            await EventSystem.Instance.PublishAsync(root, new MrAppStartInitFinish());
        }
    }
}