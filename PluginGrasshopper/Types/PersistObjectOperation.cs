using System.Collections.Generic;
using System.Linq;
using Rhino.Collections;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class PersistObjectOperation : IObjectOperation
    {
        private int _frames;

        public int Frames
        {
            get => _frames;
            set => _frames = value;
        }


        public PersistObjectOperation(int frames)
        {
            _frames = frames;
        }

        public AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            return startingGeometry;
        }

        public int NumberOfOperations
        {
            get => Frames;
        }
    }
}