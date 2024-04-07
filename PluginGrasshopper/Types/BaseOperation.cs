using System;
using GH_IO.Serialization;
using Grasshopper.Kernel.Types;

namespace Manakin.PluginGrasshopper
{
    public abstract class BaseOperation : IGH_Goo
    {
        private string _operationName;
        private string _operationDescription;
        public abstract BaseOperation DuplicateOperation();
        public abstract AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber);
        public abstract int NumberOfOperations { get; }

        
        public BaseOperation(string operationName, string operationDescription)
        {
            _operationName = operationName;
            _operationDescription = operationDescription;
        }

        public bool Write(GH_IWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public bool Read(GH_IReader reader)
        {
            throw new System.NotImplementedException();
        }

        public IGH_Goo Duplicate()
        {
            return DuplicateOperation();
        }

        public IGH_GooProxy EmitProxy()
        {
            throw new System.NotImplementedException();
        }

        public bool CastFrom(object source)
        {
            throw new System.NotImplementedException();
        }

        public bool CastTo<T>(out T target)
        {
            throw new System.NotImplementedException();
        }

        public object ScriptVariable()
        {
            throw new System.NotImplementedException();
        }

        public bool IsValid => true;
        public string IsValidWhyNot => "";
        public string TypeName => _operationName;
        public string TypeDescription => _operationDescription;
    }
}