namespace ET.Server
{
    [FriendOf(typeof (Cast))]
    public static class CastHelper
    {
        public static int CreateAndCast(this Unit caster, int castConfigId)
        {
            return caster.CreateCast(castConfigId).Cast();
        }

        public static Cast CreateCast(this Unit caster, int castConfigId)
        {
            CastComponent castComponent = caster.GetComponent<CastComponent>();
            if (castComponent == null)
            {
                return null;
            }

            Cast cast = castComponent.Create(castConfigId);
            cast.Caster = caster;

            caster.GetComponent<SkillStatusComponent>()?.StartSkill(cast);

            return cast;
        }
    }
}