using System;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class MrSceneChangeStart_AddComponent: AEvent<Scene, MrSceneChangeStart>
    {
        protected override async ETTask Run(Scene root, MrSceneChangeStart args)
        {
            try
            {
                Scene currentScene = root.CurrentScene();

                ResourcesLoaderComponent resourcesLoaderComponent = currentScene.GetComponent<ResourcesLoaderComponent>();

                // 加载场景资源
                await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/{currentScene.Name}.unity", LoadSceneMode.Single);
                // 切换到map场景

                //await SceneManager.LoadSceneAsync(currentScene.Name);

                currentScene.AddComponent<MrOperaComponent>();
                await currentScene.AddComponent<ShowFloatingTextComponent>().InitAsync();
                
                await MrUIHelper.Remove(root, MrUIType.UIMain);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }

    [Event(SceneType.Current)]
    public class MrEnterLobbySceneStart_AddComponent: AEvent<Scene, MrEnterLobbySceneStart>
    {
        protected override async ETTask Run(Scene root, MrEnterLobbySceneStart args)
        {
            try
            {
                //Scene currentScene = root.CurrentScene();

                // 加载loadingUI

                ResourcesLoaderComponent resourcesLoaderComponent = root.GetComponent<ResourcesLoaderComponent>();
                // 加载场景资源
                await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/MRMainScene.unity", LoadSceneMode.Single);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }

    [Event(SceneType.Current)]
    public class MrEnterLobbySceneFinish_CreateUIBattle: AEvent<Scene, MrEnterLobbySceneFinish>
    {
        protected override async ETTask Run(Scene scene, MrEnterLobbySceneFinish args)
        {
            await MrUIHelper.Create(scene, MrUIType.UIMain, UILayer.Mid);
        }
    }
}