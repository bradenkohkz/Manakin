using System.Collections.Generic;
using System.Linq;
using Rhino.Collections;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class ScaleObjectOperation : IObjectOperation
    {
        private Point3d _scaleOrigin;

        private List<double> _xfactors;
        private List<double> _yfactors;
        private List<double> _zfactors;

        public List<double> Xfactors
        {
            get => _xfactors;
            set => _xfactors = value;
        }

        public List<double> Yfactors
        {
            get => _yfactors;
            set => _yfactors = value;
        }

        public List<double> Zfactors
        {
            get => _zfactors;
            set => _zfactors = value;
        }


        public Point3d ScaleOrigin
        {
            get => _scaleOrigin;
            set => _scaleOrigin = value;
        }


        public ScaleObjectOperation(Point3d scaleOrigin, List<double> xfactors, List<double> yfactors, List<double> zfactors)
        {
            _scaleOrigin = scaleOrigin;
            _xfactors = xfactors;
            _yfactors = yfactors;
            _zfactors = zfactors;
        }

        private double GetScaleFactor(List<double> factors, int frameNumber)
        {
            if (factors.Count > 0)
            {
                return factors[frameNumber];
            }
            else
            {
                return factors[0];
            }
        }

        public AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            var cloneGeometry = startingGeometry.Geometry.Duplicate();
            var scaleCenter = ScaleOrigin == Point3d.Unset ? startingGeometry.Geometry.GetBoundingBox(Plane.WorldXY).PointAt(0.5,0.5,0): ScaleOrigin;
            var xFactor = GetScaleFactor(Xfactors, frameNumber);
            var yFactor = GetScaleFactor(Yfactors, frameNumber);
            var zFactor = GetScaleFactor(Zfactors, frameNumber);

            var scalePlane = new Plane(scaleCenter, Vector3d.ZAxis); 
            cloneGeometry.Transform(Transform.Scale(scalePlane, xFactor, yFactor, zFactor));
            
            return new AnimationGeometry(cloneGeometry, startingGeometry.MaterialName,
                startingGeometry.MaterialTransparency);
        }

        public int NumberOfOperations
        {
            get => new[] { Xfactors.Count, Yfactors.Count, Zfactors.Count }.Max();
        }
    }
}