namespace ET.Server
{
	[ComponentOf(typeof(Session))]
	public class MrSessionPlayer : Entity, IAwake, IDestroy
	{
		private EntityRef<MrPlayer> player;

		public MrPlayer Player
		{
			get
			{
				return this.player;
			}
			set
			{
				this.player = value;
			}
		}
	}
}