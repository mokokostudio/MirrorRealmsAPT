namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class InventoryComponent: Entity, IAwake, IDestroy, ITransfer, IDeserialize
    {
    }
}