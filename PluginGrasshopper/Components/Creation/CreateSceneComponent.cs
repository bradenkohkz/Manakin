using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Manakin.PluginGrasshopper
{
    public class CreateSceneComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CreateSceneComponent() : base("Create Scene", "AnimCreateScene", "Creates a scene to be 'rendered' later", "Manakin", "Creation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Starting Frame", "SF", "Starting Frame for the Animation Geometry",
                GH_ParamAccess.item);
            pManager.AddGenericParameter("Animation Geometry", "AG", "Animation Geometry", GH_ParamAccess.item);
            pManager.AddGenericParameter("Animation Operation", "AO", "Animation Operation", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Persist", "P", "Persist Geometry after operation", GH_ParamAccess.item, true);
            pManager[3].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Animation Scene", "FO", "Animation Scene", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Variables to hold input data
            int startingFrame = 0;
            AnimationGeometry animGeom = null;
            IObjectOperation animOp = null;
            bool persistAfterOperation = true;

            // Retrieve input data
            if (!DA.GetData(0, ref startingFrame)) return;
            if (!DA.GetData(1, ref animGeom)) return;
            if (!DA.GetData(2, ref animOp));
            if (!DA.GetData(3, ref persistAfterOperation));
          
            // Create the Frames
            var scene = new Scene(startingFrame, animGeom, animOp, persistAfterOperation);

            DA.SetData(0, scene);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Create Scene_24.png");

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("372F98A6-3CAB-4750-86F0-1E816FB2BCAD");
    }
}