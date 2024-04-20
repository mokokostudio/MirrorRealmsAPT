using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ProjectileConfigCategory : Singleton<ProjectileConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ProjectileConfig> dict = new();
		
        public void Merge(object o)
        {
            ProjectileConfigCategory s = o as ProjectileConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ProjectileConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ProjectileConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ProjectileConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ProjectileConfig> GetAll()
        {
            return this.dict;
        }

        public ProjectileConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class ProjectileConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>描述</summary>
		public string Desc { get; set; }
		/// <summary>目标选择方式</summary>
		public int SelectType { get; set; }
		/// <summary>目标选择参数</summary>
		public string[] _SelectParams;

		/// <summary>目标选择参数</summary>
		[BsonIgnore]
		public string[] SelectParams => _SelectParams ??= new string[]{};
		/// <summary>持续时间</summary>
		public int TotalTime { get; set; }
		/// <summary>创建时行为</summary>
		public int[] _SpawnBehaviors;

		/// <summary>创建时行为</summary>
		[BsonIgnore]
		public int[] SpawnBehaviors => _SpawnBehaviors ??= new int[]{};
		/// <summary>结算间隔(必须大于等于100)</summary>
		public int TickInterval { get; set; }
		/// <summary>结算技能编号</summary>
		public int[] _TickCastIds;

		/// <summary>结算技能编号</summary>
		[BsonIgnore]
		public int[] TickCastIds => _TickCastIds ??= new int[]{};
		/// <summary>结算行为</summary>
		public int[] _TickBehaviors;

		/// <summary>结算行为</summary>
		[BsonIgnore]
		public int[] TickBehaviors => _TickBehaviors ??= new int[]{};
		/// <summary>销毁时行为</summary>
		public int[] _DestructionBehaviors;

		/// <summary>销毁时行为</summary>
		[BsonIgnore]
		public int[] DestructionBehaviors => _DestructionBehaviors ??= new int[]{};
		/// <summary>目标个数</summary>
		public int TargetNum { get; set; }
		/// <summary>结算次数限制</summary>
		public int TickLimit { get; set; }
		/// <summary>0.1sTick</summary>
		public int[] _TickBehaviors100Ms;

		/// <summary>0.1sTick</summary>
		[BsonIgnore]
		public int[] TickBehaviors100Ms => _TickBehaviors100Ms ??= new int[]{};
		/// <summary>1sTick</summary>
		public int[] _TickBehaviors1000Ms;

		/// <summary>1sTick</summary>
		[BsonIgnore]
		public int[] TickBehaviors1000Ms => _TickBehaviors1000Ms ??= new int[]{};

	}
}
