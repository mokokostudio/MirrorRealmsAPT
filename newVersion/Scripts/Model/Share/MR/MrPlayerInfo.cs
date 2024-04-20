namespace ET
{
    [ComponentOf(typeof (Unit))]
    public class MrPlayerInfo: Entity, IAwake<string>, ISerializeToEntity
    {
        public string Name;
    }
}