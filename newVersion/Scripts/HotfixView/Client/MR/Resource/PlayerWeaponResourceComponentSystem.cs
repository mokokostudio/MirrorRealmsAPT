using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (PlayerWeaponResourceComponent))]
    [FriendOf(typeof (PlayerWeaponResourceComponent))]
    public static partial class PlayerWeaponResourceComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PlayerWeaponResourceComponent self)
        {
            self.Dict.Clear();
        }

        [EntitySystem]
        private static void Destroy(this PlayerWeaponResourceComponent self)
        {
            self.Dict.Clear();
        }

        public static async ETTask InitAsync(this PlayerWeaponResourceComponent self)
        {
            self.Dict.Clear();

            var weapons = WeaponConfigCategory.Instance.GetAll();

            string assetsName = $"Assets/Bundles/Battle/Weapons.prefab";
            GameObject bundleGameObject = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            if (bundleGameObject == null)
            {
                Log.Error($"加载武器资源失败: {assetsName}");
            }
            else
            {
                ReferenceCollector referenceCollector = bundleGameObject.GetComponent<ReferenceCollector>();

                foreach (WeaponConfig weaponConfig in weapons.Values)
                {
                    foreach (string prefabName in weaponConfig.Prefabs)
                    {
                        GameObject prefab = referenceCollector.Get<GameObject>(prefabName);
                        if (prefab == null)
                        {
                            continue;
                        }

                        self.Dict[prefabName] = prefab;
                    }
                }
            }
        }

        public static GameObject GetWeaponPrefab(this PlayerWeaponResourceComponent self, string name)
        {
            self.Dict.TryGetValue(name, out var prefab);
            return prefab;
        }
    }
}