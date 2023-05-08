using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Types
{
    public class GH_CrossSectionSet : GH_Goo<Dictionary<string, LightProfiles.Profile>>
    {
        public override bool IsValid => true;

        public override string TypeName => "CrossSectionSet";

        public override string TypeDescription => "A set of cross sections";

        public override IGH_Goo Duplicate()
        {
            return new GH_CrossSectionSet()
            {
                Value = Value.Select(x => new LightProfiles.Profile(x.Value.Name,x.Value.GetPoints())).ToDictionary(x => x.Name, x => x)
            };
        }

        public override string ToString() => $"{{{Value.Count} Set(s)}}";
    }
}
