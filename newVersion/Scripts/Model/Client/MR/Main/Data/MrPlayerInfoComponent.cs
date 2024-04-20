using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 管理Player的信息和数据
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class MrPlayerInfoComponent: Entity, IAwake, IDestroy
    {
        public List<int> ItemsIdAry;
        public List<int> ItemsNumberAry;
        // WeaponId可以重复
        public int[] WeaponsIdAry;
        public ulong Coins;
    }

}

// EOF