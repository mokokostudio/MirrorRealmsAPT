using UnityEngine.UI;

namespace ET
{
    public class NoDrawGraphic : MaskableGraphic
    {
        public override void SetMaterialDirty()
        {
        }

        public override void SetVerticesDirty()
        {
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}

// EOF