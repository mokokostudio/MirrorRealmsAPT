namespace ET.Server
{
    [MessageHandler(SceneType.MrRoom)]
    public class MrC2M_CastSkill__Handler: MessageLocationHandler<Unit, C2M_CastSkill, M2C_CastSkill>
    {
        protected override async ETTask Run(Unit unit, C2M_CastSkill request, M2C_CastSkill response)
        {
            int error = CanCastSkill(unit, request.SkillName);

            if (error != ErrorCode.ERR_Success)
            {
                response.Error = error;
                response.Message = $"释放技能失败";
                return;
            }

            error = unit.GetComponent<SkillComponent>().StartCast(request.SkillName);

            if (error != ErrorCode.ERR_Success)
            {
                response.Error = error;
                response.Message = $"释放技能失败";
                return;
            }

            response.Error = ErrorCode.ERR_Success;
            await ETTask.CompletedTask;
        }

        private static int CanCastSkill(Unit unit, string skillName)
        {
            if (!SkillConfigComponent.Instance.Has(skillName))
            {
                return ErrorCode.ERR_Cast_ArgsError;
            }

            if (!unit.IsAlive())
            {
                return ErrorCode.ERR_Caster_NotAlive;
            }

            return ErrorCode.ERR_Success;
        }
    }
}