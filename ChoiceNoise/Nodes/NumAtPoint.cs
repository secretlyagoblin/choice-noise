using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Nodes
{
    public class NumAtPoint : GH_Component
    {
        public NumAtPoint() : base(nameof(NumAtPoint),
                      "NP",
                      "",
                      "SB",
                      "AB")
        {
        }

        public override Guid ComponentGuid => Guid.Parse("68c26340-317d-45fd-84a8-7e18e6c1ba65");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points","P","Points to sample", GH_ParamAccess.list);
            pManager.AddVectorParameter("Seed", "S", "Seed to sample with", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Types.DoubleBarycenterParameter(), "B", "V", "", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var points = new List<GH_Point>();
            DA.GetDataList(0, points);

            GH_Vector seed = null;
            DA.GetData(1, ref seed);

            var random = new SimplexNoise.NoiseGrid((int)seed.Value.X, (int)seed.Value.Y, (int)seed.Value.Z, 1);

            DA.SetDataList(0, points
                .Select(x => random.WeightedBarycenterAtPoint(x.Value.X, x.Value.Y))
                .Select(x => new Types.GH_Barycenter<double>() { Value = x }));
        }
    }
}
