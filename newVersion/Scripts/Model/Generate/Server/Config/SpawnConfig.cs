using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SpawnConfigCategory : Singleton<SpawnConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SpawnConfig> dict = new();
		
        public void Merge(object o)
        {
            SpawnConfigCategory s = o as SpawnConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SpawnConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SpawnConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SpawnConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SpawnConfig> GetAll()
        {
            return this.dict;
        }

        public SpawnConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class SpawnConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>坐标列表</summary>
		public int[] _PositionList;

		/// <summary>坐标列表</summary>
		[BsonIgnore]
		public int[] PositionList => _PositionList ??= new int[]{};

	}
}
