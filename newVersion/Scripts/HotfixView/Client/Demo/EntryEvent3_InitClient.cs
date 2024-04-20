// using System;
// using System.Collections.Generic;
// using System.IO;
// using UnityEngine.SceneManagement;
//
// namespace ET.Client
// {
//     [Event(SceneType.Main)]
//     public class EntryEvent3_InitClient: AEvent<Scene, EntryEvent3>
//     {
//         protected override async ETTask Run(Scene root, EntryEvent3 args)
//         {
//             GlobalComponent globalComponent = root.AddComponent<GlobalComponent>();
//             root.AddComponent<UIGlobalComponent>();
//             root.AddComponent<UIComponent>();
//             ResourcesLoaderComponent resourcesLoaderComponent = root.AddComponent<ResourcesLoaderComponent>();
//             root.AddComponent<PlayerComponent>();
//             root.AddComponent<CurrentScenesComponent>();
//
//             // 根据配置修改掉Main Fiber的SceneType
//             SceneType sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
//             root.SceneType = sceneType;
//             //
//             await root.AddComponent<PlayerAnimationResourceComponent>().InitAsync();
//             await root.AddComponent<PlayerWeaponResourceComponent>().InitAsync();
//             await root.AddComponent<UI_IconResourceComponent>().InitAsync();
//
// #if !LSDEMO
//             await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/MRMainScene.unity", LoadSceneMode.Single);
// #endif
//             await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
//         }
//     }
// }