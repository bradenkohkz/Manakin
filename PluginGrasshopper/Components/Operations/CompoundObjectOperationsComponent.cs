using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using Grasshopper.Kernel.Parameters;

namespace Manakin.PluginGrasshopper
{
    public class CompoundObjectOperationsComponent : GH_Component, IGH_VariableParameterComponent
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CompoundObjectOperationsComponent() : base("Compound Animation Operations", "AnimCompOp", "Compounds animation operations", "Manakin", "Operation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Operation 0", "AG 0", "Animation Operation 0", GH_ParamAccess.item);
            pManager.AddGenericParameter("Operation 1", "AG 1", "Animation Operation 1", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Animation Operation", "AO", "Animation Operation", GH_ParamAccess.item);
        }
        
        public bool CanInsertParameter(GH_ParameterSide side, int index)
        {
            // Allow input parameters to be inserted. You might want to limit the count or types here.
            return side == GH_ParameterSide.Input;
        }

        public bool CanRemoveParameter(GH_ParameterSide side, int index)
        {
            // Allow removal if there are more than one input parameters, as an example condition.
            return side == GH_ParameterSide.Input && Params.Input.Count > 1;
        }

        public IGH_Param CreateParameter(GH_ParameterSide side, int index)
        {
            // Create a new parameter. Here, as an example, we're adding a generic geometry parameter.
            var param = new Param_GenericObject();
            param.Name = $"Operation {index}";
            param.NickName = $"AG {index}";
            param.Description = $"Animation operation {index}";
            param.Access = GH_ParamAccess.item;
            param.Optional = true;
            return param;
        }

        public bool DestroyParameter(GH_ParameterSide side, int index)
        {
            // Allow the parameter to be destroyed.
            return side == GH_ParameterSide.Input;
        }

        public void VariableParameterMaintenance()
        {
            // Here you can manage the parameters, such as setting names, descriptions, etc., dynamically based on the state of your component.
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Loop through all the operations 
            var allOperations = new List<IObjectOperation>();
            for (int i = 0; i < Params.Input.Count; i++)
            {
                IObjectOperation inputData = null;
                if (DA.GetData(i, ref inputData))
                {
                    allOperations.Add(inputData);
                }
            }
            
            // Check if the frames match 
            var frames = allOperations[0].NumberOfOperations;

            foreach (var operation in allOperations)
            {
                if (operation.NumberOfOperations != frames)
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error,"The number of frames in all operations do not match");
                    return;
                }
            }

            // Create the objects 
            var compoundOperation = new CompoundObjectOperation(allOperations);

            DA.SetData(0, compoundOperation);
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
        public override Guid ComponentGuid => new Guid("F665C6A7-9B8D-40B3-B3FA-1B854230F7E4");

      
    }
}