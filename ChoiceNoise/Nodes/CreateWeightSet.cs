using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Nodes
{
    internal class CreateWeightSet : GH_Component
    {
        public CreateWeightSet() : base(nameof(CreateWeightSet),
                              "CWS",
                              "",
                              "SB",
                              "AB")
        {
        }


        public override Guid ComponentGuid => Guid.Parse("402e36e4-773f-429a-b53f-889a0cc014ff");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Keys", "K", "", GH_ParamAccess.list);
            pManager.AddNumberParameter("Values", "V", "", GH_ParamAccess.list);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Types.WeightParameter(), "Set", "S", "", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<GH_String> strings = new List<GH_String>();
            List<GH_Number> numbers = new List<GH_Number>();

            DA.GetDataList(0, strings);
            DA.GetDataList(1, numbers);

            DA.SetData(0, new Types.GH_WeightSet() { 
                Value = strings
                    .Zip(numbers, (s, n) => (s, n))
                    .ToDictionary(x => x.s.Value, x => x.n.Value)});
        }
    }
}
