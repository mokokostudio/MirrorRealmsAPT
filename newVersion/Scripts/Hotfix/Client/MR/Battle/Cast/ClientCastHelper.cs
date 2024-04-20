namespace ET.Client
{
    public static class ClientCastHelper
    {
        public static async ETTask<int> CastCast(Scene scene, int castConfigId)
        {
            // M2C_TestCast msg = (M2C_TestCast)await scene.GetComponent<SessionComponent>().Session
            //         .Call(new C2M_TestCast() { CastConfigId = castConfigId });
            var request = new C2M_TestCast() { CastConfigId = castConfigId };
            M2C_TestCast msg = (M2C_TestCast)await scene.Root().GetComponent<MrClientSenderCompnent>().Call(request);

            return msg.Error;
        }

        public static async ETTask<int> CastSkill(Scene scene, string skillName)
        {
            var request = new C2M_CastSkill() { SkillName = skillName };
            M2C_CastSkill msg = (M2C_CastSkill)await scene.Root().GetComponent<MrClientSenderCompnent>().Call(request);

            return msg.Error;
        }
    }
}