using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
	[Message(OuterMessage.HttpGetRouterResponse)]
	[MemoryPackable]
	public partial class HttpGetRouterResponse: MessageObject
	{
		public static HttpGetRouterResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetRouterResponse), isFromPool) as HttpGetRouterResponse; 
		}

		[MemoryPackOrder(0)]
		public List<string> Realms { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<string> Routers { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Realms.Clear();
			this.Routers.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RouterSync)]
	[MemoryPackable]
	public partial class RouterSync: MessageObject
	{
		public static RouterSync Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RouterSync), isFromPool) as RouterSync; 
		}

		[MemoryPackOrder(0)]
		public uint ConnectId { get; set; }

		[MemoryPackOrder(1)]
		public string Address { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ConnectId = default;
			this.Address = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterMessage.C2M_TestRequest)]
	[MemoryPackable]
	public partial class C2M_TestRequest: MessageObject, ILocationRequest
	{
		public static C2M_TestRequest Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRequest), isFromPool) as C2M_TestRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string request { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.request = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestResponse)]
	[MemoryPackable]
	public partial class M2C_TestResponse: MessageObject, IResponse
	{
		public static M2C_TestResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestResponse), isFromPool) as M2C_TestResponse; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string response { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.response = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterMessage.C2G_EnterMap)]
	[MemoryPackable]
	public partial class C2G_EnterMap: MessageObject, ISessionRequest
	{
		public static C2G_EnterMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_EnterMap), isFromPool) as C2G_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_EnterMap)]
	[MemoryPackable]
	public partial class G2C_EnterMap: MessageObject, ISessionResponse
	{
		public static G2C_EnterMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_EnterMap), isFromPool) as G2C_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

// 自己unitId
		[MemoryPackOrder(3)]
		public long MyId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MyId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MoveInfo)]
	[MemoryPackable]
	public partial class MoveInfo: MessageObject
	{
		public static MoveInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MoveInfo), isFromPool) as MoveInfo; 
		}

		[MemoryPackOrder(0)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		[MemoryPackOrder(1)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		[MemoryPackOrder(2)]
		public int TurnSpeed { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Points.Clear();
			this.Rotation = default;
			this.TurnSpeed = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.InventoryItemProto)]
	[MemoryPackable]
	public partial class InventoryItemProto: MessageObject
	{
		public static InventoryItemProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(InventoryItemProto), isFromPool) as InventoryItemProto; 
		}

		[MemoryPackOrder(0)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(1)]
		public int Count { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ConfigId = default;
			this.Count = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.PlayerInfoProto)]
	[MemoryPackable]
	public partial class PlayerInfoProto: MessageObject
	{
		public static PlayerInfoProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(PlayerInfoProto), isFromPool) as PlayerInfoProto; 
		}

		[MemoryPackOrder(0)]
		public string PlayerName { get; set; }

		[MemoryPackOrder(1)]
		public uint ArmWeaponMode { get; set; }

		[MemoryPackOrder(2)]
		public List<InventoryItemProto> InventoryItems { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PlayerName = default;
			this.ArmWeaponMode = default;
			this.InventoryItems.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.UnitInfo)]
	[MemoryPackable]
	public partial class UnitInfo: MessageObject
	{
		public static UnitInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnitInfo), isFromPool) as UnitInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int Type { get; set; }

		[MemoryPackOrder(3)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(4)]
		public Unity.Mathematics.float3 Forward { get; set; }

		[MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
		[MemoryPackOrder(5)]
		public Dictionary<int, long> KV { get; set; } = new();
		[MemoryPackOrder(6)]
		public MoveInfo MoveInfo { get; set; }

		[MemoryPackOrder(7)]
		public bool IsMyUnit { get; set; }

// 只有Player才会有
		[MemoryPackOrder(8)]
		public PlayerInfoProto PlayerInfo { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.ConfigId = default;
			this.Type = default;
			this.Position = default;
			this.Forward = default;
			this.KV.Clear();
			this.MoveInfo = default;
			this.IsMyUnit = default;
			this.PlayerInfo = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CreateUnits)]
	[MemoryPackable]
	public partial class M2C_CreateUnits: MessageObject, IMessage
	{
		public static M2C_CreateUnits Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CreateUnits), isFromPool) as M2C_CreateUnits; 
		}

		[MemoryPackOrder(0)]
		public List<UnitInfo> Units { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CreateMyUnit)]
	[MemoryPackable]
	public partial class M2C_CreateMyUnit: MessageObject, IMessage
	{
		public static M2C_CreateMyUnit Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CreateMyUnit), isFromPool) as M2C_CreateMyUnit; 
		}

		[MemoryPackOrder(0)]
		public UnitInfo Unit { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Unit = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StartSceneChange)]
	[MemoryPackable]
	public partial class M2C_StartSceneChange: MessageObject, IMessage
	{
		public static M2C_StartSceneChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StartSceneChange), isFromPool) as M2C_StartSceneChange; 
		}

		[MemoryPackOrder(0)]
		public long SceneInstanceId { get; set; }

		[MemoryPackOrder(1)]
		public string SceneName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneInstanceId = default;
			this.SceneName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RemoveUnits)]
	[MemoryPackable]
	public partial class M2C_RemoveUnits: MessageObject, IMessage
	{
		public static M2C_RemoveUnits Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RemoveUnits), isFromPool) as M2C_RemoveUnits; 
		}

		[MemoryPackOrder(0)]
		public List<long> Units { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_PathfindingResult)]
	[MemoryPackable]
	public partial class C2M_PathfindingResult: MessageObject, ILocationMessage
	{
		public static C2M_PathfindingResult Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PathfindingResult), isFromPool) as C2M_PathfindingResult; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_Stop)]
	[MemoryPackable]
	public partial class C2M_Stop: MessageObject, ILocationMessage
	{
		public static C2M_Stop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Stop), isFromPool) as C2M_Stop; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PathfindingResult)]
	[MemoryPackable]
	public partial class M2C_PathfindingResult: MessageObject, IMessage
	{
		public static M2C_PathfindingResult Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PathfindingResult), isFromPool) as M2C_PathfindingResult; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(2)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.Position = default;
			this.Points.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Stop)]
	[MemoryPackable]
	public partial class M2C_Stop: MessageObject, IMessage
	{
		public static M2C_Stop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Stop), isFromPool) as M2C_Stop; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public long Id { get; set; }

		[MemoryPackOrder(2)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(3)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Id = default;
			this.Position = default;
			this.Rotation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterMessage.C2G_Ping)]
	[MemoryPackable]
	public partial class C2G_Ping: MessageObject, ISessionRequest
	{
		public static C2G_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Ping), isFromPool) as C2G_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Ping)]
	[MemoryPackable]
	public partial class G2C_Ping: MessageObject, ISessionResponse
	{
		public static G2C_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Ping), isFromPool) as G2C_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Test)]
	[MemoryPackable]
	public partial class G2C_Test: MessageObject, ISessionMessage
	{
		public static G2C_Test Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Test), isFromPool) as G2C_Test; 
		}

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterMessage.C2M_Reload)]
	[MemoryPackable]
	public partial class C2M_Reload: MessageObject, ISessionRequest
	{
		public static C2M_Reload Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Reload), isFromPool) as C2M_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Reload)]
	[MemoryPackable]
	public partial class M2C_Reload: MessageObject, ISessionResponse
	{
		public static M2C_Reload Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Reload), isFromPool) as M2C_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterMessage.C2R_Login)]
	[MemoryPackable]
	public partial class C2R_Login: MessageObject, ISessionRequest
	{
		public static C2R_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_Login), isFromPool) as C2R_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_Login)]
	[MemoryPackable]
	public partial class R2C_Login: MessageObject, ISessionResponse
	{
		public static R2C_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_Login), isFromPool) as R2C_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string Address { get; set; }

		[MemoryPackOrder(4)]
		public long Key { get; set; }

		[MemoryPackOrder(5)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Address = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterMessage.C2G_LoginGate)]
	[MemoryPackable]
	public partial class C2G_LoginGate: MessageObject, ISessionRequest
	{
		public static C2G_LoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_LoginGate), isFromPool) as C2G_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		[MemoryPackOrder(2)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_LoginGate)]
	[MemoryPackable]
	public partial class G2C_LoginGate: MessageObject, ISessionResponse
	{
		public static G2C_LoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_LoginGate), isFromPool) as G2C_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_TestHotfixMessage)]
	[MemoryPackable]
	public partial class G2C_TestHotfixMessage: MessageObject, ISessionMessage
	{
		public static G2C_TestHotfixMessage Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_TestHotfixMessage), isFromPool) as G2C_TestHotfixMessage; 
		}

		[MemoryPackOrder(0)]
		public string Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterMessage.C2M_TestRobotCase)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase: MessageObject, ILocationRequest
	{
		public static C2M_TestRobotCase Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase), isFromPool) as C2M_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase: MessageObject, ILocationResponse
	{
		public static M2C_TestRobotCase Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase), isFromPool) as M2C_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_TestRobotCase2)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase2: MessageObject, ILocationMessage
	{
		public static C2M_TestRobotCase2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase2), isFromPool) as C2M_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase2)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase2: MessageObject, ILocationMessage
	{
		public static M2C_TestRobotCase2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase2), isFromPool) as M2C_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterMessage.C2M_TransferMap)]
	[MemoryPackable]
	public partial class C2M_TransferMap: MessageObject, ILocationRequest
	{
		public static C2M_TransferMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TransferMap), isFromPool) as C2M_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TransferMap)]
	[MemoryPackable]
	public partial class M2C_TransferMap: MessageObject, ILocationResponse
	{
		public static M2C_TransferMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TransferMap), isFromPool) as M2C_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Benchmark))]
	[Message(OuterMessage.C2G_Benchmark)]
	[MemoryPackable]
	public partial class C2G_Benchmark: MessageObject, ISessionRequest
	{
		public static C2G_Benchmark Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Benchmark), isFromPool) as C2G_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Benchmark)]
	[MemoryPackable]
	public partial class G2C_Benchmark: MessageObject, ISessionResponse
	{
		public static G2C_Benchmark Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Benchmark), isFromPool) as G2C_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CastStart)]
	[MemoryPackable]
	public partial class M2C_CastStart: MessageObject, IMessage
	{
		public static M2C_CastStart Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CastStart), isFromPool) as M2C_CastStart; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long CastId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		[MemoryPackOrder(2)]
		public List<long> TargetIds { get; set; } = new();

		[MemoryPackOrder(3)]
		public long CastCongfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.CastId = default;
			this.CasterId = default;
			this.TargetIds.Clear();
			this.CastCongfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CastImpact)]
	[MemoryPackable]
	public partial class M2C_CastImpact: MessageObject, IMessage
	{
		public static M2C_CastImpact Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CastImpact), isFromPool) as M2C_CastImpact; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long CastId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		[MemoryPackOrder(2)]
		public List<long> TargetIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.CastId = default;
			this.CasterId = default;
			this.TargetIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CastFinish)]
	[MemoryPackable]
	public partial class M2C_CastFinish: MessageObject, IMessage
	{
		public static M2C_CastFinish Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CastFinish), isFromPool) as M2C_CastFinish; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long CastId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.CastId = default;
			this.CasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CastBreak)]
	[MemoryPackable]
	public partial class M2C_CastBreak: MessageObject, IMessage
	{
		public static M2C_CastBreak Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CastBreak), isFromPool) as M2C_CastBreak; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long CastId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.CastId = default;
			this.CasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.BuffProto)]
	[MemoryPackable]
	public partial class BuffProto: MessageObject
	{
		public static BuffProto Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(BuffProto), isFromPool) as BuffProto; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public long ExpireTime { get; set; }

		[MemoryPackOrder(3)]
		public long CreateTime { get; set; }

		[MemoryPackOrder(4)]
		public byte[] ExtraData { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ConfigId = default;
			this.ExpireTime = default;
			this.CreateTime = default;
			this.ExtraData = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuffAdd)]
	[MemoryPackable]
	public partial class M2C_BuffAdd: MessageObject, IMessage
	{
		public static M2C_BuffAdd Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuffAdd), isFromPool) as M2C_BuffAdd; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public BuffProto BuffData { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.BuffData = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuffTick)]
	[MemoryPackable]
	public partial class M2C_BuffTick: MessageObject, IMessage
	{
		public static M2C_BuffTick Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuffTick), isFromPool) as M2C_BuffTick; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long BuffId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.BuffId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuffUpdate)]
	[MemoryPackable]
	public partial class M2C_BuffUpdate: MessageObject, IMessage
	{
		public static M2C_BuffUpdate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuffUpdate), isFromPool) as M2C_BuffUpdate; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public BuffProto BuffData { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.BuffData = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BuffRemove)]
	[MemoryPackable]
	public partial class M2C_BuffRemove: MessageObject, IMessage
	{
		public static M2C_BuffRemove Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BuffRemove), isFromPool) as M2C_BuffRemove; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public long BuffId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.BuffId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_BattleResult)]
	[MemoryPackable]
	public partial class M2C_BattleResult: MessageObject, IMessage
	{
		public static M2C_BattleResult Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_BattleResult), isFromPool) as M2C_BattleResult; 
		}

		[MemoryPackOrder(0)]
		public long AttackerId { get; set; }

		[MemoryPackOrder(1)]
		public long TargetId { get; set; }

		[MemoryPackOrder(2)]
		public int DamageType { get; set; }

		[MemoryPackOrder(3)]
		public long Damage { get; set; }

		[MemoryPackOrder(4)]
		public bool ShouldShowDamageText { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.AttackerId = default;
			this.TargetId = default;
			this.DamageType = default;
			this.Damage = default;
			this.ShouldShowDamageText = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestCast))]
	[Message(OuterMessage.C2M_TestCast)]
	[MemoryPackable]
	public partial class C2M_TestCast: MessageObject, ILocationRequest
	{
		public static C2M_TestCast Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestCast), isFromPool) as C2M_TestCast; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int CastConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.CastConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestCast)]
	[MemoryPackable]
	public partial class M2C_TestCast: MessageObject, ILocationResponse
	{
		public static M2C_TestCast Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestCast), isFromPool) as M2C_TestCast; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CoolDownChange)]
	[MemoryPackable]
	public partial class M2C_CoolDownChange: MessageObject, IMessage
	{
		public static M2C_CoolDownChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CoolDownChange), isFromPool) as M2C_CoolDownChange; 
		}

		[MemoryPackOrder(0)]
		public List<int> CastConfigIds { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<long> CoolDownTimes { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<long> CoolDownStartTime { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.CastConfigIds.Clear();
			this.CoolDownTimes.Clear();
			this.CoolDownStartTime.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SetPosition)]
	[MemoryPackable]
	public partial class M2C_SetPosition: MessageObject, IMessage
	{
		public static M2C_SetPosition Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SetPosition), isFromPool) as M2C_SetPosition; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(2)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.Position = default;
			this.Rotation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_NumericChange)]
	[MemoryPackable]
	public partial class M2C_NumericChange: MessageObject, IMessage
	{
		public static M2C_NumericChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_NumericChange), isFromPool) as M2C_NumericChange; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
		[MemoryPackOrder(1)]
		public Dictionary<int, long> KV { get; set; } = new();
		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.KV.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ChangeWeapon)]
	[MemoryPackable]
	public partial class M2C_ChangeWeapon: MessageObject, IMessage
	{
		public static M2C_ChangeWeapon Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ChangeWeapon), isFromPool) as M2C_ChangeWeapon; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public uint ArmWeaponMode { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.ArmWeaponMode = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_SyncPosition)]
	[MemoryPackable]
	public partial class C2M_SyncPosition: MessageObject, IMessage
	{
		public static C2M_SyncPosition Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_SyncPosition), isFromPool) as C2M_SyncPosition; 
		}

		[MemoryPackOrder(0)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Position = default;
			this.Rotation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_CastSkill))]
	[Message(OuterMessage.C2M_CastSkill)]
	[MemoryPackable]
	public partial class C2M_CastSkill: MessageObject, ILocationRequest
	{
		public static C2M_CastSkill Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_CastSkill), isFromPool) as C2M_CastSkill; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public string SkillName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SkillName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CastSkill)]
	[MemoryPackable]
	public partial class M2C_CastSkill: MessageObject, ILocationResponse
	{
		public static M2C_CastSkill Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CastSkill), isFromPool) as M2C_CastSkill; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillStart)]
	[MemoryPackable]
	public partial class M2C_SkillStart: MessageObject, IMessage
	{
		public static M2C_SkillStart Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillStart), isFromPool) as M2C_SkillStart; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long SkillId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		[MemoryPackOrder(2)]
		public string SkillName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.SkillId = default;
			this.CasterId = default;
			this.SkillName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillImpact)]
	[MemoryPackable]
	public partial class M2C_SkillImpact: MessageObject, IMessage
	{
		public static M2C_SkillImpact Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillImpact), isFromPool) as M2C_SkillImpact; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long SkillId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		[MemoryPackOrder(2)]
		public List<long> TargetIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.SkillId = default;
			this.CasterId = default;
			this.TargetIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillBreak)]
	[MemoryPackable]
	public partial class M2C_SkillBreak: MessageObject, IMessage
	{
		public static M2C_SkillBreak Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillBreak), isFromPool) as M2C_SkillBreak; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long SkillId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.SkillId = default;
			this.CasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_SkillFinish)]
	[MemoryPackable]
	public partial class M2C_SkillFinish: MessageObject, IMessage
	{
		public static M2C_SkillFinish Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_SkillFinish), isFromPool) as M2C_SkillFinish; 
		}

		[MemoryPackOrder(79)]
		public long SceneId { get; set; }

		[MemoryPackOrder(0)]
		public long SkillId { get; set; }

		[MemoryPackOrder(1)]
		public long CasterId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneId = default;
			this.SkillId = default;
			this.CasterId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(MrM2C_Pick))]
	[Message(OuterMessage.MrC2M_Pick)]
	[MemoryPackable]
	public partial class MrC2M_Pick: MessageObject, ILocationRequest
	{
		public static MrC2M_Pick Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrC2M_Pick), isFromPool) as MrC2M_Pick; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.UnitId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrM2C_Pick)]
	[MemoryPackable]
	public partial class MrM2C_Pick: MessageObject, ILocationResponse
	{
		public static MrM2C_Pick Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_Pick), isFromPool) as MrM2C_Pick; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(MrM2C_UseItem))]
	[Message(OuterMessage.MrC2M_UseItem)]
	[MemoryPackable]
	public partial class MrC2M_UseItem: MessageObject, ILocationRequest
	{
		public static MrC2M_UseItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrC2M_UseItem), isFromPool) as MrC2M_UseItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(0)]
		public int ItemConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ItemConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrM2C_UseItem)]
	[MemoryPackable]
	public partial class MrM2C_UseItem: MessageObject, ILocationResponse
	{
		public static MrM2C_UseItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_UseItem), isFromPool) as MrM2C_UseItem; 
		}

		[MemoryPackOrder(89)]
		public int RpcId { get; set; }

		[MemoryPackOrder(90)]
		public int Error { get; set; }

		[MemoryPackOrder(91)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrInventoryCountChangeInfo)]
	[MemoryPackable]
	public partial class MrInventoryCountChangeInfo: MessageObject
	{
		public static MrInventoryCountChangeInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrInventoryCountChangeInfo), isFromPool) as MrInventoryCountChangeInfo; 
		}

		[MemoryPackOrder(0)]
		public int ItemConfigId { get; set; }

		[MemoryPackOrder(1)]
		public int OldCount { get; set; }

		[MemoryPackOrder(2)]
		public int NewCount { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ItemConfigId = default;
			this.OldCount = default;
			this.NewCount = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrM2C_InventoryCountChanged)]
	[MemoryPackable]
	public partial class MrM2C_InventoryCountChanged: MessageObject, IMessage
	{
		public static MrM2C_InventoryCountChanged Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_InventoryCountChanged), isFromPool) as MrM2C_InventoryCountChanged; 
		}

		[MemoryPackOrder(0)]
		public List<MrInventoryCountChangeInfo> ChangeList { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ChangeList.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrM2C_Drop)]
	[MemoryPackable]
	public partial class MrM2C_Drop: MessageObject, IMessage
	{
		public static MrM2C_Drop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_Drop), isFromPool) as MrM2C_Drop; 
		}

// pickable 的 id
		[MemoryPackOrder(0)]
		public long UintId { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 SpawnPosition { get; set; }

		[MemoryPackOrder(2)]
		public Unity.Mathematics.float3 TargetPosition { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UintId = default;
			this.SpawnPosition = default;
			this.TargetPosition = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

// ===========================================================================================================
// 登录, 大厅, 匹配
	[ResponseType(nameof(MrLobby2C_Ping))]
	[Message(OuterMessage.MrC2Lobby_Ping)]
	[MemoryPackable]
	public partial class MrC2Lobby_Ping: MessageObject, ISessionRequest
	{
		public static MrC2Lobby_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrC2Lobby_Ping), isFromPool) as MrC2Lobby_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrLobby2C_Ping)]
	[MemoryPackable]
	public partial class MrLobby2C_Ping: MessageObject, ISessionResponse
	{
		public static MrLobby2C_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrLobby2C_Ping), isFromPool) as MrLobby2C_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(MrR2C_Login))]
	[Message(OuterMessage.MrC2R_Login)]
	[MemoryPackable]
	public partial class MrC2R_Login: MessageObject, ISessionRequest
	{
		public static MrC2R_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrC2R_Login), isFromPool) as MrC2R_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrR2C_Login)]
	[MemoryPackable]
	public partial class MrR2C_Login: MessageObject, ISessionResponse
	{
		public static MrR2C_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrR2C_Login), isFromPool) as MrR2C_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string Address { get; set; }

		[MemoryPackOrder(4)]
		public long Key { get; set; }

		[MemoryPackOrder(5)]
		public long LobbyId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Address = default;
			this.Key = default;
			this.LobbyId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(MrLobby2C_Login))]
	[Message(OuterMessage.MrC2Lobby_Login)]
	[MemoryPackable]
	public partial class MrC2Lobby_Login: MessageObject, ISessionRequest
	{
		public static MrC2Lobby_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrC2Lobby_Login), isFromPool) as MrC2Lobby_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrLobby2C_Login)]
	[MemoryPackable]
	public partial class MrLobby2C_Login: MessageObject, ISessionResponse
	{
		public static MrLobby2C_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrLobby2C_Login), isFromPool) as MrLobby2C_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(MrLobby2C_Match))]
	[Message(OuterMessage.MrC2Lobby_Match)]
	[MemoryPackable]
	public partial class MrC2Lobby_Match: MessageObject, ISessionRequest
	{
		public static MrC2Lobby_Match Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrC2Lobby_Match), isFromPool) as MrC2Lobby_Match; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public bool SinglePlay { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.SinglePlay = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrLobby2C_Match)]
	[MemoryPackable]
	public partial class MrLobby2C_Match: MessageObject, ISessionResponse
	{
		public static MrLobby2C_Match Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrLobby2C_Match), isFromPool) as MrLobby2C_Match; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrLobby2C_NotifyMatchSuccess)]
	[MemoryPackable]
	public partial class MrLobby2C_NotifyMatchSuccess: MessageObject, IMessage
	{
		public static MrLobby2C_NotifyMatchSuccess Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrLobby2C_NotifyMatchSuccess), isFromPool) as MrLobby2C_NotifyMatchSuccess; 
		}

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrM2C_CreateMyUnit)]
	[MemoryPackable]
	public partial class MrM2C_CreateMyUnit: MessageObject, IMessage
	{
		public static MrM2C_CreateMyUnit Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_CreateMyUnit), isFromPool) as MrM2C_CreateMyUnit; 
		}

		[MemoryPackOrder(0)]
		public UnitInfo Unit { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Unit = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrRoom2C_NotifyPhaseInfo)]
	[MemoryPackable]
	public partial class MrRoom2C_NotifyPhaseInfo: MessageObject, IMessage
	{
		public static MrRoom2C_NotifyPhaseInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrRoom2C_NotifyPhaseInfo), isFromPool) as MrRoom2C_NotifyPhaseInfo; 
		}

		[MemoryPackOrder(0)]
		public int Phase { get; set; }

		[MemoryPackOrder(1)]
		public long StartTime { get; set; }

		[MemoryPackOrder(2)]
		public long RemainingTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Phase = default;
			this.StartTime = default;
			this.RemainingTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

// 房间通知客户端进入战斗准备
	[Message(OuterMessage.MrM2C_Start)]
	[MemoryPackable]
	public partial class MrM2C_Start: MessageObject, IMessage
	{
		public static MrM2C_Start Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_Start), isFromPool) as MrM2C_Start; 
		}

		[MemoryPackOrder(0)]
		public long StartTime { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.StartTime = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(MrM2C_ExitRoom))]
	[Message(OuterMessage.MrC2M_ExitRoom)]
	[MemoryPackable]
	public partial class MrC2M_ExitRoom: MessageObject, ISessionRequest
	{
		public static MrC2M_ExitRoom Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrC2M_ExitRoom), isFromPool) as MrC2M_ExitRoom; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MrM2C_ExitRoom)]
	[MemoryPackable]
	public partial class MrM2C_ExitRoom: MessageObject, ISessionResponse
	{
		public static MrM2C_ExitRoom Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_ExitRoom), isFromPool) as MrM2C_ExitRoom; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

// 房间通知客户端进入战斗
	[Message(OuterMessage.MrM2C_BattleStart)]
	[MemoryPackable]
	public partial class MrM2C_BattleStart: MessageObject, IMessage
	{
		public static MrM2C_BattleStart Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_BattleStart), isFromPool) as MrM2C_BattleStart; 
		}

		[MemoryPackOrder(0)]
		public long StartTime { get; set; }

		[MemoryPackOrder(1)]
		public List<long> PlayerIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.StartTime = default;
			this.PlayerIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

// 房间通知客户端战斗时间结束
	[Message(OuterMessage.MrM2C_BattleFinish)]
	[MemoryPackable]
	public partial class MrM2C_BattleFinish: MessageObject, IMessage
	{
		public static MrM2C_BattleFinish Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MrM2C_BattleFinish), isFromPool) as MrM2C_BattleFinish; 
		}

		[MemoryPackOrder(1)]
		public List<long> PlayerIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PlayerIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	public static class OuterMessage
	{
		 public const ushort HttpGetRouterResponse = 10002;
		 public const ushort RouterSync = 10003;
		 public const ushort C2M_TestRequest = 10004;
		 public const ushort M2C_TestResponse = 10005;
		 public const ushort C2G_EnterMap = 10006;
		 public const ushort G2C_EnterMap = 10007;
		 public const ushort MoveInfo = 10008;
		 public const ushort InventoryItemProto = 10009;
		 public const ushort PlayerInfoProto = 10010;
		 public const ushort UnitInfo = 10011;
		 public const ushort M2C_CreateUnits = 10012;
		 public const ushort M2C_CreateMyUnit = 10013;
		 public const ushort M2C_StartSceneChange = 10014;
		 public const ushort M2C_RemoveUnits = 10015;
		 public const ushort C2M_PathfindingResult = 10016;
		 public const ushort C2M_Stop = 10017;
		 public const ushort M2C_PathfindingResult = 10018;
		 public const ushort M2C_Stop = 10019;
		 public const ushort C2G_Ping = 10020;
		 public const ushort G2C_Ping = 10021;
		 public const ushort G2C_Test = 10022;
		 public const ushort C2M_Reload = 10023;
		 public const ushort M2C_Reload = 10024;
		 public const ushort C2R_Login = 10025;
		 public const ushort R2C_Login = 10026;
		 public const ushort C2G_LoginGate = 10027;
		 public const ushort G2C_LoginGate = 10028;
		 public const ushort G2C_TestHotfixMessage = 10029;
		 public const ushort C2M_TestRobotCase = 10030;
		 public const ushort M2C_TestRobotCase = 10031;
		 public const ushort C2M_TestRobotCase2 = 10032;
		 public const ushort M2C_TestRobotCase2 = 10033;
		 public const ushort C2M_TransferMap = 10034;
		 public const ushort M2C_TransferMap = 10035;
		 public const ushort C2G_Benchmark = 10036;
		 public const ushort G2C_Benchmark = 10037;
		 public const ushort M2C_CastStart = 10038;
		 public const ushort M2C_CastImpact = 10039;
		 public const ushort M2C_CastFinish = 10040;
		 public const ushort M2C_CastBreak = 10041;
		 public const ushort BuffProto = 10042;
		 public const ushort M2C_BuffAdd = 10043;
		 public const ushort M2C_BuffTick = 10044;
		 public const ushort M2C_BuffUpdate = 10045;
		 public const ushort M2C_BuffRemove = 10046;
		 public const ushort M2C_BattleResult = 10047;
		 public const ushort C2M_TestCast = 10048;
		 public const ushort M2C_TestCast = 10049;
		 public const ushort M2C_CoolDownChange = 10050;
		 public const ushort M2C_SetPosition = 10051;
		 public const ushort M2C_NumericChange = 10052;
		 public const ushort M2C_ChangeWeapon = 10053;
		 public const ushort C2M_SyncPosition = 10054;
		 public const ushort C2M_CastSkill = 10055;
		 public const ushort M2C_CastSkill = 10056;
		 public const ushort M2C_SkillStart = 10057;
		 public const ushort M2C_SkillImpact = 10058;
		 public const ushort M2C_SkillBreak = 10059;
		 public const ushort M2C_SkillFinish = 10060;
		 public const ushort MrC2M_Pick = 10061;
		 public const ushort MrM2C_Pick = 10062;
		 public const ushort MrC2M_UseItem = 10063;
		 public const ushort MrM2C_UseItem = 10064;
		 public const ushort MrInventoryCountChangeInfo = 10065;
		 public const ushort MrM2C_InventoryCountChanged = 10066;
		 public const ushort MrM2C_Drop = 10067;
		 public const ushort MrC2Lobby_Ping = 10068;
		 public const ushort MrLobby2C_Ping = 10069;
		 public const ushort MrC2R_Login = 10070;
		 public const ushort MrR2C_Login = 10071;
		 public const ushort MrC2Lobby_Login = 10072;
		 public const ushort MrLobby2C_Login = 10073;
		 public const ushort MrC2Lobby_Match = 10074;
		 public const ushort MrLobby2C_Match = 10075;
		 public const ushort MrLobby2C_NotifyMatchSuccess = 10076;
		 public const ushort MrM2C_CreateMyUnit = 10077;
		 public const ushort MrRoom2C_NotifyPhaseInfo = 10078;
		 public const ushort MrM2C_Start = 10079;
		 public const ushort MrC2M_ExitRoom = 10080;
		 public const ushort MrM2C_ExitRoom = 10081;
		 public const ushort MrM2C_BattleStart = 10082;
		 public const ushort MrM2C_BattleFinish = 10083;
	}
}
