namespace ET.Client
{
    public struct UILoadingCreate { }

    public struct UILoadingRemove { }


    public enum WeaponQualityType
    {
        N = 0,
        R,
        SR,
        SSR,
    }

    public struct InitUseItemPanelInfo { }
    public struct UseItem {
        public int itemId;
        public int useNumber;
    }
}

// EOF