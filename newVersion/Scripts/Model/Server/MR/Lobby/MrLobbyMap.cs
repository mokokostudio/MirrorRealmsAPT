﻿namespace ET.Server
{
    [ComponentOf(typeof (MrPlayer))]
    public class MrLobbyMap: Entity, IAwake
    {
        private EntityRef<Scene> scene;

        public Scene Scene
        {
            get
            {
                return this.scene;
            }
            set
            {
                this.scene = value;
            }
        }
    }
}