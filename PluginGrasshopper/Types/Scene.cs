using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class Scene
    {
        private double _startingFrame;
        
        private AnimationGeometry _animationGeometry;

        private IObjectOperation _operation;

        public double StartingFrame
        {
            get => _startingFrame;
            set => _startingFrame = value;
        }

        public AnimationGeometry AnimationGeometry
        {
            get => _animationGeometry;
            set => _animationGeometry = value;
        }

        public IObjectOperation Operation
        {
            get => _operation;
            set => _operation = value;
        }
        
        public Scene(double startingFrame, AnimationGeometry animationGeometry, IObjectOperation operation)
        {
            _startingFrame = startingFrame;
            _animationGeometry = animationGeometry;
            _operation = operation;
        }
    }
}