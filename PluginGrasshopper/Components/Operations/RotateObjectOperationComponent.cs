using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Manakin.PluginGrasshopper
{
    public class RotateObjectOperationComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public RotateObjectOperationComponent() : base("Rotate Animation Geometry", "AnimRotateOp", "Creates an operation to rotate animation geometry", "Manakin", "Operation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Rotation Angles (Degrees)", "RA", "Rotation Angles for the scene", GH_ParamAccess.list);
            pManager.AddPointParameter("(Optional) Rotation Origin", "RO", "Rotation origin, will use center of geometry if unset", GH_ParamAccess.item);
            pManager.AddVectorParameter("(Optional) Rotation Axis", "RA", "Rotation axis, will use Z-axis if unset", GH_ParamAccess.item);
            pManager[1].Optional = true;
            pManager[2].Optional = true;
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
            List<double> angles = new List<double>();
            Point3d rotOrigin = Point3d.Unset;
            Vector3d rotAxis = Vector3d.Unset;

            // Retrieve input data
            if (!DA.GetDataList(0, angles)) return;
            if (!DA.GetData(1, ref rotOrigin));
            if (!DA.GetData(2, ref rotAxis));

            // Create the objects 
            var rotateOperation = new RotateObjectOperation(angles, rotAxis, rotOrigin);

            DA.SetData(0, rotateOperation);
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
        public override Guid ComponentGuid => new Guid("9B1D6700-8488-45E0-BA01-1FB9D3639D07");
    }
}