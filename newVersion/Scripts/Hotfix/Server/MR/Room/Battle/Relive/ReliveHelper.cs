using Unity.Mathematics;

namespace ET.Server
{
    [FriendOfAttribute(typeof (ET.Server.ReliveComponent))]
    public static class ReliveHelper
    {
        public static bool IsAlive(this Unit unit)
        {
            return unit.GetComponent<ReliveComponent>()?.Alive ?? true;
        }

        public static int OnSiteRelive(this Unit unit)
        {
            if (unit.IsAlive())
            {
                return ErrorCode.ERR_Relive_Alive;
            }

            unit.DoRelive(unit.Position, 1);
            return ErrorCode.ERR_Success;
        }

        public static int PointRelive(this Unit unit, float3 pos)
        {
            if (unit.IsAlive())
            {
                return ErrorCode.ERR_Relive_Alive;
            }

            unit.DoRelive(pos, 1);
            return ErrorCode.ERR_Success;
        }

        public static void DoRelive(this Unit unit, float3 pos, float hpRate)
        {
            if (unit.IsAlive())
            {
                return;
            }

            unit.Position = pos;
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent != null)
            {
                numericComponent.Set(NumericType.HpBase,
                    math.clamp((long)(numericComponent.GetAsFloat(NumericType.MaxHp) * hpRate), 1, numericComponent.GetAsLong(NumericType.MaxHp)));
            }

            unit.GetComponent<ReliveComponent>().Alive = true;
        }
    }
}