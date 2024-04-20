using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (UI_IconResourceComponent))]
    [FriendOfAttribute(typeof (UI_IconResourceComponent))]
    public static partial class UI_IconResourceComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UI_IconResourceComponent self)
        {
            self.Dict.Clear();
        }

        [EntitySystem]
        private static void Destroy(this UI_IconResourceComponent self)
        {
            self.Dict.Clear();
        }

        public static async ETTask InitAsync(this UI_IconResourceComponent self)
        {
            self.Dict.Clear();

            string assetsName = $"Assets/Bundles/UI/Icon.prefab";

            GameObject bundleGameObject = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

            if (bundleGameObject == null)
            {
                Log.Error($"加载icon资源失败, missing prefab: {assetsName}");
                return;
            }

            var referenceCollector = bundleGameObject.GetComponent<ReferenceCollector>();
            if (referenceCollector == null)
            {
                Log.Error($"加载icon资源失败, missing ReferenceCollector: {assetsName}");
                return;
            }

            foreach (KeyValuePair<string, UnityEngine.Object> pair in referenceCollector.GetAll())
            {
                self.Dict[pair.Key] = pair.Value as Sprite;

                if (pair.Value == null)
                {
                    Log.Error($"加载icon资源失败, missing Sprite: {pair.Key}");
                }
            }
        }

        public static Sprite Get(this UI_IconResourceComponent self, string name)
        {
            self.Dict.TryGetValue(name, out var sprite);
            return sprite;
        }
    }
}