using ET.EventType;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    [FriendOfAttribute(typeof (ClientCast))]
    public class M2C_CastStartHandler: MessageHandler<Scene, M2C_CastStart>
    {
        protected override async ETTask Run(Scene scene, M2C_CastStart message)
        {
            Log.Console($"Zone: {scene.Zone()} -> 施法者 {message.CasterId} 开始施法 {message.CastCongfigId} 技能 {message.CastId} ");

            Unit caster = scene.CurrentScene().GetComponent<UnitComponent>().Get(message.CasterId);
            if (caster == null)
            {
                return;
            }

            ClientCast clientCast = ClientCastFactory.Create(caster, message.CastId, (int)message.CastCongfigId);
            clientCast.TargetIds.AddRange(message.TargetIds);
            caster.GetComponent<ClientCastComponent>().Add(clientCast);

            EventSystem.Instance.Publish(scene.CurrentScene(),
                new CastStart() { CasterId = message.CasterId, CastConfigId = message.CastCongfigId, CastId = message.CastId, });

            await ETTask.CompletedTask;
        }
    }
}