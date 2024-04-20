using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MrAfterUnitCreate_CreateUnitView: AEvent<Scene, MrAfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, MrAfterUnitCreate args)
        {
            Unit unit = args.Unit;

            string assetsName = $"Assets/Bundles/Battle/Units.prefab";
            GameObject bundleGameObject = await unit.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject prefab = bundleGameObject.Get<GameObject>(unit.Config().PrefabKey);
            GameObject go = prefab != null? UnityEngine.Object.Instantiate(prefab) : new GameObject("Empty");
            go.transform.SetParent(unit.Root().GetComponent<GlobalComponent>().UnitRoot, true);
            go.transform.position = unit.Position;
            unit.AddComponent<MrGameObjectComponent>().GameObject = go;
            //
            unit.AddComponent<UnitAudio>();

            switch (unit.UnitType())
            {
                case UnitType.Player:
                {
                    unit.AddComponent<PlayerAnimationComponent>();
                    //
                    await unit.AddComponent<HpBar>().InitAsync();
                }
                    break;
                case UnitType.Monster:
                {
                    // 暂时用玩家的模型来做演示
                    bool usePlayer = true;
                    if (usePlayer)
                    {
                        unit.AddComponent<PlayerAnimationComponent>();
                    }
                    else
                    {
                        // unit.AddComponent<AnimatorComponent>();
                    }

                    //
                    await unit.AddComponent<HpBar>().InitAsync();
                }
                    break;
                case UnitType.Pickable:
                {
                    // 等待 DropCreated__EventHandler.cs 处理
                    go.gameObject.SetActive(false);
                }
                    break;
                case UnitType.Trap:
                {
                }
                    break;
                case UnitType.Treasure:
                {
                }
                    break;
            }
        }
    }
}