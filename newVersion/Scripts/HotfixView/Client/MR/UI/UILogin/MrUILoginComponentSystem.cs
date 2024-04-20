using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrUILoginComponent))]
    [FriendOf(typeof(MrUILoginComponent))]
    public static partial class MrUILoginComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrUILoginComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.loginBtn = rc.Get<GameObject>("LoginBtn");
            self.loginBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnLogin(); });

            self.channel = rc.Get<GameObject>("DpdChannel");

            // TODO: No use now   2023.12.26
            string[] channelNames = new string[4] { "Local", "China", "Local-Usagi", "US"};
            for (int i = 0; i < 4; i++)
            {
                self.channel.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData(channelNames[i]));
            }

            self.account = rc.Get<GameObject>("Account");
            self.password = rc.Get<GameObject>("Password");
        }


        public static void OnLogin(this MrUILoginComponent self)
        {
            // TODO:     2023.12.26
            //int channelIndex = self.channel.GetComponent<TMP_Dropdown>().value;
            //PlayerPrefs.SetInt("ChannelIndex", channelIndex);
            //List<ChannelConfig> channels = new List<ChannelConfig>(new ChannelConfig[4] {
            //    new ChannelConfig() { name = "Local", ip = "127.0.0.1", portTcp = 12345, portUdp = 12346},
            //    new ChannelConfig() { name = "China", ip = "124.223.116.182", portTcp = 12345, portUdp = 12346},
            //    new ChannelConfig() { name = "Local-Usagi", ip = "192.168.110.138", portTcp = 12345, portUdp = 12346},
            //    new ChannelConfig() { name = "US", ip = "47.251.11.114", portTcp = 12345, portUdp = 12346}
            //});

            MrLoginHelper.Login(
                self.Root(),
                self.account.GetComponent<TMP_InputField>().text,
                self.password.GetComponent<TMP_InputField>().text).Coroutine();
        }
    }
}
