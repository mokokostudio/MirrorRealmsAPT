namespace ET
{
    public enum ProjectileSelectType
    {
        None = 0,

        /// <summary>
        /// 圆形
        /// Params:
        ///   - 0 : 是否选中主人
        ///   - 1 : 半径
        /// </summary>
        Circle = 1,

        /// <summary>
        /// 扇形
        /// Params:
        ///   - 0 : 是否选中主人
        ///   - 1 : 半径
        ///   - 2 : 角度
        /// </summary>
        Fan = 2,

        /// <summary>
        /// 矩形
        /// Params:
        ///   - 0 : 是否选中主人
        ///   - 1 : 长(前后边界)
        ///   - 2 : 宽(左右边界)
        /// </summary>
        Rectangle = 3,
    }
}