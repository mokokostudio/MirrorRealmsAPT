using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TrapConfigCategory : Singleton<TrapConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TrapConfig> dict = new();
		
        public void Merge(object o)
        {
            TrapConfigCategory s = o as TrapConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TrapConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TrapConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TrapConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TrapConfig> GetAll()
        {
            return this.dict;
        }

        public TrapConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class TrapConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>UnitConfigId</summary>
		public int UnitConfigId { get; set; }
		/// <summary>TrapType</summary>
		public int TrapType { get; set; }
		/// <summary>x</summary>
		public int x { get; set; }
		/// <summary>z</summary>
		public int z { get; set; }
		/// <summary>Radius</summary>
		public int Radius { get; set; }

	}
}
