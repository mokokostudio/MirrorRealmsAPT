using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ET.Server
{
    [Code]
    public class BehaviorDispatcher: Singleton<BehaviorDispatcher>, ISingletonAwake
    {
        private readonly Dictionary<int, IBehavior> Dict = new();

        public void Awake()
        {
            Log.Info("BehaviorDispatcher::Awake()");

            this.Dict.Clear();

            var types = CodeTypes.Instance.GetTypes(typeof (BehaviorAttribute));

            foreach (Type type in types)
            {
                object[] attribute = type.GetCustomAttributes(typeof (BehaviorAttribute), false);
                if (attribute.Length == 0)
                {
                    continue;
                }

                BehaviorAttribute behaviorAttribute = attribute[0] as BehaviorAttribute;
                object obj = Activator.CreateInstance(type);

                IBehavior iBehavior = obj as IBehavior;
                if (iBehavior == null)
                {
                    throw new Exception($"type not is IBehavior: {obj.GetType().Name}");
                }

                this.Dict.Add(behaviorAttribute.BehaviorType, iBehavior);
            }
        }

        public IBehavior Get(int type)
        {
            if (this.Dict.TryGetValue(type, out IBehavior behavior))
            {
                return behavior;
            }

            return null;
        }
    }
}