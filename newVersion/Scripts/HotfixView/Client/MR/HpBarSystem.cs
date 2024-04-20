using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (HpBar))]
    [FriendOf(typeof (HpBar))]
    [FriendOf(typeof (MrPlayerInfo))]
    public static partial class HpBarSystem
    {
        [EntitySystem]
        private static void Awake(this HpBar self)
        {
            self.Camera = Camera.main;
        }

        public static async ETTask InitAsync(this HpBar self)
        {
            var unit = self.GetParent<Unit>();
            bool isMyUnit = unit.Id == self.Root().GetComponent<MrPlayerComponent>().MyId;
            //
            string assetsName = $"Assets/Bundles/Battle/HPBar.prefab";
            GameObject prefab = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            self.GameObject = UnityEngine.Object.Instantiate(prefab, self.GetParent<Unit>().GetComponent<MrGameObjectComponent>().GameObject.transform,
                false);
            self.GameObject.transform.localPosition = new Vector3(0, 1.8f, 0);
            //
            self.HPSlider = self.GameObject.Get<GameObject>(isMyUnit? "Slider1" : "Slider2").GetComponent<Slider>();
            //
            self.GameObject.Get<GameObject>("NameTxt1").SetActive(isMyUnit);
            self.GameObject.Get<GameObject>("NameTxt2").SetActive(!isMyUnit);
            self.GameObject.Get<GameObject>("Slider1").SetActive(isMyUnit);
            self.GameObject.Get<GameObject>("Slider2").SetActive(!isMyUnit);
            //
            string name = unit.GetComponent<MrPlayerInfo>()?.Name ?? unit.Config().Name;
            self.GameObject.Get<GameObject>(isMyUnit? "NameTxt1" : "NameTxt2").GetComponent<TextMeshProUGUI>().text = name;
        }

        [EntitySystem]
        private static void Destroy(this HpBar self)
        {
            UnityEngine.Object.Destroy(self.GameObject);
            self.Camera = null;
            self.HPSlider = null;
        }

        [EntitySystem]
        private static void LateUpdate(this HpBar self)
        {
            self.UpdateHp();
            self.UpdateRotation();
        }

        private static void UpdateRotation(this HpBar self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.Camera ??= Camera.main;
            if (self.Camera == null)
            {
                return;
            }

            self.GameObject.transform.rotation = self.Camera.transform.rotation;
        }

        private static void UpdateHp(this HpBar self)
        {
            if (self.HPSlider == null)
            {
                return;
            }

            var unit = self.GetParent<Unit>();
            var numericComponent = unit.GetComponent<NumericComponent>();
            float hp = numericComponent.GetAsInt(NumericType.Hp);
            float maxHp = math.max(1, numericComponent.GetAsInt(NumericType.MaxHp));
            float hpPercent = hp / maxHp;

            self.HPSlider.value = hpPercent > self.HPSlider.value? hpPercent : math.lerp(self.HPSlider.value, hpPercent, 0.1f);
        }
    }
}