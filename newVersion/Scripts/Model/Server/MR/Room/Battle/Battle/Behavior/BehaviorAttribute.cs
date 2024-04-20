namespace ET.Server
{
    public class BehaviorAttribute: BaseAttribute
    {
        public int BehaviorType { get; }

        public BehaviorAttribute(int behaviorType)
        {
            this.BehaviorType = behaviorType;
        }
    }
}