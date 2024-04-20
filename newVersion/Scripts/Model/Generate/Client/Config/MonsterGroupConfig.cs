using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MonsterGroupConfigCategory : Singleton<MonsterGroupConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MonsterGroupConfig> dict = new();
		
        public void Merge(object o)
        {
            MonsterGroupConfigCategory s = o as MonsterGroupConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MonsterGroupConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MonsterGroupConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MonsterGroupConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MonsterGroupConfig> GetAll()
        {
            return this.dict;
        }

        public MonsterGroupConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class MonsterGroupConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>坐标x</summary>
		public float PosX { get; set; }
		/// <summary>坐标y</summary>
		public float PosY { get; set; }
		/// <summary>坐标z</summary>
		public float PosZ { get; set; }
		/// <summary>范围</summary>
		public int Range { get; set; }
		/// <summary>重生间隔</summary>
		public int ReliveTime { get; set; }

	}
}
