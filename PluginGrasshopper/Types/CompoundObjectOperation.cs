using System.Collections.Generic;
using GH_IO.Serialization;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class CompoundObjectOperation: BaseOperation
    {
        private List<BaseOperation> _operations;

        public List<BaseOperation> Operations
        {
            get => _operations;
            set => _operations = value;
        }

        public CompoundObjectOperation(List<BaseOperation> operations): base("Compound", "Compounds multiple operations together")
        {
            _operations = operations;
        }

        public override BaseOperation DuplicateOperation()
        {
            return new CompoundObjectOperation(this.Operations);
        }

        public override AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            AnimationGeometry operatedGeometry = startingGeometry;
            foreach (var objectOperation in Operations)
            {
                operatedGeometry = objectOperation.GenerateGeometry(operatedGeometry, frameNumber);
            }

            return operatedGeometry;
        }

        public override int NumberOfOperations
        {
            get => Operations[0].NumberOfOperations;
        }

    }
}