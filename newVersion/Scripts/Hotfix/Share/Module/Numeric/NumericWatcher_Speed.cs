namespace ET
{
    /// <summary>
    /// 客户端监视speed数值变化
    /// </summary>
    [NumericWatcher(SceneType.Demo, NumericType.Speed)]
    public class NumericWatcher_Speed: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            Log.Info($"unit({unit}),speed changed {args.Old} -> {args.New}");
        }
    }
}