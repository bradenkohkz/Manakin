using System.Collections.Generic;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class MoveObjectOperation : IObjectOperation
    {
        private Curve _rail;

        private List<double> _parameters;

        public Curve Rail
        {
            get => _rail;
            set => _rail = value;
        }

        public List<double> Parameters
        {
            get => _parameters;
            set => _parameters = value;
        }

        public MoveObjectOperation(Curve rail, List<double> parameters)
        {
            _rail = rail;
            _parameters = parameters;
        }

        public AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            var cloneGeometry = startingGeometry.Geometry.Duplicate();
            var origin = Rail.PointAt(Parameters[0]);
            var moveVector = Rail.PointAt(Parameters[frameNumber]) - origin;
            cloneGeometry.Transform(Transform.Translation(moveVector));

            return new AnimationGeometry(cloneGeometry, startingGeometry.MaterialName,
                startingGeometry.MaterialTransparency);
        }

        public int NumberOfOperations
        {
            get => _parameters.Count;
        }
    }
}