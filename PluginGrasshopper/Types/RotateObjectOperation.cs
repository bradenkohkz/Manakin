using System.Collections.Generic;
using Rhino.Collections;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class RotateObjectOperation : IObjectOperation
    {
        private Point3d _rotOrigin;

        private List<double> _angles;

        private Vector3d _rotAxis;

        public Vector3d RotAxis
        {
            get => _rotAxis;
            set => _rotAxis = value;
        }

        public Point3d RotOrigin
        {
            get => _rotOrigin;
            set => _rotOrigin = value;
        }

        public List<double> Angles
        {
            get => _angles;
            set => _angles = value;
        }

        public RotateObjectOperation(List<double> angles, Vector3d rotAxis, Point3d rotOrigin)
        {
            _rotOrigin = rotOrigin;
            _angles = angles;
            _rotAxis = rotAxis;
        }


        public AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            var cloneGeometry = startingGeometry.Geometry.Duplicate();
            var rotCenter = RotOrigin == Point3d.Unset ? startingGeometry.Geometry.GetBoundingBox(Plane.WorldXY).Center : RotOrigin;
            var rotAngle = Angles[frameNumber];
            var rotAxis = _rotAxis == Vector3d.Unset ? Vector3d.ZAxis : _rotAxis;
            
            cloneGeometry.Transform(Transform.Rotation(Rhino.RhinoMath.ToRadians(rotAngle), rotAxis, rotCenter));
            
            return new AnimationGeometry(cloneGeometry, startingGeometry.MaterialName,
                startingGeometry.MaterialTransparency);
        }

        public int NumberOfOperations { get => _angles.Count; }
    }
}