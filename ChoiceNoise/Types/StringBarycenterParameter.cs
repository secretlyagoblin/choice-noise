using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Types
{
    public class StringBarycenterParameter : GH_Param<GH_Barycenter<string>>
    {
        public StringBarycenterParameter() : base("StringB", "Sgb", "", "SB", "SB", GH_ParamAccess.item)
        {
        }

        public override Guid ComponentGuid => Guid.Parse("83c03088-215a-45cf-a4e6-58f57b31f4f2");
    }
}
