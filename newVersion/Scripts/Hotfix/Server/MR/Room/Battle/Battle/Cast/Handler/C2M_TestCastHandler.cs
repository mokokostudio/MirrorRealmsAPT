namespace ET.Server
{
    [MessageHandler(SceneType.MrRoom)]
    public class C2M_TestCastHandler: MessageLocationHandler<Unit, C2M_TestCast, M2C_TestCast>
    {
        protected override async ETTask Run(Unit unit, C2M_TestCast request, M2C_TestCast response)
        {
            int err = BattleHelper.CanCastSkill(unit, request.CastConfigId);

            if (err != ErrorCode.ERR_Success)
            {
                response.Error = err;
                response.Message = $"释放技能失败";
                return;
            }

            response.Error = unit.CreateAndCast(request.CastConfigId);

            await ETTask.CompletedTask;
        }
    }
}