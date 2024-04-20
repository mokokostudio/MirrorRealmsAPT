using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class MrLobbySessionKeyMgr : Entity, IAwake
    {
        public readonly Dictionary<long, string> sessionKey = new();
    }
}