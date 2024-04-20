namespace ET.Server
{
	[MessageSessionHandler(SceneType.MrLobby)]
	public class MrC2Lobby_Ping__Handler : MessageSessionHandler<MrC2Lobby_Ping, MrLobby2C_Ping>
	{
		protected override async ETTask Run(Session session, MrC2Lobby_Ping request, MrLobby2C_Ping response)
		{
			response.Time = TimeInfo.Instance.ServerNow();
			await ETTask.CompletedTask;
		}
	}
}