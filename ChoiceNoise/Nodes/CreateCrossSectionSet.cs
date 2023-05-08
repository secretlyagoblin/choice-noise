using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Nodes
{
    internal class CreateCrossSectionSet : GH_Component
    {
        public CreateCrossSectionSet() : base(nameof(CreateCrossSectionSet),
                                      "CSS",
                                      "",
                                      "SB",
                                      "AB")
        {
        }


        public override Guid ComponentGuid => Guid.Parse("13002508-a949-4b8c-b114-8d2866c994ae");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Keys", "K", "", GH_ParamAccess.list);
            pManager.AddCurveParameter("Values", "V", "", GH_ParamAccess.list);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Types.WeightParameter(), "Set", "S", "", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<GH_String> strings = new List<GH_String>();
            List<GH_Curve> curves = new List<GH_Curve>();

            DA.GetDataList(0, strings);
            DA.GetDataList(1, curves);

            DA.SetData(0, new Types.GH_CrossSectionSet() {
                Value = strings
                    .Zip(curves, (s, n) => (s, n))
                    .ToDictionary(x => x.s.Value, x => new LightProfiles.Profile(x.s.Value, x.n.Value
                        .ToPolyline(0.1, 0.1, 0, 0)
                        .ToPolyline()
                        .Select(y => new LightProfiles.ProfilePoint((float)y.X, (float)y.Y))
                        )
                    )
            });
        }
    }
}
