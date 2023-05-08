using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise.Types
{
    public class GH_WeightSet : GH_Goo<Dictionary<string,double>>
    {
        public override bool IsValid => true;

        public override string TypeName => "Weight";

        public override string TypeDescription => "A weight";

        public override IGH_Goo Duplicate()
        {
            return new GH_WeightSet()
            {
                Value = new Dictionary<string, double>(Value)
            };
        }

        public override string ToString() => $"{{{Value.Count} Weight(s)}}";

        private double max = 0;

        private bool needsSetting = true;

        private void Set()
        {
            Value.ToList().ForEach(x => max += x.Value);
            max *= 0.5;
            needsSetting = false;
        }

        public string PullNormalisedSample(double sample)
        {
            if (needsSetting) Set();

            sample += 1;
            sample *= max;

            var range = 0.0;

            foreach (var item in Value)
            {
                range += item.Value;

                if (sample <= range) return item.Key;
            }

            throw new NotImplementedException();
        }
    }
}
