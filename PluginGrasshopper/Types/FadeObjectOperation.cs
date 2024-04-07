using System.Collections.Generic;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class FadeObjectOperation : BaseOperation
    {
        private List<double> _transparencies;

        public List<double> Transparencies
        {
            get => _transparencies;
            set => _transparencies = value;
        }

        public FadeObjectOperation(List<double> transparencies): base("Fade", "Fades geometry")
        {
            _transparencies = transparencies;
        }

        public override BaseOperation DuplicateOperation()
        {
            return new FadeObjectOperation(this.Transparencies);
        }

        public override AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            var baseTransparency = startingGeometry.MaterialTransparency;

            return new AnimationGeometry(startingGeometry.Geometry, startingGeometry.MaterialName,baseTransparency * Transparencies[frameNumber]);
        }

        public override int NumberOfOperations
        {
            get => _transparencies.Count;
        }
    }
}