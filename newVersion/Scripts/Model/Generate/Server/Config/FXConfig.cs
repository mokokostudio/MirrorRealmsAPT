using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class FXConfigCategory : Singleton<FXConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, FXConfig> dict = new();
		
        public void Merge(object o)
        {
            FXConfigCategory s = o as FXConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public FXConfig Get(int id)
        {
            this.dict.TryGetValue(id, out FXConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (FXConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, FXConfig> GetAll()
        {
            return this.dict;
        }

        public FXConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class FXConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>资源</summary>
		public string PrefabKey { get; set; }
		/// <summary>存在总时长</summary>
		public int TotalTime { get; set; }
		/// <summary>是否跟随</summary>
		public int IsFollowUnit { get; set; }
		/// <summary>初始相对坐标x</summary>
		public int PosX { get; set; }
		/// <summary>初始相对坐标y</summary>
		public int PosY { get; set; }
		/// <summary>初始相对坐标z</summary>
		public int PosZ { get; set; }
		/// <summary>缩放x</summary>
		public int ScaleX { get; set; }
		/// <summary>缩放y</summary>
		public int ScaleY { get; set; }
		/// <summary>缩放z</summary>
		public int ScaleZ { get; set; }

	}
}
