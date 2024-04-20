using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TriggerConfigCategory : Singleton<TriggerConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TriggerConfig> dict = new();
		
        public void Merge(object o)
        {
            TriggerConfigCategory s = o as TriggerConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TriggerConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TriggerConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TriggerConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TriggerConfig> GetAll()
        {
            return this.dict;
        }

        public TriggerConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class TriggerConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>UnitConfigId</summary>
		public int UnitConfigId { get; set; }
		/// <summary>ProjectileId</summary>
		public int ProjectileId { get; set; }

	}
}