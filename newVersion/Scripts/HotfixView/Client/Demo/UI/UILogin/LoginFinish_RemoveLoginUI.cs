// namespace ET.Client
// {
// 	[Event(SceneType.Demo)]
// 	public class LoginFinish_RemoveLoginUI: AEvent<Scene, LoginFinish>
// 	{
// 		protected override async ETTask Run(Scene scene, LoginFinish args)
// 		{
// #if LSDEMO
// 			await UIHelper.Remove(scene, UIType.UILogin);
// #else
// 			await ETTask.CompletedTask;
// #endif
// 		}
// 	}
// }
