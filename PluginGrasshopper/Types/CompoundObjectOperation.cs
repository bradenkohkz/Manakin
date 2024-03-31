using System.Collections.Generic;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class CompoundObjectOperation: IObjectOperation
    {
        private List<IObjectOperation> _operations;

        public List<IObjectOperation> Operations
        {
            get => _operations;
            set => _operations = value;
        }

        public CompoundObjectOperation(List<IObjectOperation> operations)
        {
            _operations = operations;
        }


        public AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            AnimationGeometry operatedGeometry = startingGeometry;
            foreach (var objectOperation in Operations)
            {
                operatedGeometry = objectOperation.GenerateGeometry(operatedGeometry, frameNumber);
            }

            return operatedGeometry;
        }

        public int NumberOfOperations
        {
            get => Operations[0].NumberOfOperations;
        }
    }
}