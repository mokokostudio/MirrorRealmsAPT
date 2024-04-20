using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class ClientInventoryComponent: Entity, IAwake<List<InventoryItemProto>>, IDestroy
    {
    }
}