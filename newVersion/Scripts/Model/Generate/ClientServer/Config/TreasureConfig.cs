using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TreasureConfigCategory : Singleton<TreasureConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TreasureConfig> dict = new();
		
        public void Merge(object o)
        {
            TreasureConfigCategory s = o as TreasureConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TreasureConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TreasureConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TreasureConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TreasureConfig> GetAll()
        {
            return this.dict;
        }

        public TreasureConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class TreasureConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>UnitConfigId</summary>
		public int UnitConfigId { get; set; }
		/// <summary>掉落组</summary>
		public int DropGroupId { get; set; }

	}
}
