using Unity.Mathematics;

namespace ET
{
    public partial class PositionConfig
    {
        public float3 Position => new float3(this.PosX * 0.001f, 0, this.PosZ * 0.001f);
    }
}