using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Types
{
    public class WeightParameter : GH_Param<GH_WeightSet>
    {
        public WeightParameter() : base("WG", "WG", "", "SB", "SB", GH_ParamAccess.item)
        {
        }

        public override Guid ComponentGuid => Guid.Parse("d07a5dbe-098d-4958-bace-f049894977bc");
    }
}
