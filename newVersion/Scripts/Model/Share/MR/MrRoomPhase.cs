namespace ET
{
    public enum MrRoomPhase
    {
        Invalid = 0, // 无效
        Ready, // 准备
        Phase_1, // 第一波怪
        Phase_2, // 第二波怪
        Phase_3, // 第三波怪
        Escap, // 逃离
        End, // 结束
    }
}