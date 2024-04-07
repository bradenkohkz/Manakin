using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manakin.PluginGrasshopper
{
    public class CreateAnimationFrameComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        /// <param name="animationCamera"></param>
        public CreateAnimationFrameComponent() : base("Create Animation Frame",
            "AnimCreateFrame", "Creates a frame based on all the scenes", "Manakin", "Animate")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Current Frame Number", "FN", "Current Frame Number", GH_ParamAccess.item);
            pManager.AddGenericParameter("Animation Scenes", "AS", "Animation Scenes", GH_ParamAccess.list);
            pManager.AddGenericParameter("Animation Camera", "AC", "Animation Camera", GH_ParamAccess.item);
            pManager[2].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Frame Objects", "FO", "Frame Objects", GH_ParamAccess.list);
            pManager.AddGenericParameter("Frame Camera", "FC", "Frame Camera", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Variables to hold input data
            int curFrameNumber = 0;
            List<Scene> animScenes = new List<Scene>();
            AnimationCamera animationCamera = null;

            // Retrieve input data
            if (!DA.GetData(0, ref curFrameNumber)) return;
            if (!DA.GetDataList(1, animScenes)) return;
            if (!DA.GetData(2, ref animationCamera)) ;

            var totalNumOfFrames = animScenes.Select(x => x.Operation.NumberOfOperations).Sum();

            if (animationCamera != null)
            {
                if (animationCamera.Locations.Count != 1 && totalNumOfFrames != animationCamera.Locations.Count)
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error,
                        "The number of frames in your objects and the camera don't match");
                    return;
                }
            }

            // Loop through the scenes and see which objects we need to "render" 
            List<AnimationGeometry> frameGeometry = new List<AnimationGeometry>();
            foreach (var animScene in animScenes)
            {
                var minSceneFrame = animScene.StartingFrame;
                var maxSceneFrame = minSceneFrame + animScene.Operation.NumberOfOperations - 1;

                if (curFrameNumber >= minSceneFrame && curFrameNumber <= maxSceneFrame)
                {
                    frameGeometry.Add(
                        animScene.Operation.GenerateGeometry(animScene.AnimationGeometry,
                            curFrameNumber - minSceneFrame));
                }

                if (curFrameNumber > maxSceneFrame && animScene.PersistAfterOperation)
                {
                    frameGeometry.Add(animScene.Operation.GenerateGeometry(animScene.AnimationGeometry,
                        animScene.Operation.NumberOfOperations - 1));
                }
            }
            
            DA.SetDataList(0, frameGeometry);

            if (animationCamera != null)
            {
                // Account for static camera
                var camLoc = animationCamera.Locations[0];
                var camTar = animationCamera.Targets[0];

                if (animationCamera.Locations.Count > 1)
                {
                    camLoc = animationCamera.Locations[curFrameNumber];
                }

                if (animationCamera.Targets.Count > 1)
                {
                    camTar = animationCamera.Targets[curFrameNumber];
                }

                DA.SetData(1,
                    new CameraPosition(camLoc, camTar));
            }

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("Create Animation Frame_24.png");

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("2DB78F26-3768-4DD3-8046-0DE49F080DA8");
    }
}