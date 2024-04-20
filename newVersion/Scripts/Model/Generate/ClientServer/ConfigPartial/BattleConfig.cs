using System.Collections.Generic;

namespace ET
{
    public partial class BattleConfigCategory
    {
        private readonly Dictionary<string, int> Key2Id = new();

        public override void EndInit()
        {
            this.Key2Id.Clear();
            foreach (BattleConfig battleConfig in this.GetAll().Values)
            {
                this.Key2Id.Add(battleConfig.Key, battleConfig.Id);
            }

            base.EndInit();
        }

        public BattleConfig GetByKey(string key)
        {
            if (this.Key2Id.TryGetValue(key, out int id))
                return this.Get(id);
            return null;
        }
    }
}