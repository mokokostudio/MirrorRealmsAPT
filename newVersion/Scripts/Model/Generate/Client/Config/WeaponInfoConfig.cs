using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class WeaponInfoConfigCategory : Singleton<WeaponInfoConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, WeaponInfoConfig> dict = new();
		
        public void Merge(object o)
        {
            WeaponInfoConfigCategory s = o as WeaponInfoConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public WeaponInfoConfig Get(int id)
        {
            this.dict.TryGetValue(id, out WeaponInfoConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (WeaponInfoConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, WeaponInfoConfig> GetAll()
        {
            return this.dict;
        }

        public WeaponInfoConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class WeaponInfoConfig: ProtoObject, IConfig
	{
		/// <summary>ID</summary>
		public int Id { get; set; }
		/// <summary>类型</summary>
		public int WeaponType { get; set; }
		/// <summary>品质（N=0，R，SR，SSR）</summary>
		public int Quality { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>图标</summary>
		public string Icon { get; set; }
		/// <summary>卡片1</summary>
		public int Card1 { get; set; }
		/// <summary>卡片2</summary>
		public int Card2 { get; set; }
		/// <summary>卡片3</summary>
		public int Card3 { get; set; }
		/// <summary>卡片4</summary>
		public int Cards4 { get; set; }
		/// <summary>卡片5</summary>
		public int Cards5 { get; set; }
		/// <summary></summary>
		public string Weapon1 { get; set; }
		/// <summary></summary>
		public string Weapon2 { get; set; }
		/// <summary>描述</summary>
		public string Desc { get; set; }

	}
}
