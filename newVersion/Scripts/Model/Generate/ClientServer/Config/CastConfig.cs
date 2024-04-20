using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class CastConfigCategory : Singleton<CastConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, CastConfig> dict = new();
		
        public void Merge(object o)
        {
            CastConfigCategory s = o as CastConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public CastConfig Get(int id)
        {
            this.dict.TryGetValue(id, out CastConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (CastConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, CastConfig> GetAll()
        {
            return this.dict;
        }

        public CastConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class CastConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>通知客户端类型</summary>
		public int NoticeClientType { get; set; }
		/// <summary>冷却时间</summary>
		public int CoolDown { get; set; }
		/// <summary>状态技能</summary>
		public int StatusSkill { get; set; }
		/// <summary>总时长</summary>
		public int TotalTime { get; set; }
		/// <summary>目标选择方式</summary>
		public int SelectType { get; set; }
		/// <summary>目标选择参数</summary>
		public string[] _SelectParams;

		/// <summary>目标选择参数</summary>
		[BsonIgnore]
		public string[] SelectParams => _SelectParams ??= new string[]{};
		/// <summary>技能命中目标时间点</summary>
		public int[] _ImpactBehaviorTimes;

		/// <summary>技能命中目标时间点</summary>
		[BsonIgnore]
		public int[] ImpactBehaviorTimes => _ImpactBehaviorTimes ??= new int[]{};
		/// <summary>技能命中目标行为</summary>
		public int[] _ImpactBehaviors;

		/// <summary>技能命中目标行为</summary>
		[BsonIgnore]
		public int[] ImpactBehaviors => _ImpactBehaviors ??= new int[]{};
		/// <summary>命中目标施加Buff</summary>
		public int[] _ImpactBuffs;

		/// <summary>命中目标施加Buff</summary>
		[BsonIgnore]
		public int[] ImpactBuffs => _ImpactBuffs ??= new int[]{};
		/// <summary>技能命中自身时间点</summary>
		public int[] _SelfImpactBehaviorTimes;

		/// <summary>技能命中自身时间点</summary>
		[BsonIgnore]
		public int[] SelfImpactBehaviorTimes => _SelfImpactBehaviorTimes ??= new int[]{};
		/// <summary>技能命中自身行为</summary>
		public int[] _SelfImpactBehaviors;

		/// <summary>技能命中自身行为</summary>
		[BsonIgnore]
		public int[] SelfImpactBehaviors => _SelfImpactBehaviors ??= new int[]{};
		/// <summary>命中自身施加Buff</summary>
		public int[] _SelfImpactBuffs;

		/// <summary>命中自身施加Buff</summary>
		[BsonIgnore]
		public int[] SelfImpactBuffs => _SelfImpactBuffs ??= new int[]{};
		/// <summary>技能结束行为</summary>
		public int[] _FinishBehaviors;

		/// <summary>技能结束行为</summary>
		[BsonIgnore]
		public int[] FinishBehaviors => _FinishBehaviors ??= new int[]{};
		/// <summary>技能开始时的自身特效</summary>
		public int[] _StartFXs;

		/// <summary>技能开始时的自身特效</summary>
		[BsonIgnore]
		public int[] StartFXs => _StartFXs ??= new int[]{};
		/// <summary>技能命中时的目标特效</summary>
		public int[] _ImpactFXs;

		/// <summary>技能命中时的目标特效</summary>
		[BsonIgnore]
		public int[] ImpactFXs => _ImpactFXs ??= new int[]{};
		/// <summary>起手动画</summary>
		public string StartAnimation { get; set; }

	}
}
