using System.Collections.Generic;
using GH_IO.Serialization;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class AnimationCamera: IGH_Goo
    {
        private List<Point3d> _locations;
        private List<Point3d> _targets;

        public List<Point3d> Locations
        {
            get => _locations;
            set => _locations = value;
        }

        public List<Point3d> Targets
        {
            get => _targets;
            set => _targets = value;
        }

        public AnimationCamera()
        {
        }

        public AnimationCamera(List<Point3d> locations, List<Point3d> targets)
        {
            _locations = locations;
            _targets = targets;
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
            return new AnimationCamera(this.Locations, this.Targets);
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
        public string TypeName => "Animation Camera";
        public string TypeDescription => "Parameter for Animation Camera";
    }
}