using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(UI))]
	public class MrUILoadingComponent : Entity, IAwake
	{
		public Slider slider;
	}
}
