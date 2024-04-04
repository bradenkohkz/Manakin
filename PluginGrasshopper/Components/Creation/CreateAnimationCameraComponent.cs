using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Manakin.PluginGrasshopper
{
    public class CreateAnimationCameraComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CreateAnimationCameraComponent() : base("Create Animation Camera", "AnimCreateCam", "Creates the animation camera", "Manakin", "Creation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Camera Locations", "CL", "Camera Locations", GH_ParamAccess.list);
            pManager.AddPointParameter("Camera Targets", "CT", "Camera Targets", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Animation Camera", "SC", "Animation Camera", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Variables to hold input data
            List<Point3d> camLocations = new List<Point3d>();
            List<Point3d> camTargets = new List<Point3d>();

            // Retrieve input data
            if (!DA.GetDataList(0,camLocations)) return;
            if (!DA.GetDataList(1, camTargets)) return;

            // Create the Frames
            var sceneCam = new AnimationCamera(camLocations, camTargets);

            DA.SetData(0, sceneCam);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Create Animation Camera_24.png");

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("52CF6F64-0726-4786-82B1-6D8A0A29178E");
    }
}