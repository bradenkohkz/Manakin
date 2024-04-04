using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Manakin.PluginGrasshopper
{
    public class DeconstructAnimationGeometryComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public DeconstructAnimationGeometryComponent() : base("Deconstruct Animation Geometry", "AnimDeconGeom", "Deconstruct Animation Geometry for Render", "Manakin", "Animate")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Animation Geometry", "AG", "Animation Geometry", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGeometryParameter("Frame Geometry", "FG", "Geometry for the current frame", GH_ParamAccess.item);
            pManager.AddTextParameter("Material Name", "MN", "Material name for the geometry", GH_ParamAccess.item);
            pManager.AddNumberParameter("Material Transparency", "MT", "Transparency for material", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Variables to hold input data
            AnimationGeometry animationGeometry = null;

            // Retrieve input data
            if (!DA.GetData(0, ref animationGeometry)) return;

            DA.SetData(0, animationGeometry.Geometry);
            DA.SetData(1, animationGeometry.MaterialName);
            DA.SetData(2, animationGeometry.MaterialTransparency);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Deconstruct Geometry_24.png");

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("F20A467F-BFD2-4D25-AD19-9BCC487EEF69");
    }
}