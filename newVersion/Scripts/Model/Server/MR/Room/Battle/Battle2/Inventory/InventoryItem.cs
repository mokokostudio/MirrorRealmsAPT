using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof (InventoryComponent))]
    public class InventoryItem: Entity, IAwake<int, int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;

        [BsonIgnore]
        public ItemConfig Config => ItemConfigCategory.Instance.Get(this.ConfigId);

        public MrInventoryType ItemType => (MrInventoryType)this.Config.ItemType;

        public int Count;
    }
}