using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ET.Client
{
    [EntitySystemOf(typeof(MrPlayerInfoComponent))]
    [FriendOf(typeof(MrPlayerInfoComponent))]
    public static partial class MrPlayerInfoComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MrPlayerInfoComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this MrPlayerInfoComponent self)
        {

        }

        public static void InitPlayerInfos(this MrPlayerInfoComponent self, int[] itemIds, int[] itemNumbers, int[] weaponIds)
        {
            self.ItemsIdAry = new List<int>(itemIds);
            self.ItemsNumberAry = new List<int>(itemNumbers);
            self.WeaponsIdAry = weaponIds;
        }
    }
}

// EOF