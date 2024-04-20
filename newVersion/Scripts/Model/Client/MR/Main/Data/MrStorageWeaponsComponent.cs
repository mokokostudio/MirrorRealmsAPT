namespace ET.Client
{
    [ComponentOf(typeof(MrPlayerInfoComponent))]
    public class MrStorageWeaponsComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {

    }

    [ComponentOf(typeof(MrStorageWeaponsComponent))]
    public class MrStorageWeaponInfoComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {

    }
}

// EOF