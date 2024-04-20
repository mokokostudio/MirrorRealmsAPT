using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class MrMatch : Entity, IAwake
    {
        public List<long> waitMatchPlayers;
    }

}