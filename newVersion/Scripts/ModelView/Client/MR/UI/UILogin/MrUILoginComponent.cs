using UnityEngine;

namespace ET.Client
{
	[ComponentOf(typeof(UI))]
	public class MrUILoginComponent: Entity, IAwake
	{
		public GameObject account;
		public GameObject password;
		public GameObject channel;
		public GameObject loginBtn;
	}
}
