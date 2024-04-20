using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ShowFloatingTextComponent))]
    [FriendOf(typeof (ShowFloatingTextComponent))]
    public static partial class MrShowFloatingTextComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ShowFloatingTextComponent self)
        {
            self.ShowFloatingTextTemplate = null;
            self.ChildrenSortingOrder = 0;
        }

        [EntitySystem]
        private static void Destroy(this ShowFloatingTextComponent self)
        {
            self.ShowFloatingTextTemplate = null;
            self.ChildrenSortingOrder = 0;
        }

        public static async ETTask InitAsync(this ShowFloatingTextComponent self)
        {
            string assetsName = $"Assets/Bundles/Battle/FloatingText.prefab";
            self.ShowFloatingTextTemplate = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

            if (self.ShowFloatingTextTemplate == null)
            {
                Log.Error($"FloatingTextTemplate is null: {assetsName}");
            }
        }

        public static void Create(this ShowFloatingTextComponent self, float3 position, string text, int fontSize, Color color)
        {
            if (self.ShowFloatingTextTemplate == null)
            {
                // 可能还没加载完
                return;
            }

            var parentTransform = self.Root().GetComponent<GlobalComponent>().FloatingTextRoot;
            // TODO: 使用对象池
            GameObject go = UnityEngine.Object.Instantiate(self.ShowFloatingTextTemplate, parentTransform, true);
            go.transform.position = position;

            if (self.ChildrenCount() == 0)
            {
                self.ChildrenSortingOrder = 0;
            }
            else
            {
                self.ChildrenSortingOrder++;
            }

            self.AddChild<ShowFloatingText, GameObject>(go).Init(self.ChildrenSortingOrder, text, fontSize, color);
        }
    }
}