using GH_IO.Serialization;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class Scene : IGH_Goo
    {
        private int _startingFrame;
        
        private AnimationGeometry _animationGeometry;

        private BaseOperation _operation;

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

        public BaseOperation Operation
        {
            get => _operation;
            set => _operation = value;
        }
        
        public Scene(int startingFrame, AnimationGeometry animationGeometry, BaseOperation operation, bool persistAfterOperation = true)
        {
            _startingFrame = startingFrame;
            _animationGeometry = animationGeometry;
            _operation = operation;
            _persistAfterOperation = persistAfterOperation;
        }

        public bool Write(GH_IWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public bool Read(GH_IReader reader)
        {
            throw new System.NotImplementedException();
        }

        public IGH_Goo Duplicate()
        {
            return new Scene(this.StartingFrame, this.AnimationGeometry, this.Operation, this.PersistAfterOperation);
        }

        public IGH_GooProxy EmitProxy()
        {
            throw new System.NotImplementedException();
        }

        public bool CastFrom(object source)
        {
            throw new System.NotImplementedException();
        }

        public bool CastTo<T>(out T target)
        {
            throw new System.NotImplementedException();
        }

        public object ScriptVariable()
        {
            throw new System.NotImplementedException();
        }

        public bool IsValid => true;
        public string IsValidWhyNot => "";
        public string TypeName => "Animation Scene";
        public string TypeDescription => "Holds information of the scene for render later";
    }
}