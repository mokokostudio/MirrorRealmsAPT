using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class MrPlayerMgr: Entity, IAwake, IDestroy
    {
        public Dictionary<string, MrPlayer> dictionary = new();
    }
}