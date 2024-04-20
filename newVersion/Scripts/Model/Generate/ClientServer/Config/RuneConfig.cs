using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class RuneConfigCategory : Singleton<RuneConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, RuneConfig> dict = new();
		
        public void Merge(object o)
        {
            RuneConfigCategory s = o as RuneConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public RuneConfig Get(int id)
        {
            this.dict.TryGetValue(id, out RuneConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (RuneConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, RuneConfig> GetAll()
        {
            return this.dict;
        }

        public RuneConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class RuneConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>使用效果(技能)</summary>
		public string Skill { get; set; }

	}
}
