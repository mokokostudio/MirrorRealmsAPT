using System.Collections.Generic;

namespace ET
{
    public struct CastBehaviorTimes
    {
        public int Index;
        public bool IsSelfImpact;
    }

    public sealed partial class CastConfig
    {
        public List<int> Times = new();

        public MultiMap<int, CastBehaviorTimes> TimesDict = new();

        public override void EndInit()
        {
            for (int i = 0; i < this.SelfImpactBehaviorTimes.Length; ++i)
            {
                int time = this.SelfImpactBehaviorTimes[i];
                if (!this.Times.Contains(time))
                {
                    this.Times.Add(time);
                }

                this.TimesDict.Add(time, new CastBehaviorTimes() { Index = i, IsSelfImpact = true });
            }

            for (int i = 0; i < this.ImpactBehaviorTimes.Length; ++i)
            {
                int time = this.ImpactBehaviorTimes[i];
                if (!this.Times.Contains(time))
                {
                    this.Times.Add(time);
                }

                this.TimesDict.Add(time, new CastBehaviorTimes() { Index = i, IsSelfImpact = false });
            }

            this.Times.Sort();

            base.EndInit();
        }
    }
}