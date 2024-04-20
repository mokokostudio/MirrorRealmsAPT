using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class WeaponTypeConfigCategory : Singleton<WeaponTypeConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, WeaponTypeConfig> dict = new();
		
        public void Merge(object o)
        {
            WeaponTypeConfigCategory s = o as WeaponTypeConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public WeaponTypeConfig Get(int id)
        {
            this.dict.TryGetValue(id, out WeaponTypeConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (WeaponTypeConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, WeaponTypeConfig> GetAll()
        {
            return this.dict;
        }

        public WeaponTypeConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class WeaponTypeConfig: ProtoObject, IConfig
	{
		/// <summary>ID</summary>
		public int Id { get; set; }
		/// <summary>模式</summary>
		public string Model { get; set; }
		/// <summary>描述</summary>
		public string Desc { get; set; }
		/// <summary>对应的WeaponConfig的Id</summary>
		public int ToWeaponId { get; set; }
		/// <summary>可防御</summary>
		public int CanDef { get; set; }
		/// <summary>装备位置</summary>
		public int EquipPos1 { get; set; }
		/// <summary>装备位置</summary>
		public int EquipPos2 { get; set; }

	}
}
