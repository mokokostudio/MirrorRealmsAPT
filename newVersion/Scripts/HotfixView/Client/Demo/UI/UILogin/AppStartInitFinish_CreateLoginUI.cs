// using UnityEngine;
//
// namespace ET.Client
// {
// 	[Event(SceneType.Demo)]
// 	public class AppStartInitFinish_CreateLoginUI: AEvent<Scene, AppStartInitFinish>
// 	{
// 		protected override async ETTask Run(Scene root, AppStartInitFinish args)
// 		{
// #if LSDEMO
// 			await UIHelper.Create(root, UIType.UILogin, UILayer.Mid);
// #else
// 			//Debug.LogWarning("=== ET Demo AppStartInitFinish_CreateLoginUI. ===");
// 			await ETTask.CompletedTask;
// #endif
// 		}
// 	}
// }
