using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"MemoryPack.dll",
		"MongoDB.Bson.dll",
		"System.Core.dll",
		"System.Runtime.CompilerServices.Unsafe.dll",
		"System.dll",
		"Unity.Core.dll",
		"Unity.Loader.dll",
		"Unity.ThirdParty.dll",
		"UnityEngine.AnimationModule.dll",
		"UnityEngine.CoreModule.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// ET.AEvent.<Handle>d__3<object,ET.ChangePosition>
	// ET.AEvent.<Handle>d__3<object,ET.ChangeRotation>
	// ET.AEvent.<Handle>d__3<object,ET.Client.AfterCreateClientScene>
	// ET.AEvent.<Handle>d__3<object,ET.Client.AfterCreateClientSceneMR>
	// ET.AEvent.<Handle>d__3<object,ET.Client.AfterCreateCurrentScene>
	// ET.AEvent.<Handle>d__3<object,ET.Client.AfterCreateCurrentSceneMR>
	// ET.AEvent.<Handle>d__3<object,ET.Client.AfterUnitCreate>
	// ET.AEvent.<Handle>d__3<object,ET.Client.AppStartInitFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.BattleEnd>
	// ET.AEvent.<Handle>d__3<object,ET.Client.EnterMapFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.ExitCurrentSceneFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.ExitCurrentSceneStart>
	// ET.AEvent.<Handle>d__3<object,ET.Client.ExitMapFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.GameBattleFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.GameBattleStart>
	// ET.AEvent.<Handle>d__3<object,ET.Client.GameReadyStart>
	// ET.AEvent.<Handle>d__3<object,ET.Client.LSSceneChangeStart>
	// ET.AEvent.<Handle>d__3<object,ET.Client.LSSceneChangeStartMR>
	// ET.AEvent.<Handle>d__3<object,ET.Client.LSSceneInitFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.LSSceneInitFinishMR>
	// ET.AEvent.<Handle>d__3<object,ET.Client.LoginFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.LoginFinishMR>
	// ET.AEvent.<Handle>d__3<object,ET.Client.SceneChangeFinish>
	// ET.AEvent.<Handle>d__3<object,ET.Client.SceneChangeFinishMR>
	// ET.AEvent.<Handle>d__3<object,ET.Client.SceneChangeStart>
	// ET.AEvent.<Handle>d__3<object,ET.Client.SceneChangeStartMR>
	// ET.AEvent.<Handle>d__3<object,ET.Client.UILoadingCreate>
	// ET.AEvent.<Handle>d__3<object,ET.Client.UILoadingRemove>
	// ET.AEvent.<Handle>d__3<object,ET.EntryEvent1>
	// ET.AEvent.<Handle>d__3<object,ET.EntryEvent2>
	// ET.AEvent.<Handle>d__3<object,ET.EntryEvent3>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.BuffAdd>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.BuffRemove>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.BuffTick>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.BuffUpdate>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.CastBreak>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.CastFinish>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.CastImpact>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.CastStart>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.DropCreated>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.InventoryInited>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.IventoryCountChanged>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.NumericChanged>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.SkillBreak>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.SkillFinish>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.SkillImpact>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.SkillStart>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.TakeDamage>
	// ET.AEvent.<Handle>d__3<object,ET.EventType.UnitWeaponChanged>
	// ET.AEvent.<Handle>d__3<object,ET.MoveStart>
	// ET.AEvent.<Handle>d__3<object,ET.MoveStop>
	// ET.AEvent.<Handle>d__3<object,ET.NumbericChange>
	// ET.AEvent<object,ET.ChangePosition>
	// ET.AEvent<object,ET.ChangeRotation>
	// ET.AEvent<object,ET.Client.AfterCreateClientScene>
	// ET.AEvent<object,ET.Client.AfterCreateClientSceneMR>
	// ET.AEvent<object,ET.Client.AfterCreateCurrentScene>
	// ET.AEvent<object,ET.Client.AfterCreateCurrentSceneMR>
	// ET.AEvent<object,ET.Client.AfterUnitCreate>
	// ET.AEvent<object,ET.Client.AppStartInitFinish>
	// ET.AEvent<object,ET.Client.BattleEnd>
	// ET.AEvent<object,ET.Client.EnterMapFinish>
	// ET.AEvent<object,ET.Client.ExitCurrentSceneFinish>
	// ET.AEvent<object,ET.Client.ExitCurrentSceneStart>
	// ET.AEvent<object,ET.Client.ExitMapFinish>
	// ET.AEvent<object,ET.Client.GameBattleFinish>
	// ET.AEvent<object,ET.Client.GameBattleStart>
	// ET.AEvent<object,ET.Client.GameReadyStart>
	// ET.AEvent<object,ET.Client.LSSceneChangeStart>
	// ET.AEvent<object,ET.Client.LSSceneChangeStartMR>
	// ET.AEvent<object,ET.Client.LSSceneInitFinish>
	// ET.AEvent<object,ET.Client.LSSceneInitFinishMR>
	// ET.AEvent<object,ET.Client.LoginFinish>
	// ET.AEvent<object,ET.Client.LoginFinishMR>
	// ET.AEvent<object,ET.Client.SceneChangeFinish>
	// ET.AEvent<object,ET.Client.SceneChangeFinishMR>
	// ET.AEvent<object,ET.Client.SceneChangeStart>
	// ET.AEvent<object,ET.Client.SceneChangeStartMR>
	// ET.AEvent<object,ET.Client.UILoadingCreate>
	// ET.AEvent<object,ET.Client.UILoadingRemove>
	// ET.AEvent<object,ET.EntryEvent1>
	// ET.AEvent<object,ET.EntryEvent2>
	// ET.AEvent<object,ET.EntryEvent3>
	// ET.AEvent<object,ET.EventType.BuffAdd>
	// ET.AEvent<object,ET.EventType.BuffRemove>
	// ET.AEvent<object,ET.EventType.BuffTick>
	// ET.AEvent<object,ET.EventType.BuffUpdate>
	// ET.AEvent<object,ET.EventType.CastBreak>
	// ET.AEvent<object,ET.EventType.CastFinish>
	// ET.AEvent<object,ET.EventType.CastImpact>
	// ET.AEvent<object,ET.EventType.CastStart>
	// ET.AEvent<object,ET.EventType.DropCreated>
	// ET.AEvent<object,ET.EventType.InventoryInited>
	// ET.AEvent<object,ET.EventType.IventoryCountChanged>
	// ET.AEvent<object,ET.EventType.NumericChanged>
	// ET.AEvent<object,ET.EventType.SkillBreak>
	// ET.AEvent<object,ET.EventType.SkillFinish>
	// ET.AEvent<object,ET.EventType.SkillImpact>
	// ET.AEvent<object,ET.EventType.SkillStart>
	// ET.AEvent<object,ET.EventType.TakeDamage>
	// ET.AEvent<object,ET.EventType.UnitWeaponChanged>
	// ET.AEvent<object,ET.MoveStart>
	// ET.AEvent<object,ET.MoveStop>
	// ET.AEvent<object,ET.NumbericChange>
	// ET.AInvokeHandler<ET.FiberInit,object>
	// ET.AInvokeHandler<ET.MailBoxInvoker>
	// ET.AInvokeHandler<ET.NetComponentOnRead>
	// ET.AInvokeHandler<ET.TimerCallback>
	// ET.ATimer<object>
	// ET.AwakeSystem<object,float>
	// ET.AwakeSystem<object,int,int,object>
	// ET.AwakeSystem<object,int,int>
	// ET.AwakeSystem<object,int>
	// ET.AwakeSystem<object,long>
	// ET.AwakeSystem<object,object,int>
	// ET.AwakeSystem<object,object,object>
	// ET.AwakeSystem<object,object>
	// ET.AwakeSystem<object>
	// ET.DestroySystem<object>
	// ET.DoubleMap<object,long>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_BattleUI>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start_MR>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>
	// ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>
	// ET.ETAsyncTaskMethodBuilder<Wait_ExitCurrentSceneFinish>
	// ET.ETAsyncTaskMethodBuilder<byte>
	// ET.ETAsyncTaskMethodBuilder<int>
	// ET.ETAsyncTaskMethodBuilder<long>
	// ET.ETAsyncTaskMethodBuilder<object>
	// ET.ETAsyncTaskMethodBuilder<uint>
	// ET.ETTask.<InnerCoroutine>d__8<ET.Client.WaitType.Wait_BattleUI>
	// ET.ETTask.<InnerCoroutine>d__8<ET.Client.WaitType.Wait_GameRoom2C_Start>
	// ET.ETTask.<InnerCoroutine>d__8<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETTask.<InnerCoroutine>d__8<ET.Client.WaitType.Wait_Room2C_Start_MR>
	// ET.ETTask.<InnerCoroutine>d__8<ET.Client.Wait_CreateMyUnit>
	// ET.ETTask.<InnerCoroutine>d__8<ET.Client.Wait_SceneChangeFinish>
	// ET.ETTask.<InnerCoroutine>d__8<ET.Client.Wait_UnitStop>
	// ET.ETTask.<InnerCoroutine>d__8<System.ValueTuple<uint,object>>
	// ET.ETTask.<InnerCoroutine>d__8<Wait_ExitCurrentSceneFinish>
	// ET.ETTask.<InnerCoroutine>d__8<byte>
	// ET.ETTask.<InnerCoroutine>d__8<int>
	// ET.ETTask.<InnerCoroutine>d__8<long>
	// ET.ETTask.<InnerCoroutine>d__8<object>
	// ET.ETTask.<InnerCoroutine>d__8<uint>
	// ET.ETTask<ET.Client.WaitType.Wait_BattleUI>
	// ET.ETTask<ET.Client.WaitType.Wait_GameRoom2C_Start>
	// ET.ETTask<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETTask<ET.Client.WaitType.Wait_Room2C_Start_MR>
	// ET.ETTask<ET.Client.Wait_CreateMyUnit>
	// ET.ETTask<ET.Client.Wait_SceneChangeFinish>
	// ET.ETTask<ET.Client.Wait_UnitStop>
	// ET.ETTask<System.ValueTuple<uint,object>>
	// ET.ETTask<Wait_ExitCurrentSceneFinish>
	// ET.ETTask<byte>
	// ET.ETTask<int>
	// ET.ETTask<long>
	// ET.ETTask<object>
	// ET.ETTask<uint>
	// ET.EntityRef<object>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.AppStartInitFinish>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.BattleEnd>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LSSceneChangeStart>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LSSceneChangeStartMR>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinish>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LoginFinishMR>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.UILoadingCreate>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.Client.UILoadingRemove>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.EventType.DropCreated>
	// ET.EventSystem.<PublishAsync>d__4<object,ET.EventType.NumericChanged>
	// ET.IAwake<float>
	// ET.IAwake<int,int,object>
	// ET.IAwake<int,int>
	// ET.IAwake<int>
	// ET.IAwake<long>
	// ET.IAwake<object,int>
	// ET.IAwake<object,object,object>
	// ET.IAwake<object,object>
	// ET.IAwake<object>
	// ET.IAwakeSystem<float>
	// ET.IAwakeSystem<int,int,object>
	// ET.IAwakeSystem<int,int>
	// ET.IAwakeSystem<int>
	// ET.IAwakeSystem<long>
	// ET.IAwakeSystem<object,int>
	// ET.IAwakeSystem<object,object,object>
	// ET.IAwakeSystem<object,object>
	// ET.IAwakeSystem<object>
	// ET.LateUpdateSystem<object>
	// ET.ListComponent<Unity.Mathematics.float3>
	// ET.ListComponent<object>
	// ET.Singleton<object>
	// ET.StateMachineWrap<object>
	// ET.StructBsonSerialize<ET.LSInput>
	// ET.StructBsonSerialize<TrueSync.FP>
	// ET.StructBsonSerialize<TrueSync.TSQuaternion>
	// ET.StructBsonSerialize<TrueSync.TSVector2>
	// ET.StructBsonSerialize<TrueSync.TSVector4>
	// ET.StructBsonSerialize<TrueSync.TSVector>
	// ET.StructBsonSerialize<Unity.Mathematics.float2>
	// ET.StructBsonSerialize<Unity.Mathematics.float3>
	// ET.StructBsonSerialize<Unity.Mathematics.float4>
	// ET.StructBsonSerialize<Unity.Mathematics.quaternion>
	// ET.StructBsonSerialize<object>
	// ET.UnOrderMultiMap<object,object>
	// ET.UpdateSystem<object>
	// MemoryPack.Formatters.ArrayFormatter<ET.LSInput>
	// MemoryPack.Formatters.ArrayFormatter<ET.LSInputMR>
	// MemoryPack.Formatters.ArrayFormatter<byte>
	// MemoryPack.Formatters.ArrayFormatter<object>
	// MemoryPack.Formatters.DictionaryFormatter<int,long>
	// MemoryPack.Formatters.DictionaryFormatter<long,ET.LSInput>
	// MemoryPack.Formatters.DictionaryFormatter<long,ET.LSInputMR>
	// MemoryPack.Formatters.ListFormatter<Unity.Mathematics.float3>
	// MemoryPack.Formatters.ListFormatter<int>
	// MemoryPack.Formatters.ListFormatter<long>
	// MemoryPack.Formatters.ListFormatter<object>
	// MemoryPack.Formatters.ListFormatter<ulong>
	// MemoryPack.Formatters.UnmanagedFormatter<byte>
	// MemoryPack.IMemoryPackFormatter<Unity.Mathematics.float3>
	// MemoryPack.IMemoryPackFormatter<byte>
	// MemoryPack.IMemoryPackFormatter<int>
	// MemoryPack.IMemoryPackFormatter<long>
	// MemoryPack.IMemoryPackFormatter<object>
	// MemoryPack.IMemoryPackFormatter<ulong>
	// MemoryPack.IMemoryPackable<ET.LSInput>
	// MemoryPack.IMemoryPackable<ET.LSInputMR>
	// MemoryPack.IMemoryPackable<object>
	// MemoryPack.MemoryPackFormatter<ET.LSInput>
	// MemoryPack.MemoryPackFormatter<ET.LSInputMR>
	// MemoryPack.MemoryPackFormatter<System.UIntPtr>
	// MemoryPack.MemoryPackFormatter<byte>
	// MemoryPack.MemoryPackFormatter<object>
	// MongoDB.Bson.Serialization.IBsonSerializer<object>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<ET.LSInput>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<object>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<ET.LSInput>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<object>
	// System.Action<DotRecast.Detour.StraightPathItem>
	// System.Action<ET.FX>
	// System.Action<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Action<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Action<Unity.Mathematics.float3>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Action<byte>
	// System.Action<int>
	// System.Action<long,int>
	// System.Action<long,object>
	// System.Action<long>
	// System.Action<object,long>
	// System.Action<object,object>
	// System.Action<object>
	// System.Action<ulong>
	// System.ArraySegment.Enumerator<UnityEngine.Animations.TransformStreamHandle>
	// System.ArraySegment.Enumerator<byte>
	// System.ArraySegment.Enumerator<float>
	// System.ArraySegment<UnityEngine.Animations.TransformStreamHandle>
	// System.ArraySegment<byte>
	// System.ArraySegment<float>
	// System.ByReference<UnityEngine.Animations.TransformStreamHandle>
	// System.ByReference<byte>
	// System.ByReference<float>
	// System.Collections.Concurrent.ConcurrentDictionary.<GetEnumerator>d__35<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.DictionaryEnumerator<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Node<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Tables<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary<object,object>
	// System.Collections.Concurrent.ConcurrentQueue.<Enumerate>d__28<object>
	// System.Collections.Concurrent.ConcurrentQueue.Segment<object>
	// System.Collections.Concurrent.ConcurrentQueue<object>
	// System.Collections.Generic.ArraySortHelper<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ArraySortHelper<ET.FX>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ArraySortHelper<Unity.Mathematics.float3>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<long>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.ArraySortHelper<ulong>
	// System.Collections.Generic.Comparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.Comparer<ET.ActorId>
	// System.Collections.Generic.Comparer<ET.FX>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Comparer<Unity.Mathematics.float3>
	// System.Collections.Generic.Comparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<long>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Comparer<uint>
	// System.Collections.Generic.Comparer<ulong>
	// System.Collections.Generic.Comparer<ushort>
	// System.Collections.Generic.ComparisonComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ComparisonComparer<ET.ActorId>
	// System.Collections.Generic.ComparisonComparer<ET.FX>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ComparisonComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ComparisonComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ComparisonComparer<int>
	// System.Collections.Generic.ComparisonComparer<long>
	// System.Collections.Generic.ComparisonComparer<object>
	// System.Collections.Generic.ComparisonComparer<uint>
	// System.Collections.Generic.ComparisonComparer<ulong>
	// System.Collections.Generic.ComparisonComparer<ushort>
	// System.Collections.Generic.Dictionary.Enumerator<ET.FX,object>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.LSInputMR>
	// System.Collections.Generic.Dictionary.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<ET.FX,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.LSInputMR>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection<ET.FX,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.LSInputMR>
	// System.Collections.Generic.Dictionary.KeyCollection<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<ET.FX,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.LSInputMR>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection<ET.FX,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.LSInputMR>
	// System.Collections.Generic.Dictionary.ValueCollection<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<ushort,object>
	// System.Collections.Generic.Dictionary<ET.FX,object>
	// System.Collections.Generic.Dictionary<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary<int,long>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<long,ET.LSInput>
	// System.Collections.Generic.Dictionary<long,ET.LSInputMR>
	// System.Collections.Generic.Dictionary<long,object>
	// System.Collections.Generic.Dictionary<object,long>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.Dictionary<ushort,object>
	// System.Collections.Generic.EqualityComparer<ET.ActorId>
	// System.Collections.Generic.EqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.EqualityComparer<ET.FX>
	// System.Collections.Generic.EqualityComparer<ET.LSInput>
	// System.Collections.Generic.EqualityComparer<ET.LSInputMR>
	// System.Collections.Generic.EqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<long>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.EqualityComparer<uint>
	// System.Collections.Generic.EqualityComparer<ushort>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet.Enumerator<ushort>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.HashSet<ushort>
	// System.Collections.Generic.HashSetEqualityComparer<object>
	// System.Collections.Generic.HashSetEqualityComparer<ushort>
	// System.Collections.Generic.ICollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ICollection<ET.FX>
	// System.Collections.Generic.ICollection<ET.RpcInfo>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<ET.FX,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.LSInputMR>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.ICollection<Unity.Mathematics.float3>
	// System.Collections.Generic.ICollection<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<long>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.ICollection<ulong>
	// System.Collections.Generic.ICollection<ushort>
	// System.Collections.Generic.IComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IComparer<ET.FX>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.IComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<long>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IComparer<ulong>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerable<ET.FX>
	// System.Collections.Generic.IEnumerable<ET.RpcInfo>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<ET.FX,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.LSInputMR>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerable<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerable<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<long>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerable<ulong>
	// System.Collections.Generic.IEnumerable<ushort>
	// System.Collections.Generic.IEnumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerator<ET.FX>
	// System.Collections.Generic.IEnumerator<ET.RpcInfo>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ET.FX,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.LSInputMR>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerator<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<long>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEnumerator<ulong>
	// System.Collections.Generic.IEnumerator<ushort>
	// System.Collections.Generic.IEqualityComparer<ET.FX>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<long>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IEqualityComparer<ushort>
	// System.Collections.Generic.IList<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IList<ET.FX>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IList<Unity.Mathematics.float3>
	// System.Collections.Generic.IList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<long>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.IList<ulong>
	// System.Collections.Generic.KeyValuePair<ET.FX,object>
	// System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>
	// System.Collections.Generic.KeyValuePair<int,long>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<long,ET.LSInput>
	// System.Collections.Generic.KeyValuePair<long,ET.LSInputMR>
	// System.Collections.Generic.KeyValuePair<long,object>
	// System.Collections.Generic.KeyValuePair<object,long>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.KeyValuePair<ushort,object>
	// System.Collections.Generic.List.Enumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List.Enumerator<ET.FX>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List.Enumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.List.Enumerator<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<long>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List.Enumerator<ulong>
	// System.Collections.Generic.List<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List<ET.FX>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List<Unity.Mathematics.float3>
	// System.Collections.Generic.List<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<long>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.List<ulong>
	// System.Collections.Generic.ObjectComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ObjectComparer<ET.ActorId>
	// System.Collections.Generic.ObjectComparer<ET.FX>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ObjectComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<long>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectComparer<uint>
	// System.Collections.Generic.ObjectComparer<ulong>
	// System.Collections.Generic.ObjectComparer<ushort>
	// System.Collections.Generic.ObjectEqualityComparer<ET.ActorId>
	// System.Collections.Generic.ObjectEqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.ObjectEqualityComparer<ET.FX>
	// System.Collections.Generic.ObjectEqualityComparer<ET.LSInput>
	// System.Collections.Generic.ObjectEqualityComparer<ET.LSInputMR>
	// System.Collections.Generic.ObjectEqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<long>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<uint>
	// System.Collections.Generic.ObjectEqualityComparer<ushort>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<int,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<long,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<int,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<long,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<long,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<int,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<long,object>
	// System.Collections.Generic.SortedDictionary<int,object>
	// System.Collections.Generic.SortedDictionary<long,object>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Stack.Enumerator<object>
	// System.Collections.Generic.Stack<object>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.FX>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<Unity.Mathematics.float3>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<long>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<ulong>
	// System.Comparison<DotRecast.Detour.StraightPathItem>
	// System.Comparison<ET.ActorId>
	// System.Comparison<ET.FX>
	// System.Comparison<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Comparison<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Comparison<Unity.Mathematics.float3>
	// System.Comparison<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Comparison<int>
	// System.Comparison<long>
	// System.Comparison<object>
	// System.Comparison<uint>
	// System.Comparison<ulong>
	// System.Comparison<ushort>
	// System.Func<System.Collections.Generic.KeyValuePair<long,object>,byte>
	// System.Func<System.Collections.Generic.KeyValuePair<long,object>,object>
	// System.Func<UnityEngine.Playables.Playable>
	// System.Func<float>
	// System.Func<object,byte>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.IEquatable<ET.FX>
	// System.Linq.Buffer<ET.RpcInfo>
	// System.Linq.Buffer<object>
	// System.Linq.Enumerable.<CastIterator>d__99<object>
	// System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Linq.Enumerable.Iterator<object>
	// System.Linq.Enumerable.WhereArrayIterator<object>
	// System.Linq.Enumerable.WhereEnumerableIterator<object>
	// System.Linq.Enumerable.WhereListIterator<object>
	// System.Linq.Enumerable.WhereSelectArrayIterator<System.Collections.Generic.KeyValuePair<long,object>,object>
	// System.Linq.Enumerable.WhereSelectArrayIterator<object,object>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<System.Collections.Generic.KeyValuePair<long,object>,object>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<object,object>
	// System.Linq.Enumerable.WhereSelectListIterator<System.Collections.Generic.KeyValuePair<long,object>,object>
	// System.Linq.Enumerable.WhereSelectListIterator<object,object>
	// System.Predicate<DotRecast.Detour.StraightPathItem>
	// System.Predicate<ET.FX>
	// System.Predicate<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Predicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Predicate<Unity.Mathematics.float3>
	// System.Predicate<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Predicate<int>
	// System.Predicate<long>
	// System.Predicate<object>
	// System.Predicate<ulong>
	// System.Predicate<ushort>
	// System.ReadOnlySpan.Enumerator<UnityEngine.Animations.TransformStreamHandle>
	// System.ReadOnlySpan.Enumerator<byte>
	// System.ReadOnlySpan.Enumerator<float>
	// System.ReadOnlySpan<UnityEngine.Animations.TransformStreamHandle>
	// System.ReadOnlySpan<byte>
	// System.ReadOnlySpan<float>
	// System.Runtime.CompilerServices.ConditionalWeakTable.<>c<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.CreateValueCallback<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.Enumerator<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable<object,object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Span.Enumerator<UnityEngine.Animations.TransformStreamHandle>
	// System.Span.Enumerator<byte>
	// System.Span.Enumerator<float>
	// System.Span<UnityEngine.Animations.TransformStreamHandle>
	// System.Span<byte>
	// System.Span<float>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskFactory.<>c<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass32_0<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<object>
	// System.Tuple<object,object>
	// System.ValueTuple<ET.ActorId,object>
	// System.ValueTuple<uint,object>
	// System.ValueTuple<uint,uint>
	// System.ValueTuple<ushort,object>
	// Unity.Collections.NativeArray.Enumerator<UnityEngine.Animations.TransformStreamHandle>
	// Unity.Collections.NativeArray.Enumerator<float>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<UnityEngine.Animations.TransformStreamHandle>
	// Unity.Collections.NativeArray.ReadOnly.Enumerator<float>
	// Unity.Collections.NativeArray.ReadOnly<UnityEngine.Animations.TransformStreamHandle>
	// Unity.Collections.NativeArray.ReadOnly<float>
	// Unity.Collections.NativeArray<UnityEngine.Animations.TransformStreamHandle>
	// Unity.Collections.NativeArray<float>
	// UnityEngine.Animations.ProcessAnimationJobStruct.ExecuteJobFunction<ET.Client.AuAnimator2.AnimationJob>
	// UnityEngine.Animations.ProcessAnimationJobStruct<ET.Client.AuAnimator2.AnimationJob>
	// UnityEngine.Playables.ScriptPlayable<object>
	// }}

	public void RefMethods()
	{
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,object>(ET.ETTaskCompleted&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,object>(System.Runtime.CompilerServices.TaskAwaiter&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,object>(System.Runtime.CompilerServices.TaskAwaiter<object>&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,object>(ET.ETTaskCompleted&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,object>(System.Runtime.CompilerServices.TaskAwaiter&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,object>(System.Runtime.CompilerServices.TaskAwaiter<object>&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_BattleUI>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start_MR>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<Wait_ExitCurrentSceneFinish>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<object>(object&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.Start<object>(object&)
		// object ET.Entity.AddChild<object,int,int,object>(int,int,object,bool)
		// object ET.Entity.AddChild<object,int,int>(int,int,bool)
		// object ET.Entity.AddChild<object,int>(int,bool)
		// object ET.Entity.AddChild<object,object,object>(object,object,bool)
		// object ET.Entity.AddChild<object,object>(object,bool)
		// object ET.Entity.AddChildWithId<object,int>(long,int,bool)
		// object ET.Entity.AddChildWithId<object,object,object,object>(long,object,object,object,bool)
		// object ET.Entity.AddChildWithId<object,object,object>(long,object,object,bool)
		// object ET.Entity.AddChildWithId<object,object>(long,object,bool)
		// object ET.Entity.AddChildWithId<object>(long,bool)
		// object ET.Entity.AddComponent<object,float>(float,bool)
		// object ET.Entity.AddComponent<object,int,int>(int,int,bool)
		// object ET.Entity.AddComponent<object,int>(int,bool)
		// object ET.Entity.AddComponent<object,long>(long,bool)
		// object ET.Entity.AddComponent<object,object,int>(object,int,bool)
		// object ET.Entity.AddComponent<object,object>(object,bool)
		// object ET.Entity.AddComponent<object>(bool)
		// object ET.Entity.AddComponentWithId<object,float>(long,float,bool)
		// object ET.Entity.AddComponentWithId<object,int,int>(long,int,int,bool)
		// object ET.Entity.AddComponentWithId<object,int>(long,int,bool)
		// object ET.Entity.AddComponentWithId<object,long>(long,long,bool)
		// object ET.Entity.AddComponentWithId<object,object,int>(long,object,int,bool)
		// object ET.Entity.AddComponentWithId<object,object,object,object>(long,object,object,object,bool)
		// object ET.Entity.AddComponentWithId<object,object,object>(long,object,object,bool)
		// object ET.Entity.AddComponentWithId<object,object>(long,object,bool)
		// object ET.Entity.AddComponentWithId<object>(long,bool)
		// object ET.Entity.GetChild<object>(long)
		// object ET.Entity.GetComponent<object>()
		// object ET.Entity.GetParent<object>()
		// System.Void ET.Entity.RemoveComponent<object>()
		// System.Void ET.EntitySystemSingleton.Awake<float>(ET.Entity,float)
		// System.Void ET.EntitySystemSingleton.Awake<int,int,object>(ET.Entity,int,int,object)
		// System.Void ET.EntitySystemSingleton.Awake<int,int>(ET.Entity,int,int)
		// System.Void ET.EntitySystemSingleton.Awake<int>(ET.Entity,int)
		// System.Void ET.EntitySystemSingleton.Awake<long>(ET.Entity,long)
		// System.Void ET.EntitySystemSingleton.Awake<object,int>(ET.Entity,object,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,object,object>(ET.Entity,object,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object,object>(ET.Entity,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object>(ET.Entity,object)
		// long ET.EnumHelper.FromString<long>(string)
		// System.Void ET.EventSystem.Invoke<ET.NetComponentOnRead>(long,ET.NetComponentOnRead)
		// System.Void ET.EventSystem.Publish<object,ET.ChangePosition>(object,ET.ChangePosition)
		// System.Void ET.EventSystem.Publish<object,ET.ChangeRotation>(object,ET.ChangeRotation)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterCreateCurrentScene>(object,ET.Client.AfterCreateCurrentScene)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterCreateCurrentSceneMR>(object,ET.Client.AfterCreateCurrentSceneMR)
		// System.Void ET.EventSystem.Publish<object,ET.Client.AfterUnitCreate>(object,ET.Client.AfterUnitCreate)
		// System.Void ET.EventSystem.Publish<object,ET.Client.EnterMapFinish>(object,ET.Client.EnterMapFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ExitCurrentSceneFinish>(object,ET.Client.ExitCurrentSceneFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ExitCurrentSceneStart>(object,ET.Client.ExitCurrentSceneStart)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ExitMapFinish>(object,ET.Client.ExitMapFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.GameBattleFinish>(object,ET.Client.GameBattleFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.GameBattleStart>(object,ET.Client.GameBattleStart)
		// System.Void ET.EventSystem.Publish<object,ET.Client.GameReadyStart>(object,ET.Client.GameReadyStart)
		// System.Void ET.EventSystem.Publish<object,ET.Client.LSSceneInitFinish>(object,ET.Client.LSSceneInitFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.LSSceneInitFinishMR>(object,ET.Client.LSSceneInitFinishMR)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeFinish>(object,ET.Client.SceneChangeFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeFinishMR>(object,ET.Client.SceneChangeFinishMR)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeStart>(object,ET.Client.SceneChangeStart)
		// System.Void ET.EventSystem.Publish<object,ET.Client.SceneChangeStartMR>(object,ET.Client.SceneChangeStartMR)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.BuffAdd>(object,ET.EventType.BuffAdd)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.BuffRemove>(object,ET.EventType.BuffRemove)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.BuffTick>(object,ET.EventType.BuffTick)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.BuffUpdate>(object,ET.EventType.BuffUpdate)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.CastBreak>(object,ET.EventType.CastBreak)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.CastFinish>(object,ET.EventType.CastFinish)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.CastImpact>(object,ET.EventType.CastImpact)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.CastStart>(object,ET.EventType.CastStart)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.InventoryInited>(object,ET.EventType.InventoryInited)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.IventoryCountChanged>(object,ET.EventType.IventoryCountChanged)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.SkillBreak>(object,ET.EventType.SkillBreak)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.SkillFinish>(object,ET.EventType.SkillFinish)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.SkillImpact>(object,ET.EventType.SkillImpact)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.SkillStart>(object,ET.EventType.SkillStart)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.TakeDamage>(object,ET.EventType.TakeDamage)
		// System.Void ET.EventSystem.Publish<object,ET.EventType.UnitWeaponChanged>(object,ET.EventType.UnitWeaponChanged)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStart>(object,ET.MoveStart)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStop>(object,ET.MoveStop)
		// System.Void ET.EventSystem.Publish<object,ET.NumbericChange>(object,ET.NumbericChange)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.AppStartInitFinish>(object,ET.Client.AppStartInitFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.BattleEnd>(object,ET.Client.BattleEnd)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LSSceneChangeStart>(object,ET.Client.LSSceneChangeStart)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LSSceneChangeStartMR>(object,ET.Client.LSSceneChangeStartMR)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LoginFinish>(object,ET.Client.LoginFinish)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LoginFinishMR>(object,ET.Client.LoginFinishMR)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.UILoadingCreate>(object,ET.Client.UILoadingCreate)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.UILoadingRemove>(object,ET.Client.UILoadingRemove)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent1>(object,ET.EntryEvent1)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent2>(object,ET.EntryEvent2)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent3>(object,ET.EntryEvent3)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EventType.DropCreated>(object,ET.EventType.DropCreated)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EventType.NumericChanged>(object,ET.EventType.NumericChanged)
		// object ET.MongoHelper.FromJson<object>(string)
		// System.Void ET.ObjectHelper.Swap<object>(object&,object&)
		// object ET.ObjectPool.Fetch<object>()
		// System.Void ET.RandomGenerator.BreakRank<object>(System.Collections.Generic.List<object>)
		// string ET.StringHelper.ListToString<long>(System.Collections.Generic.List<long>)
		// object ET.World.AddSingleton<object>()
		// System.Collections.Generic.List<object> MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&)
		// System.Void MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&,System.Collections.Generic.List<object>&)
		// System.Void MemoryPack.Formatters.ListFormatter.SerializePackable<object>(MemoryPack.MemoryPackWriter&,System.Collections.Generic.List<object>&)
		// byte[] MemoryPack.Internal.MemoryMarshalEx.AllocateUninitializedArray<byte>(int,bool)
		// byte& MemoryPack.Internal.MemoryMarshalEx.GetArrayDataReference<byte>(byte[])
		// MemoryPack.MemoryPackFormatter<byte> MemoryPack.MemoryPackFormatterProvider.GetFormatter<byte>()
		// MemoryPack.MemoryPackFormatter<long> MemoryPack.MemoryPackFormatterProvider.GetFormatter<long>()
		// MemoryPack.MemoryPackFormatter<object> MemoryPack.MemoryPackFormatterProvider.GetFormatter<object>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<ET.LSInput>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<ET.LSInputMR>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<byte>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<object>()
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<ET.LSInput>(MemoryPack.MemoryPackFormatter<ET.LSInput>)
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<ET.LSInputMR>(MemoryPack.MemoryPackFormatter<ET.LSInputMR>)
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<byte>(MemoryPack.MemoryPackFormatter<byte>)
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<object>(MemoryPack.MemoryPackFormatter<object>)
		// System.Void MemoryPack.MemoryPackReader.DangerousReadUnmanagedArray<byte>(byte[]&)
		// byte[] MemoryPack.MemoryPackReader.DangerousReadUnmanagedArray<byte>()
		// MemoryPack.IMemoryPackFormatter<byte> MemoryPack.MemoryPackReader.GetFormatter<byte>()
		// MemoryPack.IMemoryPackFormatter<long> MemoryPack.MemoryPackReader.GetFormatter<long>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackReader.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadPackable<object>(object&)
		// object MemoryPack.MemoryPackReader.ReadPackable<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.ActorId>(ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.LSInput>(ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.LSInputMR>(ET.LSInputMR&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<TrueSync.FP>(TrueSync.FP&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<TrueSync.TSQuaternion>(TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<TrueSync.TSVector>(TrueSync.TSVector&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.float3>(Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion>(Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,ET.ActorId>(byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,Unity.Mathematics.float3>(byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,int>(byte&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int>(byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,ET.LSInput>(byte&,int&,long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,ET.LSInputMR>(byte&,int&,long&,ET.LSInputMR&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long>(byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int>(byte&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,TrueSync.TSVector,TrueSync.FP,uint>(byte&,long&,TrueSync.TSVector&,TrueSync.FP&,uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,TrueSync.TSVector,TrueSync.TSQuaternion,TrueSync.FP>(byte&,long&,TrueSync.TSVector&,TrueSync.TSQuaternion&,TrueSync.FP&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte&,long&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,Unity.Mathematics.float3>(byte&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,long>(byte&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long>(byte&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int>(byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,long,byte>(byte&,long&,long&,int&,long&,byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,long>(byte&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long>(byte&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,uint>(byte&,long&,uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long>(byte&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,uint>(byte&,uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte>(byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,ET.LSInput>(long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,ET.LSInputMR>(long&,ET.LSInputMR&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,TrueSync.TSVector,TrueSync.TSQuaternion>(long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<uint>(uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanagedArray<byte>(byte[]&)
		// byte[] MemoryPack.MemoryPackReader.ReadUnmanagedArray<byte>()
		// System.Void MemoryPack.MemoryPackReader.ReadValue<object>(object&)
		// byte MemoryPack.MemoryPackReader.ReadValue<byte>()
		// long MemoryPack.MemoryPackReader.ReadValue<long>()
		// object MemoryPack.MemoryPackReader.ReadValue<object>()
		// System.Void MemoryPack.MemoryPackWriter.DangerousWriteUnmanagedArray<byte>(byte[])
		// MemoryPack.IMemoryPackFormatter<byte> MemoryPack.MemoryPackWriter.GetFormatter<byte>()
		// MemoryPack.IMemoryPackFormatter<long> MemoryPack.MemoryPackWriter.GetFormatter<long>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackWriter.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackWriter.WritePackable<object>(object&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<ET.LSInput>(ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<ET.LSInputMR>(ET.LSInputMR&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<byte>(byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,ET.LSInput>(long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,ET.LSInputMR>(long&,ET.LSInputMR&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,TrueSync.TSVector,TrueSync.TSQuaternion>(long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<uint>(uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedArray<byte>(byte[])
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte,byte&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,ET.ActorId>(byte,byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,Unity.Mathematics.float3>(byte,byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,int>(byte,byte&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int>(byte,byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,ET.LSInput>(byte,byte&,int&,long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,ET.LSInputMR>(byte,byte&,int&,long&,ET.LSInputMR&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte,byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long>(byte,byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int>(byte,byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,TrueSync.TSVector,TrueSync.FP,uint>(byte,byte&,long&,TrueSync.TSVector&,TrueSync.FP&,uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,TrueSync.TSVector,TrueSync.TSQuaternion,TrueSync.FP>(byte,byte&,long&,TrueSync.TSVector&,TrueSync.TSQuaternion&,TrueSync.FP&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte,byte&,long&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte,byte&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,Unity.Mathematics.float3>(byte,byte&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte,byte&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,long>(byte,byte&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long>(byte,byte&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int>(byte,byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,long,byte>(byte,byte&,long&,long&,int&,long&,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,long>(byte,byte&,long&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long>(byte,byte&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,uint>(byte,byte&,long&,uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long>(byte,byte&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,uint>(byte,byte&,uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte>(byte,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<byte>(byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<object>(object&)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(MongoDB.Bson.IO.IBsonReader,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(string,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// MongoDB.Bson.Serialization.IBsonSerializer<object> MongoDB.Bson.Serialization.BsonSerializer.LookupSerializer<object>()
		// object MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize<object>(MongoDB.Bson.Serialization.IBsonSerializer<object>,MongoDB.Bson.Serialization.BsonDeserializationContext)
		// object ReferenceCollector.Get<object>(string)
		// object System.Activator.CreateInstance<object>()
		// byte[] System.Array.Empty<byte>()
		// object[] System.Array.Empty<object>()
		// int System.HashCode.Combine<TrueSync.TSVector2,byte>(TrueSync.TSVector2,byte)
		// int System.HashCode.Combine<TrueSync.TSVector2,int>(TrueSync.TSVector2,int)
		// int System.HashCode.Combine<object>(object)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Cast<object>(System.Collections.IEnumerable)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.CastIterator<object>(System.Collections.IEnumerable)
		// object System.Linq.Enumerable.FirstOrDefault<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<long,object>,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,object>>,System.Func<System.Collections.Generic.KeyValuePair<long,object>,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>)
		// ET.RpcInfo[] System.Linq.Enumerable.ToArray<ET.RpcInfo>(System.Collections.Generic.IEnumerable<ET.RpcInfo>)
		// object[] System.Linq.Enumerable.ToArray<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Where<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<long,object>>.Select<object>(System.Func<System.Collections.Generic.KeyValuePair<long,object>,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<object>.Select<object>(System.Func<object,object>)
		// System.Span<byte> System.MemoryExtensions.AsSpan<byte>(byte[])
		// byte& System.Runtime.CompilerServices.Unsafe.Add<byte>(byte&,int)
		// byte& System.Runtime.CompilerServices.Unsafe.As<byte,byte>(byte&)
		// object& System.Runtime.CompilerServices.Unsafe.As<object,object>(object&)
		// byte& System.Runtime.CompilerServices.Unsafe.AsRef<byte>(byte&)
		// long& System.Runtime.CompilerServices.Unsafe.AsRef<long>(long&)
		// object& System.Runtime.CompilerServices.Unsafe.AsRef<object>(object&)
		// ET.ActorId System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.ActorId>(byte&)
		// ET.LSInput System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.LSInput>(byte&)
		// ET.LSInputMR System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.LSInputMR>(byte&)
		// TrueSync.FP System.Runtime.CompilerServices.Unsafe.ReadUnaligned<TrueSync.FP>(byte&)
		// TrueSync.TSQuaternion System.Runtime.CompilerServices.Unsafe.ReadUnaligned<TrueSync.TSQuaternion>(byte&)
		// TrueSync.TSVector System.Runtime.CompilerServices.Unsafe.ReadUnaligned<TrueSync.TSVector>(byte&)
		// Unity.Mathematics.float3 System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.float3>(byte&)
		// Unity.Mathematics.quaternion System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.quaternion>(byte&)
		// byte System.Runtime.CompilerServices.Unsafe.ReadUnaligned<byte>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.ReadUnaligned<int>(byte&)
		// long System.Runtime.CompilerServices.Unsafe.ReadUnaligned<long>(byte&)
		// uint System.Runtime.CompilerServices.Unsafe.ReadUnaligned<uint>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.ActorId>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.LSInput>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.LSInputMR>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<TrueSync.FP>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<TrueSync.TSQuaternion>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<TrueSync.TSVector>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.float3>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.quaternion>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<byte>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<int>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<long>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<uint>()
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.ActorId>(byte&,ET.ActorId)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.LSInput>(byte&,ET.LSInput)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.LSInputMR>(byte&,ET.LSInputMR)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<TrueSync.FP>(byte&,TrueSync.FP)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<TrueSync.TSQuaternion>(byte&,TrueSync.TSQuaternion)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<TrueSync.TSVector>(byte&,TrueSync.TSVector)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.float3>(byte&,Unity.Mathematics.float3)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.quaternion>(byte&,Unity.Mathematics.quaternion)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<byte>(byte&,byte)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<int>(byte&,int)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<long>(byte&,long)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<uint>(byte&,uint)
		// byte& System.Runtime.InteropServices.MemoryMarshal.GetReference<byte>(System.Span<byte>)
		// System.Threading.Tasks.Task<object> System.Threading.Tasks.TaskFactory.StartNew<object>(System.Func<object>,System.Threading.CancellationToken)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.CopyStructureToPtr<ET.Client.AuAnimator2.AnimationJob>(ET.Client.AuAnimator2.AnimationJob&,System.Void*)
		// System.Void Unity.Collections.LowLevel.Unsafe.UnsafeUtility.InternalCopyStructureToPtr<ET.Client.AuAnimator2.AnimationJob>(ET.Client.AuAnimator2.AnimationJob&,System.Void*)
		// System.Void UnityEngine.Animations.AnimationScriptPlayable.CheckJobTypeValidity<ET.Client.AuAnimator2.AnimationJob>()
		// UnityEngine.Animations.AnimationScriptPlayable UnityEngine.Animations.AnimationScriptPlayable.Create<ET.Client.AuAnimator2.AnimationJob>(UnityEngine.Playables.PlayableGraph,ET.Client.AuAnimator2.AnimationJob,int)
		// UnityEngine.Playables.PlayableHandle UnityEngine.Animations.AnimationScriptPlayable.CreateHandle<ET.Client.AuAnimator2.AnimationJob>(UnityEngine.Playables.PlayableGraph,int)
		// System.Void UnityEngine.Animations.AnimationScriptPlayable.SetJobData<ET.Client.AuAnimator2.AnimationJob>(ET.Client.AuAnimator2.AnimationJob)
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationLayerMixerPlayable,UnityEngine.Playables.Playable>(UnityEngine.Animations.AnimationLayerMixerPlayable,int,UnityEngine.Playables.Playable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationLayerMixerPlayable,UnityEngine.Playables.ScriptPlayable<object>>(UnityEngine.Animations.AnimationLayerMixerPlayable,int,UnityEngine.Playables.ScriptPlayable<object>,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationMixerPlayable,UnityEngine.Animations.AnimationClipPlayable>(UnityEngine.Animations.AnimationMixerPlayable,int,UnityEngine.Animations.AnimationClipPlayable,int)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationMixerPlayable,UnityEngine.Animations.AnimationClipPlayable>(UnityEngine.Animations.AnimationMixerPlayable,int,UnityEngine.Animations.AnimationClipPlayable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationMixerPlayable,UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable,int,UnityEngine.Animations.AnimationMixerPlayable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationMixerPlayable,UnityEngine.Playables.Playable>(UnityEngine.Animations.AnimationMixerPlayable,int,UnityEngine.Playables.Playable,int)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationMixerPlayable,UnityEngine.Playables.Playable>(UnityEngine.Animations.AnimationMixerPlayable,int,UnityEngine.Playables.Playable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Animations.AnimationScriptPlayable,UnityEngine.Playables.Playable>(UnityEngine.Animations.AnimationScriptPlayable,int,UnityEngine.Playables.Playable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Playables.Playable,UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,int,UnityEngine.Playables.Playable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Playables.Playable,UnityEngine.Playables.ScriptPlayable<object>>(UnityEngine.Playables.Playable,int,UnityEngine.Playables.ScriptPlayable<object>,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Playables.ScriptPlayable<object>,UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Playables.ScriptPlayable<object>,int,UnityEngine.Animations.AnimationMixerPlayable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.ConnectInput<UnityEngine.Playables.ScriptPlayable<object>,UnityEngine.Playables.Playable>(UnityEngine.Playables.ScriptPlayable<object>,int,UnityEngine.Playables.Playable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.DisconnectInput<UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Animations.AnimationLayerMixerPlayable,int)
		// System.Void UnityEngine.Playables.PlayableExtensions.DisconnectInput<UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable,int)
		// System.Void UnityEngine.Playables.PlayableExtensions.DisconnectInput<UnityEngine.Animations.AnimationScriptPlayable>(UnityEngine.Animations.AnimationScriptPlayable,int)
		// System.Void UnityEngine.Playables.PlayableExtensions.DisconnectInput<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,int)
		// double UnityEngine.Playables.PlayableExtensions.GetDuration<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable)
		// UnityEngine.Playables.PlayableGraph UnityEngine.Playables.PlayableExtensions.GetGraph<UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Animations.AnimationLayerMixerPlayable)
		// UnityEngine.Playables.PlayableGraph UnityEngine.Playables.PlayableExtensions.GetGraph<UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable)
		// UnityEngine.Playables.PlayableGraph UnityEngine.Playables.PlayableExtensions.GetGraph<UnityEngine.Animations.AnimationScriptPlayable>(UnityEngine.Animations.AnimationScriptPlayable)
		// UnityEngine.Playables.PlayableGraph UnityEngine.Playables.PlayableExtensions.GetGraph<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable)
		// UnityEngine.Playables.PlayableGraph UnityEngine.Playables.PlayableExtensions.GetGraph<UnityEngine.Playables.ScriptPlayable<object>>(UnityEngine.Playables.ScriptPlayable<object>)
		// UnityEngine.Playables.Playable UnityEngine.Playables.PlayableExtensions.GetInput<UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Animations.AnimationLayerMixerPlayable,int)
		// UnityEngine.Playables.Playable UnityEngine.Playables.PlayableExtensions.GetInput<UnityEngine.Animations.AnimationScriptPlayable>(UnityEngine.Animations.AnimationScriptPlayable,int)
		// UnityEngine.Playables.Playable UnityEngine.Playables.PlayableExtensions.GetInput<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,int)
		// UnityEngine.Playables.Playable UnityEngine.Playables.PlayableExtensions.GetOutput<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,int)
		// double UnityEngine.Playables.PlayableExtensions.GetSpeed<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable)
		// double UnityEngine.Playables.PlayableExtensions.GetTime<UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable)
		// double UnityEngine.Playables.PlayableExtensions.GetTime<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable)
		// bool UnityEngine.Playables.PlayableExtensions.IsNull<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable)
		// bool UnityEngine.Playables.PlayableExtensions.IsValid<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetDuration<UnityEngine.Animations.AnimationClipPlayable>(UnityEngine.Animations.AnimationClipPlayable,double)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetDuration<UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable,double)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetDuration<UnityEngine.Playables.ScriptPlayable<object>>(UnityEngine.Playables.ScriptPlayable<object>,double)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetInputWeight<UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Animations.AnimationLayerMixerPlayable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetInputWeight<UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetInputWeight<UnityEngine.Animations.AnimationScriptPlayable>(UnityEngine.Animations.AnimationScriptPlayable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetInputWeight<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetInputWeight<UnityEngine.Playables.ScriptPlayable<object>>(UnityEngine.Playables.ScriptPlayable<object>,int,float)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetSpeed<UnityEngine.Animations.AnimationClipPlayable>(UnityEngine.Animations.AnimationClipPlayable,double)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetSpeed<UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable,double)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetSpeed<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,double)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetTime<UnityEngine.Animations.AnimationClipPlayable>(UnityEngine.Animations.AnimationClipPlayable,double)
		// System.Void UnityEngine.Playables.PlayableExtensions.SetTime<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,double)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Animations.AnimationClipPlayable,UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationClipPlayable,int,UnityEngine.Animations.AnimationMixerPlayable,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Animations.AnimationMixerPlayable,UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable,int,UnityEngine.Animations.AnimationMixerPlayable,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Animations.AnimationMixerPlayable,UnityEngine.Playables.ScriptPlayable<object>>(UnityEngine.Animations.AnimationMixerPlayable,int,UnityEngine.Playables.ScriptPlayable<object>,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Playables.Playable,UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Playables.Playable,int,UnityEngine.Animations.AnimationLayerMixerPlayable,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Playables.Playable,UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Playables.Playable,int,UnityEngine.Animations.AnimationMixerPlayable,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Playables.Playable,UnityEngine.Animations.AnimationScriptPlayable>(UnityEngine.Playables.Playable,int,UnityEngine.Animations.AnimationScriptPlayable,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Playables.Playable,UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,int,UnityEngine.Playables.Playable,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Playables.Playable,UnityEngine.Playables.ScriptPlayable<object>>(UnityEngine.Playables.Playable,int,UnityEngine.Playables.ScriptPlayable<object>,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Playables.ScriptPlayable<object>,UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Playables.ScriptPlayable<object>,int,UnityEngine.Animations.AnimationLayerMixerPlayable,int)
		// bool UnityEngine.Playables.PlayableGraph.Connect<UnityEngine.Playables.ScriptPlayable<object>,UnityEngine.Playables.Playable>(UnityEngine.Playables.ScriptPlayable<object>,int,UnityEngine.Playables.Playable,int)
		// System.Void UnityEngine.Playables.PlayableGraph.Disconnect<UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Animations.AnimationLayerMixerPlayable,int)
		// System.Void UnityEngine.Playables.PlayableGraph.Disconnect<UnityEngine.Animations.AnimationMixerPlayable>(UnityEngine.Animations.AnimationMixerPlayable,int)
		// System.Void UnityEngine.Playables.PlayableGraph.Disconnect<UnityEngine.Animations.AnimationScriptPlayable>(UnityEngine.Animations.AnimationScriptPlayable,int)
		// System.Void UnityEngine.Playables.PlayableGraph.Disconnect<UnityEngine.Playables.Playable>(UnityEngine.Playables.Playable,int)
		// int UnityEngine.Playables.PlayableOutputExtensions.GetSourceOutputPort<UnityEngine.Animations.AnimationPlayableOutput>(UnityEngine.Animations.AnimationPlayableOutput)
		// System.Void UnityEngine.Playables.PlayableOutputExtensions.SetSourcePlayable<UnityEngine.Animations.AnimationPlayableOutput,UnityEngine.Animations.AnimationLayerMixerPlayable>(UnityEngine.Animations.AnimationPlayableOutput,UnityEngine.Animations.AnimationLayerMixerPlayable)
		// System.Void UnityEngine.Playables.PlayableOutputExtensions.SetSourcePlayable<UnityEngine.Animations.AnimationPlayableOutput,UnityEngine.Animations.AnimationScriptPlayable>(UnityEngine.Animations.AnimationPlayableOutput,UnityEngine.Animations.AnimationScriptPlayable)
		// YooAsset.AllAssetsOperationHandle YooAsset.ResourcePackage.LoadAllAssetsAsync<object>(string)
		// YooAsset.AssetOperationHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string)
	}
}