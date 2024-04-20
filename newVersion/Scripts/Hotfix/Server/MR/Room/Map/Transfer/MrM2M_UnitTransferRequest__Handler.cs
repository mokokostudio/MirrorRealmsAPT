using System;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.MrRoom)]
    public class MrM2M_UnitTransferRequest__Handler: MessageHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = MongoHelper.Deserialize<Unit>(request.Unit);

            try
            {
                unitComponent.RemoveChild(unit.Id);
                unitComponent.AddChild(unit);
                unitComponent.Add(unit);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            foreach (byte[] bytes in request.Entitys)
            {
                Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                unit.AddComponent(entity);
            }

            unit.AddComponent<MoveComponent>();
            unit.AddComponent<PathfindingComponent, string>(scene.Name);
            unit.Position = new float3(0, 0, -10);

            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);

            // 通知客户端开始切场景
            var startSceneChangeMsg = M2C_StartSceneChange.Create();
            startSceneChangeMsg.SceneInstanceId = scene.InstanceId;
            startSceneChangeMsg.SceneName = scene.Name;
            MrMapMessageHelper.SendToClient(unit, startSceneChangeMsg);

            // 通知客户端创建My Unit
            var createMyUnitMsg = MrM2C_CreateMyUnit.Create();
            createMyUnitMsg.Unit = UnitHelper.CreateUnitInfo(unit, true);
            MrMapMessageHelper.SendToClient(unit, createMyUnitMsg);

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}