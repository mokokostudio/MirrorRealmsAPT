using UnityEngine;

namespace ET.Client
{
    public static class FXHelper
    {
        public static async ETTask<Unit> CreateFX(Unit target, int configId)
        {
            FXConfig config = FXConfigCategory.Instance.Get(configId);

            string assetsName = $"Assets/Bundles/Battle/FXs.prefab";
            GameObject bundleGameObject = await target.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject prefab = bundleGameObject.Get<GameObject>(config.PrefabKey);
            if (prefab == null)
            {
                Log.Error($"FXHelper.CreateFX() prefab is null, configId: {configId}");
                return null;
            }

            GameObject fxGameObject = UnityEngine.Object.Instantiate(prefab);

            var offset = new Vector3(config.PosX, config.PosY, config.PosZ) * 0.001f;
            if (config.IsFollowUnit != 0)
            {
                fxGameObject.transform.SetParent(target.GetComponent<MrGameObjectComponent>().GameObject.transform, false);
                fxGameObject.transform.localPosition = offset;
            }
            else
            {
                fxGameObject.transform.SetParent(target.Root().GetComponent<GlobalComponent>().UnitRoot, false);
                var unitPos = target.GetComponent<MrGameObjectComponent>().GameObject.transform.position;
                var pos = unitPos + offset;
                fxGameObject.transform.position = pos;
            }

            Unit fxUnit = ClientUnitFactory.CreateFXUnit(target.Scene());
            fxUnit.AddComponent<MrGameObjectComponent>().GameObject = fxGameObject;
            fxGameObject.transform.localScale = new Vector3(config.ScaleX, config.ScaleY, config.ScaleZ) * 0.001f;
            OutDurationTime(fxUnit, config.TotalTime).Coroutine();

            return fxUnit;
        }

        private static async ETTask OutDurationTime(Unit unit, float durationTime)
        {
            if (durationTime <= 0)
            {
                return;
            }

            EntityRef<Unit> entityRef = unit;
            await unit.Root().GetComponent<TimerComponent>().WaitAsync((long)durationTime);
            if ((Unit)entityRef == null)
            {
                return;
            }

            unit.Scene()?.GetComponent<UnitComponent>()?.Remove(unit.Id);
        }
    }
}