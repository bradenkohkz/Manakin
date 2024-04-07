using System;
using Grasshopper.Kernel;

namespace Manakin.PluginGrasshopper.Components.Containers
{
    public class AnimationOperationParam:  GH_Param<BaseOperation>
    {
        public AnimationOperationParam() : base(new GH_InstanceDescription("Animation Operation", "AO", "Parameter for animation operation", "Manakin", "Parameters"))
        {
        }

        public override Guid ComponentGuid => new Guid("37C45795-6129-435E-9EF9-40E642414104");

        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Animation Operation_24.png");

        public override GH_Exposure Exposure => GH_Exposure.secondary;
        
    }
}