namespace ET.Client
{
    namespace WaitType
    {
        public struct Wait_GameRoom2C_Start : IWaitType
        {
            public int Error { get; set; }

            public MrM2C_Start Message;
        }

        public struct Wait_BattleUI : IWaitType
        {
            public int Error { get; set; }
        }
        
        
        public struct Wait_ExitCurrentSceneFinish : IWaitType
        {
            public int Error
            {
                get;
                set;
            }
        }


    }
}