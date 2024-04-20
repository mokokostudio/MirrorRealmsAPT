using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PickableConfigCategory : Singleton<PickableConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PickableConfig> dict = new();
		
        public void Merge(object o)
        {
            PickableConfigCategory s = o as PickableConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PickableConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PickableConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PickableConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PickableConfig> GetAll()
        {
            return this.dict;
        }

        public PickableConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class PickableConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>模型</summary>
		public int UnitId { get; set; }
		/// <summary>获得道具</summary>
		public int ItemId { get; set; }
		/// <summary>获得道具数量</summary>
		public int ItemCount { get; set; }

	}
}
