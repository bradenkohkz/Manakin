using System;
using Grasshopper.Kernel;

namespace Manakin.PluginGrasshopper.Components.Containers
{
    public class AnimationGeometryParam:  GH_Param<AnimationGeometry>
    {
        public AnimationGeometryParam() : base(new GH_InstanceDescription("Animation Geometry", "AG", "Parameter for animation geometry", "Manakin", "Parameters"))
        {
        }

        public override Guid ComponentGuid => new Guid("2FB21728-D51E-47AF-86DE-706318DC7542");

        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Animation Geometry_24.png");

        public override GH_Exposure Exposure => GH_Exposure.secondary;
        
    }
}