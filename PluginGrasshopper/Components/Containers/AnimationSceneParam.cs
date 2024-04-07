using System;
using Grasshopper.Kernel;

namespace Manakin.PluginGrasshopper.Components.Containers
{
    public class AnimationGeometryScene:  GH_Param<Scene>
    {
        public AnimationGeometryScene() : base(new GH_InstanceDescription("Animation Scene", "AS", "Parameter for animation scene", "Manakin", "Parameters"))
        {
        }

        public override Guid ComponentGuid => new Guid("EBBCD8D3-A8D1-439B-BC04-B0F3B05AEDB5");

        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Animation Scene_24.png");

        public override GH_Exposure Exposure => GH_Exposure.secondary;
        
    }
}