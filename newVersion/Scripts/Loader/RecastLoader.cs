using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using HybridCLR;
using UnityEngine;

namespace ET
{
    public class RecastLoader : Singleton<RecastLoader>, ISingletonAwake
    {
        private Assembly assembly;

        private Dictionary<string, byte[]> recasts;

        public void Awake()
        {
        }

        public async ETTask DownloadAsync()
        {
            recasts = new Dictionary<string, byte[]>();
            //if (!Define.IsEditor)
            {
                string[] maps = new string[] { "Map1", "Map2", "Map3" };
                foreach (var mapName in maps)
                {
                    string path = $"Assets/Bundles/Recast/{mapName}.bytes";
                    TextAsset ta = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>(path);
                    recasts[mapName] = ta.bytes;
                }
            }
        }

        public byte[] GetRecast(string name)
        {
            byte[] tes = null;
            if (!recasts.TryGetValue(name, out tes))
            {
                // TODO: 
            }
            return tes;
        }
    }
}