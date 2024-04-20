
namespace ET.Server
{
    [MessageSessionHandler(SceneType.MrRoom)]
    public class MrC2M_ExitRoom__Handler : MessageSessionHandler<MrC2M_ExitRoom, MrM2C_ExitRoom>
    {
        protected override async ETTask Run(Session session, MrC2M_ExitRoom request, MrM2C_ExitRoom response)
        {
            var player = session.GetComponent<MrSessionPlayer>().Player;
            
            // TODO: 这里要处理的是退出房间的逻辑, 也就是玩家放弃了主动退出(放弃)比赛
            
       

            await ETTask.CompletedTask;
        }
    }
}

// EOF