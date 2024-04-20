namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public sealed class CastComponent: Entity, IAwake, IDestroy, ITransfer
    {
    }
}