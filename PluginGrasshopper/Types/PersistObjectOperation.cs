using System.Collections.Generic;
using System.Linq;
using Rhino.Collections;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class PersistObjectOperation : BaseOperation
    {
        private int _frames;

        public int Frames
        {
            get => _frames;
            set => _frames = value;
        }


        public PersistObjectOperation(int frames): base("Persist", "Leaves geometry in the scene")
        {
            _frames = frames;
        }

        public override BaseOperation DuplicateOperation()
        {
            return new PersistObjectOperation(this.Frames);
        }

        public override AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            return startingGeometry;
        }

        public override int NumberOfOperations
        {
            get => Frames;
        }
    }
}