using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Types
{
    public class DoubleBarycenterParameter : GH_Param<GH_Barycenter<double>>
    {
        public DoubleBarycenterParameter() : base("DB", "Dgb", "", "SB", "SB", GH_ParamAccess.item)
        {
        }

        public override Guid ComponentGuid => Guid.Parse("68c69326-1ea2-47bc-b29f-2e77f105263c");
    }
}
