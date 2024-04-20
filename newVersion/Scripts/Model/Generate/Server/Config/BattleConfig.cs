using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class BattleConfigCategory : Singleton<BattleConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, BattleConfig> dict = new();
		
        public void Merge(object o)
        {
            BattleConfigCategory s = o as BattleConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public BattleConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BattleConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BattleConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BattleConfig> GetAll()
        {
            return this.dict;
        }

        public BattleConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class BattleConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Key</summary>
		public string Key { get; set; }
		/// <summary>值</summary>
		public int Value { get; set; }

	}
}
