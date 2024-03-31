using System.Collections.Generic;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class AnimationCamera
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

        public AnimationCamera(List<Point3d> locations, List<Point3d> targets)
        {
            _locations = locations;
            _targets = targets;
        }
    }
}