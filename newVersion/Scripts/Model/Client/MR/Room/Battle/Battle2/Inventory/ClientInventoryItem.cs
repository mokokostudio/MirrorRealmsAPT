namespace ET.Client
{
    [ChildOf(typeof (ClientInventoryComponent))]
    public class ClientInventoryItem: Entity, IAwake<int, int>, IDestroy
    {
        public int ConfigId;

        public ItemConfig Config => ItemConfigCategory.Instance.Get(this.ConfigId);
        
        public MrInventoryType ItemType => (MrInventoryType)this.Config.ItemType;

        public int Count;
    }
}