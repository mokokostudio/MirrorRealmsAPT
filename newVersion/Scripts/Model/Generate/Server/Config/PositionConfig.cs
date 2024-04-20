using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PositionConfigCategory : Singleton<PositionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PositionConfig> dict = new();
		
        public void Merge(object o)
        {
            PositionConfigCategory s = o as PositionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PositionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PositionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PositionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PositionConfig> GetAll()
        {
            return this.dict;
        }

        public PositionConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class PositionConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>坐标x</summary>
		public int PosX { get; set; }
		/// <summary>坐标z</summary>
		public int PosZ { get; set; }

	}
}
