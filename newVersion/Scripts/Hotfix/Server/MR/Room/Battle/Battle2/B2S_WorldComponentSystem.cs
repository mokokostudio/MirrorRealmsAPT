using System.Numerics;
using Box2DSharp.Dynamics;
using ET.Server;

namespace ET
{
    [EntitySystemOf(typeof (B2S_WorldComponent))]
    [FriendOfAttribute(typeof (B2S_WorldComponent))]
    public static partial class B2S_WorldComponentSystem
    {
        [EntitySystem]
        private static void Awake(this B2S_WorldComponent self)
        {
            // 我们需要的是水平的(暗黑破坏神)2D, 不是垂直的(马里奥)2D, 所以不需要重力
            self.World = new Box2DSharp.Dynamics.World(Vector2.Zero);
        }

        [EntitySystem]
        private static void Destroy(this B2S_WorldComponent self)
        {
            foreach (var body in self.BodyToDestroy)
            {
                self.World.DestroyBody(body);
            }

            self.BodyToDestroy.Clear();

            self.World.Dispose();
            self.World = null;
        }

        [EntitySystem]
        private static void LateUpdate(this B2S_WorldComponent self)
        {
            foreach (var body in self.BodyToDestroy)
            {
                self.World.DestroyBody(body);
            }

            self.BodyToDestroy.Clear();
            self.World.Step(0.02f, B2S_WorldComponent.VelocityIteration, B2S_WorldComponent.PositionIteration);
        }

        public static void AddBodyTobeDestroyed(this B2S_WorldComponent self, Body body)
        {
            self.BodyToDestroy.Add(body);
        }

        public static Body CreateDynamicBody(this B2S_WorldComponent self)
        {
            return self.World.CreateBody(new BodyDef() { BodyType = BodyType.DynamicBody, AllowSleep = false });
        }

        public static Body CreateStaticBody(this B2S_WorldComponent self)
        {
            return self.World.CreateBody(new BodyDef() { BodyType = BodyType.StaticBody });
        }
    }
}