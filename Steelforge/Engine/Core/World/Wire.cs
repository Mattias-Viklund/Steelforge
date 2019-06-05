using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Core.World
{
    public struct Wire
    {
        public Vector3f start;
        public Vector3f end;

        public Wire(Vector3f start, Vector3f end)
        {
            this.start = start;
            this.end = end;

        }
    }
}
