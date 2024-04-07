using GH_IO.Serialization;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class AnimationGeometry: IGH_Goo
    {
        private GeometryBase _geometry;

        private string _materialName;

        private double _materialTransparency;

        public GeometryBase Geometry
        {
            get => _geometry;
            set => _geometry = value;
        }

        public string MaterialName
        {
            get => _materialName;
            set => _materialName = value;
        }

        public double MaterialTransparency
        {
            get => _materialTransparency;
            set => _materialTransparency = value;
        }

        public AnimationGeometry(GeometryBase geometry, string materialName, double materialTransparency = 1.0)
        {
            _geometry = geometry;
            _materialName = materialName;
            _materialTransparency = materialTransparency;
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
            return new AnimationGeometry(this.Geometry, this.MaterialName, this.MaterialTransparency);
        }

        public IGH_GooProxy EmitProxy()
        {
            throw new System.NotImplementedException();
        }

        public bool CastFrom(object source)
        {
            return false;
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
        public string TypeName => "Animation Geometry";
        public string TypeDescription => "Object to hold geometry and properties for animation";
    }
}