using System.Collections.Generic;
using Box2DSharp.Dynamics;

namespace ET.Server
{
    /// <summary>
    /// 物理世界组件，代表一个物理世界
    /// </summary>
    public class B2S_WorldComponent: Entity, IAwake, IDestroy, ILateUpdate
    {
        public Box2DSharp.Dynamics.World World;

        public List<Body> BodyToDestroy = new List<Body>();

        public const int VelocityIteration = 10;
        public const int PositionIteration = 10;
    }
}