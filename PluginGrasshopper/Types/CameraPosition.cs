using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class CameraPosition
    {
        private Point3d _location;
        private Point3d _target;

        public Point3d Location
        {
            get => _location;
            set => _location = value;
        }

        public Point3d Target
        {
            get => _target;
            set => _target = value;
        }

        public CameraPosition(Point3d location, Point3d target)
        {
            _location = location;
            _target = target;
        }
    }
}