using UnityEngine;

namespace ET.Client
{
    public static class QualityColor
    {
        public static Color GetColor(MrItemQuality quality)
        {
            return quality switch
            {
                MrItemQuality.White => Color.white,
                MrItemQuality.Green => Color.green,
                MrItemQuality.Blue => Color.blue,
                MrItemQuality.Yellow => Color.yellow,
                _ => Color.white
            };
        }
    }
}