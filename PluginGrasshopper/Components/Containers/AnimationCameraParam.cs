using System;
using Grasshopper.Kernel;

namespace Manakin.PluginGrasshopper.Components.Containers
{
    public class AnimationCameraParam:  GH_Param<AnimationCamera>
    {
        public AnimationCameraParam() : base(new GH_InstanceDescription("Animation Camera", "AC", "Parameter for animation camera", "Manakin", "Parameters"))
        {
        }

        public override Guid ComponentGuid => new Guid("703022D8-0967-4553-95B6-107E496A91E8");

        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Animation Camera_24.png");

        public override GH_Exposure Exposure => GH_Exposure.secondary;
        
    }
}