namespace ET.Server
{
	[ComponentOf(typeof(MrPlayer))]
	public class MrPlayerSession : Entity, IAwake
	{
		private EntityRef<Session> session;

		public Session Session
		{
			get
			{
				return this.session;
			}
			set
			{
				this.session = value;
			}
		}
	}
}