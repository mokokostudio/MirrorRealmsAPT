namespace ET.Server
{
    [ChildOf(typeof (BuffTempComponent))]
    public class BuffCreateInfo: Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId { get; set; }

        // 施法者 状态来源, 关联技能等
    }
}