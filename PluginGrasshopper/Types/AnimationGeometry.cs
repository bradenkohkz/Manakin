using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class AnimationGeometry
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
    }
}