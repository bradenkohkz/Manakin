using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class Scene
    {
        private int _startingFrame;
        
        private AnimationGeometry _animationGeometry;

        private IObjectOperation _operation;

        private bool _persistAfterOperation;

        public bool PersistAfterOperation
        {
            get => _persistAfterOperation;
            set => _persistAfterOperation = value;
        }

        public int StartingFrame
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
        
        public Scene(int startingFrame, AnimationGeometry animationGeometry, IObjectOperation operation, bool persistAfterOperation = true)
        {
            _startingFrame = startingFrame;
            _animationGeometry = animationGeometry;
            _operation = operation;
            _persistAfterOperation = persistAfterOperation;
        }
    }
}