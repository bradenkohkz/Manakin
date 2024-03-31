using System.Collections.Generic;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class FadeObjectOperation : IObjectOperation
    {
        private List<double> _transparencies;

        public List<double> Transparencies
        {
            get => _transparencies;
            set => _transparencies = value;
        }

        public FadeObjectOperation(List<double> transparencies)
        {
            _transparencies = transparencies;
        }

        public AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            var baseTransparency = startingGeometry.MaterialTransparency;

            return new AnimationGeometry(startingGeometry.Geometry, startingGeometry.MaterialName,baseTransparency * Transparencies[frameNumber]);
        }

        public int NumberOfOperations
        {
            get => _transparencies.Count;
        }
    }
}