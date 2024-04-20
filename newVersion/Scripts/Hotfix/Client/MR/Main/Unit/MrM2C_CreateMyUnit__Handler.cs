namespace ET.Client
{
	[MessageHandler(SceneType.Demo)]
	public class MrM2C_CreateMyUnit__Handler: MessageHandler<Scene, MrM2C_CreateMyUnit>
	{
		protected override async ETTask Run(Scene root, MrM2C_CreateMyUnit message)
		{
			// 通知场景切换协程继续往下走
			root.GetComponent<ObjectWait>().Notify(new MrWait_CreateMyUnit() {Message = message});
			await ETTask.CompletedTask;
		}
	}
}
