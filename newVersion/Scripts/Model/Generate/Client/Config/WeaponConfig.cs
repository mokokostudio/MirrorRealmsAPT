using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class WeaponConfigCategory : Singleton<WeaponConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, WeaponConfig> dict = new();
		
        public void Merge(object o)
        {
            WeaponConfigCategory s = o as WeaponConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public WeaponConfig Get(int id)
        {
            this.dict.TryGetValue(id, out WeaponConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (WeaponConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, WeaponConfig> GetAll()
        {
            return this.dict;
        }

        public WeaponConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class WeaponConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>人物动画组</summary>
		public string AnimationGroup { get; set; }
		/// <summary>模型</summary>
		public string[] _Prefabs;

		/// <summary>模型</summary>
		[BsonIgnore]
		public string[] Prefabs => _Prefabs ??= new string[]{};
		/// <summary>装备位置</summary>
		public int[] _EquipPosition;

		/// <summary>装备位置</summary>
		[BsonIgnore]
		public int[] EquipPosition => _EquipPosition ??= new int[]{};
		/// <summary>攻击力</summary>
		public int Damage { get; set; }
		/// <summary>武器模式</summary>
		public int ArmWeaponMode { get; set; }
		/// <summary>装备技</summary>
		public string EquipSkill { get; set; }
		/// <summary>移动速度修正</summary>
		public int MovementSpeedModifier { get; set; }
		/// <summary>普通攻击</summary>
		public string[] _Attack;

		/// <summary>普通攻击</summary>
		[BsonIgnore]
		public string[] Attack => _Attack ??= new string[]{};
		/// <summary>主动技能</summary>
		public string[] _Skills;

		/// <summary>主动技能</summary>
		[BsonIgnore]
		public string[] Skills => _Skills ??= new string[]{};
		/// <summary>闪避技</summary>
		public string Slide { get; set; }

	}
}
