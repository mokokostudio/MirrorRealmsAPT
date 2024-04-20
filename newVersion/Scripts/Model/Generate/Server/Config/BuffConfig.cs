using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class BuffConfigCategory : Singleton<BuffConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, BuffConfig> dict = new();
		
        public void Merge(object o)
        {
            BuffConfigCategory s = o as BuffConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public BuffConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BuffConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BuffConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BuffConfig> GetAll()
        {
            return this.dict;
        }

        public BuffConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class BuffConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>通知客户端类型</summary>
		public int NoticeClientType { get; set; }
		/// <summary>总时长</summary>
		public int TotalTime { get; set; }
		/// <summary>添加时产生的效果</summary>
		public int[] _AdditionBehaviors;

		/// <summary>添加时产生的效果</summary>
		[BsonIgnore]
		public int[] AdditionBehaviors => _AdditionBehaviors ??= new int[]{};
		/// <summary>Tick间隔时间</summary>
		public int TickInterval { get; set; }
		/// <summary>Tick时产生的效果</summary>
		public int[] _TickBehaviors;

		/// <summary>Tick时产生的效果</summary>
		[BsonIgnore]
		public int[] TickBehaviors => _TickBehaviors ??= new int[]{};
		/// <summary>移除时产生的效果</summary>
		public int[] _RemovalBehaviors;

		/// <summary>移除时产生的效果</summary>
		[BsonIgnore]
		public int[] RemovalBehaviors => _RemovalBehaviors ??= new int[]{};
		/// <summary>Buff持有者特效</summary>
		public int[] _OwnerFXs;

		/// <summary>Buff持有者特效</summary>
		[BsonIgnore]
		public int[] OwnerFXs => _OwnerFXs ??= new int[]{};

	}
}
