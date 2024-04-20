using Unity.Mathematics;

namespace ET
{
    public static class MrGeometry2DUtility
    {
        public static bool IsInCircle(float3 obsPos, float3 tarPos, float tarRadius, double circleRadius)
        {
            var direction = tarPos - obsPos;
            direction.y = 0;
            
            if (math.lengthsq(direction) > circleRadius * circleRadius)
            {
                return false;
            }

            return true;
        }

        public static bool IsInFrontFan(float3 obsPos, float3 obsForward, float3 tarPos, float tarRadius, float fanRadius, float angle)
        {
            var direction = tarPos - obsPos;
            direction.y = 0;

            if (math.lengthsq(direction) > fanRadius * fanRadius)
            {
                return false;
            }

            var dot = math.dot(math.normalize(direction), obsForward);
            var radians = math.acos(dot);
            float offsetAngle = math.degrees(radians);
            if (offsetAngle > angle * .5f)
            {
                return false;
            }

            return true;
        }

        public static bool IsInFrontRectangle(float3 obsPos, float3 obsForward, float3 tarPos, float tarRadius, float length, float width)
        {
            var direction = tarPos - obsPos;
            direction.y = 0;

            var dot = math.dot(obsForward, direction);

            if (dot < 0)
            {
                return false;
            }

            float forwardProject = math.length(math.project(direction, obsForward));

            if (forwardProject > length)
            {
                return false;
            }

            float3 right = math.cross(obsForward, math.up());
            float rightProject = math.length(math.project(direction, right));
            if (math.abs(rightProject) > width * .5f)
            {
                return false;
            }

            return true;
        }
    }
}