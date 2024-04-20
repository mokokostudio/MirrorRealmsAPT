using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace ET
{
    [Invoke]
    public class RecastFileReader: AInvokeHandler<NavmeshComponent.RecastFileLoader, byte[]>
    {
        public override byte[] Handle(NavmeshComponent.RecastFileLoader args)
        {
            if (Define.IsEditor || Define.EnableDll)
            {
                return File.ReadAllBytes(Path.Combine("../Config/Recast", args.Name));
            }
            else
            {
                //string[] maps = new string[] { "map1", "map2", "map3" };
                //foreach (var mapName in maps)
                //{
                //    string path = $"Assets/Bundles/Recast/{mapName}.bytes";
                //    TextAsset ta = ResourcesComponent.Instance.LoadAssetSync<TextAsset>(path);
                //}
                byte[] bytes = RecastLoader.Instance.GetRecast(args.Name);
                return bytes;
            }


            throw new Exception("not load");
        }
    }
}