namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MrClientSenderCompnent: Entity, IAwake, IDestroy
    {
        public int fiberId;

        public ActorId netClientActorId;
    }
}