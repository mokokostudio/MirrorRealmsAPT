namespace ET.Server
{
    [MessageHandler(SceneType.MrRoom)]
    public class C2M_UseItem__Handler: MessageLocationHandler<Unit, MrC2M_UseItem, MrM2C_UseItem>
    {
        protected override async ETTask Run(Unit unit, MrC2M_UseItem request, MrM2C_UseItem response)
        {
            var itemConfig = ItemConfigCategory.Instance.Get(request.ItemConfigId);
            if (itemConfig == null)
            {
                response.Error = ErrorCode.ERR_UseItem_IdError;
                response.Message = $"ItemConfig为空";
                return;
            }

            if ((MrInventoryType)itemConfig.ItemType == MrInventoryType.Rune)
            {
                var runeConfig = RuneConfigCategory.Instance.Get(itemConfig.SubConfigId);
                if (runeConfig == null)
                {
                    response.Error = ErrorCode.ERR_UseItem_IdError;
                    response.Message = $"RuneConfig为空";
                    return;
                }

                var error = unit.GetComponent<SkillComponent>().StartCast(runeConfig.Skill);
                if (error != ErrorCode.ERR_Success)
                {
                    response.Error = error;
                    response.Message = $"物品技能释放失败";
                    return;
                }
            }
            else
            {
                response.Error = ErrorCode.ERR_UseItem_TypeError;
            }

            await ETTask.CompletedTask;
        }
    }
}