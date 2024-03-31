using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public interface IObjectOperation
    {
        AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber);

        int NumberOfOperations { get; }
    }
}