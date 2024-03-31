using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Manakin.PluginGrasshopper
{
    public class MoveObjectOperationComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public MoveObjectOperationComponent() : base("Move Animation Geometry", "AnimMoveOp", "Creates an operation to move animation geometry along a rail", "Manakin", "Operation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Rail", "G", "Rail curve to move animation geometry", GH_ParamAccess.item);
            pManager.AddNumberParameter("Rail Parameters", "T", "Rail curve parameters to move animation geometry", GH_ParamAccess.list);
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
            Curve railCurve = null;
            List<double> railParameters = new List<double>();

            // Retrieve input data
            if (!DA.GetData(0, ref railCurve)) return;
            if (!DA.GetDataList(1, railParameters)) return;

            // Create the objects 
            var moveOperation = new MoveObjectOperation(railCurve, railParameters);

            DA.SetData(0, moveOperation);
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
        public override Guid ComponentGuid => new Guid("1224A7F5-D598-4E5E-820D-60555B85A5C8");
    }
}