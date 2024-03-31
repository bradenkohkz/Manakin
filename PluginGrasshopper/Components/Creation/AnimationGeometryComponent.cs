using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace Manakin.PluginGrasshopper
{
    public class AnimationGeometryComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public AnimationGeometryComponent() : base("Animation Geometry", "AnimGeom", "Creates an Animation Geometry object to be used and displayed later", "Manakin", "Creation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "G", "Input geometry for animation", GH_ParamAccess.item);
            pManager.AddTextParameter("Material Name", "MN", "Name of the material for the geometry", GH_ParamAccess.item);
            pManager.AddNumberParameter("Transparency (0 To 1)", "T", "(Optional) Transparency for the material, default is 1", GH_ParamAccess.item);
            pManager[2].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Animation Geometry", "AM", "Animation Geometry", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Variables to hold input data
            GeometryBase inputGeometry = null;
            string inputMaterialName = "";
            double transparency = 1.0;

            // Retrieve input data
            if (!DA.GetData(0, ref inputGeometry)) return;
            if (!DA.GetData(1, ref inputMaterialName)) return;
            if (!DA.GetData(2, ref transparency));
            
            // Create the objects 
            var animGeom = new AnimationGeometry(inputGeometry, inputMaterialName, transparency);

            DA.SetData(0, animGeom);
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
        public override Guid ComponentGuid => new Guid("AB80F475-40DE-43AC-9243-BB9FAA18FA1C");
    }
}