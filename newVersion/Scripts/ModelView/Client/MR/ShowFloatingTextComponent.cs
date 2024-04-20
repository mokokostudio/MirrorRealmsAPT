using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class ShowFloatingTextComponent: Entity, IAwake, IDestroy
    {
        public GameObject ShowFloatingTextTemplate;
        public int ChildrenSortingOrder;
    }
}