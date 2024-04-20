namespace ET.Server
{
    public enum CastSelectType
    {
        /// <summary>
        /// 由子弹或buff指定
        /// </summary>
        External = 0,

        /// <summary>
        /// 选择自己
        /// </summary>
        SelfSelect = 1,

        /// <summary>
        /// 自身圆形范围搜索
        /// 参数1: 是否包含自己
        /// 参数1: 范围(半径)
        /// </summary>
        SelectInCircle = 2,

        /// <summary>
        /// 自身前方扇形范围搜索
        /// 参数1: 是否包含自己
        /// 参数2: 范围(扇形,半径)
        /// 参数3: 角度
        /// </summary>
        SelectInFan = 3,

        /// <summary>
        /// 自身前方矩形范围搜索
        /// 参数1: 是否包含自己 
        /// 参数2: 范围(矩形,长)
        /// 参数3: 范围(矩形,宽)
        /// </summary>
        SelectInRectangle = 4,
    }
}