using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceNoise
{
    public class ChoiceNoiseInfo : Grasshopper.Kernel.GH_AssemblyInfo
    {
        public override string Version => "0.1.0";

        public override string Name => "ChoiceNoise";

        //public override Bitmap Icon => null;

        public override string Description => "A library for picking and choosing consistent weight values from sets.";

        public override Guid Id => new Guid("3b857073-cded-4e41-bfc8-dbfb9bc383c6");

        public override string AuthorName => "Chris Welch";

        public override string AuthorContact => "";

    }
}
