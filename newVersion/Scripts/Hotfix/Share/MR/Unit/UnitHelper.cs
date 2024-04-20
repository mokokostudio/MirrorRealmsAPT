using Unity.Mathematics;

namespace ET
{
    public static class UnitHelper
    {
        public static void SetRotationConsiderForbidRotation(this Unit unit, quaternion rotation)
        {
            bool forbidRotation = (unit.GetComponent<NumericComponent>()?.GetAsInt(NumericType.ForbidRotation) ?? 0) > 0;
            if (forbidRotation)
            {
                return;
            }

            unit.Rotation = rotation;
        }
    }
}