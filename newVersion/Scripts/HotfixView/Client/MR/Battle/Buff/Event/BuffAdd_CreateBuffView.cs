using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class BuffAdd_CreateBuffView: AEvent<Scene, BuffAdd>
    {
        protected override async ETTask Run(Scene scene, BuffAdd a)
        {
            ClientBuff clientBuff = a.Unit.GetComponent<ClientBuffComponent>().Get((a.BuffId));
            if (clientBuff == null)
            {
                return;
            }

            BuffConfig buffConfig = clientBuff.Config;
            foreach (int fxId in buffConfig.OwnerFXs)
            {
                FXHelper.CreateFX(a.Unit, fxId).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}