namespace ET.Server
{
    [EntitySystemOf(typeof (BuffCreateInfo))]
    public static partial class BuffCreateInfoSystem
    {
        [EntitySystem]
        private static void Awake(this BuffCreateInfo self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this BuffCreateInfo self)
        {
            self.ConfigId = default;
        }
    }
}