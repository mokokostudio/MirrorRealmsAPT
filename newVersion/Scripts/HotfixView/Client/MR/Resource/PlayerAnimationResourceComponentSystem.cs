using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (PlayerAnimationResourceComponent))]
    [FriendOf(typeof (PlayerAnimationResourceComponent))]
    public static partial class PlayerAnimationResourceComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PlayerAnimationResourceComponent self)
        {
            self.Dict.Clear();
        }

        [EntitySystem]
        private static void Destroy(this PlayerAnimationResourceComponent self)
        {
            self.Dict.Clear();
        }

        public static async ETTask InitAsync(this PlayerAnimationResourceComponent self)
        {
            self.Dict.Clear();

            string assetsName = $"Assets/Bundles/Battle/AnimationReference.prefab";

            GameObject bundleGameObject;
            //if (Define.IsEditor)
            //{
            //    // TODO: Editor下加载资源
            //    bundleGameObject = null;
            //}
            //else
            {
                bundleGameObject = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            }

            if (bundleGameObject == null)
            {
                Log.Error($"加载动画资源失败, missing prefab: {assetsName}");
                return;
            }

            var referenceCollector = bundleGameObject.GetComponent<ReferenceCollector>();
            if (referenceCollector == null)
            {
                Log.Error($"加载动画资源失败, missing ReferenceCollector: {assetsName}");
                return;
            }

            // 加载animations
            //TextAsset t = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>($"Assets/ABAssets/Animations/AnimationsName.txt");
            //if (t != null)
            //{
            //    string[] names = t.text.Split("\r\n");
            //    foreach (string n in names)
            //    {
            //        if (string.IsNullOrEmpty(n)) continue;
            //        //ScriptableObject clip = await ResourcesComponent.Instance.LoadAssetAsync<ScriptableObject>(n);
            //        //if (clip == null) continue;

            //        //CharacterAnimationDataClip c = clip as CharacterAnimationDataClip;
            //        //if (c == null) continue;
            //        CharacterAnimationDataClip c = await ResourcesComponent.Instance.LoadAssetAsync<CharacterAnimationDataClip>(n);
            //        if (c == null) continue;

            //        self.Dict[c.skillConfig.Name] = c;
            //    }
            //}
            foreach (KeyValuePair<string, UnityEngine.Object> pair in referenceCollector.GetAll())
            {
                var clip = pair.Value as CharacterAnimationDataClip;

                if (clip != null)
                {
                    self.Dict[clip.skillConfig.Name] = clip;
                }
                else
                {
                    Log.Error(
                        $"加载配置失败, missing CharacterAnimationDataClip: {pair.Key}, {pair.Value.GetType()}, {typeof(CharacterAnimationDataClip)}");
                }
            }
        }

        public static CharacterAnimationDataClip Get(this PlayerAnimationResourceComponent self, string key)
        {
            self.Dict.TryGetValue(key, out CharacterAnimationDataClip characterAnimationDataClip);
            return characterAnimationDataClip;
        }

        public static CharacterAnimationDataClip Get(this PlayerAnimationResourceComponent self, string posture, ArmWeaponMode armWeaponMode,
        string name)
        {
            string mode = WeaponConfigCategory.Instance.Get((int)armWeaponMode).AnimationGroup;
            string key = $"{posture}_{mode}_{name}";
            self.Dict.TryGetValue(key, out CharacterAnimationDataClip characterAnimationDataClip);
            return characterAnimationDataClip;
        }
    }
}