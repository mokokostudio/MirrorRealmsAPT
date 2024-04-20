namespace ET.Client
{
    public struct MrWait_CreateMyUnit: IWaitType
    {
        public int Error
        {
            get;
            set;
        }

        public MrM2C_CreateMyUnit Message;
    }
}