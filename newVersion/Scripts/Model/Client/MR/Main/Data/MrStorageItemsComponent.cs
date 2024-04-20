namespace ET.Client
{
    [ComponentOf(typeof(MrPlayerInfoComponent))]
    public class MrStorageItemsComponent: Entity, IAwake, IDestroy, ISerializeToEntity
    {

    }

    [ComponentOf(typeof(MrStorageItemsComponent))]
    public class MrStorageItemInfoComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {

    }
}

// EOF