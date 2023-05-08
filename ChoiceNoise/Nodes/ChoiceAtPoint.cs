using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Nodes
{
    public class ChoiceAtPoint : GH_Component
    {
        public ChoiceAtPoint() : base(nameof(ChoiceAtPoint),
                                      "CP",
                                      "",
                                      "SB",
                                      "AB")
        {
        }

        public override Guid ComponentGuid => Guid.Parse("fa5d26de-5837-4de5-bac6-c36090fe9c0f");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points","P","Points to sample", GH_ParamAccess.list);
            pManager.AddVectorParameter("Seed", "S", "Seed to sample with", GH_ParamAccess.item);
            pManager.AddParameter(new Types.WeightParameter(),"CS", "CS", "", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Types.StringBarycenterParameter(), "B", "V", "", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var points = new List<GH_Point>();
            DA.GetDataList(0, points);

            GH_Vector seed = null;
            DA.GetData(1, ref seed);

            Types.GH_WeightSet weights = null;
            DA.GetData(2, ref weights);

            var random = new SimplexNoise.NoiseGrid((int)seed.Value.X, (int)seed.Value.Y, (int)seed.Value.Z, 1);

            DA.SetDataList(0, points
                .Select(x => random.WeightedBarycenterAtPoint(x.Value.X, x.Value.Y))
                .Select(x => new Types.GH_Barycenter<string>() { Value = new SimplexNoise.WeightedBarycenter<string>(
                    x.ABC,
                    weights.PullNormalisedSample(x.U),
                    weights.PullNormalisedSample(x.V),
                    weights.PullNormalisedSample(x.W)) }));
        }
    }
}
