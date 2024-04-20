namespace ET.Server
{
    public static class MrLobbyMapFactory
    {
        public static async ETTask<Scene> Create(Entity parent, long id, long instanceId, string name)
        {
            await ETTask.CompletedTask;
            Scene scene = EntitySceneFactory.CreateScene(parent, id, instanceId, SceneType.MrRoom, name);

            scene.AddComponent<UnitComponent>();
            scene.AddComponent<AOIManagerComponent>();
            
            scene.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            
            return scene;
        }
        
    }
}