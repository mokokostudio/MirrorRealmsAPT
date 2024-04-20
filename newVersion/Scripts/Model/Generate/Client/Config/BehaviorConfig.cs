using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class BehaviorConfigCategory : Singleton<BehaviorConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, BehaviorConfig> dict = new();
		
        public void Merge(object o)
        {
            BehaviorConfigCategory s = o as BehaviorConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public BehaviorConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BehaviorConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BehaviorConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BehaviorConfig> GetAll()
        {
            return this.dict;
        }

        public BehaviorConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class BehaviorConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>技能行为类型(BehaviorType)</summary>
		public int Type { get; set; }
		/// <summary>参数</summary>
		public string[] _Params;

		/// <summary>参数</summary>
		[BsonIgnore]
		public string[] Params => _Params ??= new string[]{};

	}
}
