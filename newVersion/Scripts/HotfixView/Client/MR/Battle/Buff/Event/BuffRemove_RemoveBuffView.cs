using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class BuffRemove_RemoveBuffView: AEvent<Scene, BuffRemove>
    {
        protected override async ETTask Run(Scene scene, BuffRemove a)
        {
            ClientBuff clientBuff = a.Unit.GetComponent<ClientBuffComponent>().Get((a.BuffId));
            if (clientBuff == null)
            {
                return;
            }

            BuffConfig buffConfig = clientBuff.Config;
            // foreach (int fxId in buffConfig.OwnerFXs)
            // {
            //    
            // }
            await ETTask.CompletedTask;
        }
    }
}