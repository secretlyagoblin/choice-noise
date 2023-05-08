using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Types
{
    public class CrossSectionSetParameter : GH_Param<GH_CrossSectionSet>
    {
        public CrossSectionSetParameter() : base("CS", "CS", "", "SB", "SB", GH_ParamAccess.item)
        {
        }

        public override Guid ComponentGuid => Guid.Parse("f9843052-7ee0-48d1-83db-b6b899ff3d3f");
    }
}
