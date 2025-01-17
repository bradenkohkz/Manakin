using System.Collections.Generic;
using Rhino.Geometry;

namespace Manakin.PluginGrasshopper
{
    public class LoftObjectOperation : BaseOperation
    {
        private List<Curve> _sections;

        public List<Curve> Sections
        {
            get => _sections;
            set => _sections = value;
        }

        public LoftObjectOperation(List<Curve> sections): base("Loft", "Animates the lofting of sections")
        {
            _sections = sections;
        }

        public override BaseOperation DuplicateOperation()
        {
            return new LoftObjectOperation(this.Sections);
        }

        public override AnimationGeometry GenerateGeometry(AnimationGeometry startingGeometry, int frameNumber)
        {
            var loftSections = new List<Curve>();
            for (int i = 0; i <= frameNumber; i++)
            {
                loftSections.Add(Sections[i]);
            }

            GeometryBase cloneGeometry = null;
                var tol = Rhino.RhinoDoc.ActiveDoc.ModelAbsoluteTolerance;
            if (frameNumber == 0)
            {
                cloneGeometry = Brep.CreatePlanarBreps(Sections[0],tol )[0].CapPlanarHoles(tol);
            }
            else
            {
                cloneGeometry = Brep.CreateFromLoft(loftSections, Point3d.Unset, Point3d.Unset, LoftType.Tight, false)[0].CapPlanarHoles(tol);
            }


            return new AnimationGeometry(cloneGeometry, startingGeometry.MaterialName,
                startingGeometry.MaterialTransparency);
        }

        public override int NumberOfOperations
        {
            get => Sections.Count;
        }
    }
}