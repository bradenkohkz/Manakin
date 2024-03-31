using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Manakin.PluginGrasshopper
{
    public class ScaleObjectOperationComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public ScaleObjectOperationComponent() : base("Scale Animation Geometry", "AnimScaleOp", "Creates an operation to scale animation geometry", "Manakin", "Operation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("(Optional) Scale Origin", "RO", "Scale origin, will use center of geometry if unset", GH_ParamAccess.item);
            pManager[0].Optional = true;
            
            pManager.AddNumberParameter("X Scale Factors", "XSF", "X Scale Factors", GH_ParamAccess.list, new List<double>{1});
            pManager.AddNumberParameter("Y Scale Factors", "YSF", "Y Scale Factors", GH_ParamAccess.list, new List<double>{1});
            pManager.AddNumberParameter("Z Scale Factors", "ZSF", "Z Scale Factors", GH_ParamAccess.list, new List<double>{1});
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Animation Operation", "AO", "Animation Operation", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Variables to hold input data
            List<double> xFactors = new List<double>();
            List<double> yFactors = new List<double>();
            List<double> zFactors = new List<double>();
            Point3d scaleOrigin = Point3d.Unset;

            // Retrieve input data
            if (!DA.GetData(0, ref scaleOrigin));
            if (!DA.GetDataList(1, xFactors)) return;
            if (!DA.GetDataList(1, yFactors)) return;
            if (!DA.GetDataList(1, zFactors)) return;

            // Create the objects 
            var scaleOperation = new ScaleObjectOperation(scaleOrigin, xFactors, yFactors, zFactors);

            DA.SetData(0, scaleOperation);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("PluginGrasshopper_24.png");

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("0B94FE63-535B-48A9-A4A8-0BC68360AC14");
    }
}