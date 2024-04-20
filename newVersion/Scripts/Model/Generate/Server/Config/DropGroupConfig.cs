using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class DropGroupConfigCategory : Singleton<DropGroupConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, DropGroupConfig> dict = new();
		
        public void Merge(object o)
        {
            DropGroupConfigCategory s = o as DropGroupConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public DropGroupConfig Get(int id)
        {
            this.dict.TryGetValue(id, out DropGroupConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (DropGroupConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, DropGroupConfig> GetAll()
        {
            return this.dict;
        }

        public DropGroupConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class DropGroupConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>掉落Id</summary>
		public int[] _DropIdList;

		/// <summary>掉落Id</summary>
		[BsonIgnore]
		public int[] DropIdList => _DropIdList ??= new int[]{};

	}
}
