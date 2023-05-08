using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Types
{
    public class GH_Barycenter<T> : GH_Goo<SimplexNoise.WeightedBarycenter<T>>
    {
        public override bool IsValid => true;

        public override string TypeName => $"Barycenter ({typeof(T)})";

        public override string TypeDescription => "A Barycenter";

        public override IGH_Goo Duplicate()
        {
            return new GH_Barycenter<T>()
            {
                Value = new SimplexNoise.WeightedBarycenter<T>(Value.ABC, Value.U, Value.V, Value.W)
            };
        }

        public override string ToString() => Value.ToString();
    }
}
