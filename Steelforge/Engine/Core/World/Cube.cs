using SFML.System;
using Steelforge.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Core.World
{
    public struct Cube
    {
        public Wire[] Wires;

        public Cube(Vector3f pos, float size)
        {
            Wires = new Wire[12];
            Wires[0] = new Wire(Vectors.Relative(pos, size / 2, size / 2, size / 2),    Vectors.Relative(pos, -size / 2, size / 2, size / 2));
            Wires[1] = new Wire(Vectors.Relative(pos, size / 2, -size / 2, size / 2),   Vectors.Relative(pos, -size / 2, -size / 2, size / 2));
            Wires[2] = new Wire(Vectors.Relative(pos, size / 2, size / 2, size / 2),    Vectors.Relative(pos, size / 2, -size / 2, size / 2));
            Wires[3] = new Wire(Vectors.Relative(pos, -size / 2, size / 2, size / 2),   Vectors.Relative(pos, -size / 2, -size / 2, size / 2));
            Wires[4] = new Wire(Vectors.Relative(pos, size / 2, size / 2, -size / 2),   Vectors.Relative(pos, -size / 2, size / 2, -size / 2));
            Wires[5] = new Wire(Vectors.Relative(pos, size / 2, -size / 2, -size / 2),  Vectors.Relative(pos, -size / 2, -size / 2, -size / 2));
            Wires[6] = new Wire(Vectors.Relative(pos, size / 2, size / 2, -size / 2),   Vectors.Relative(pos, size / 2, -size / 2, -size / 2));
            Wires[7] = new Wire(Vectors.Relative(pos, -size / 2, size / 2, -size / 2),  Vectors.Relative(pos, -size / 2, -size / 2, -size / 2));
            Wires[8] = new Wire(Vectors.Relative(pos, size / 2, size / 2, size / 2),    Vectors.Relative(pos, size / 2, size / 2, -size / 2));
            Wires[9] = new Wire(Vectors.Relative(pos, size / 2, -size / 2, size / 2),   Vectors.Relative(pos, size / 2, -size / 2, -size / 2));
            Wires[10] = new Wire(Vectors.Relative(pos, -size / 2, -size / 2, size / 2), Vectors.Relative(pos, -size / 2, -size / 2, -size / 2));
            Wires[11] = new Wire(Vectors.Relative(pos, -size / 2, size / 2, size / 2),  Vectors.Relative(pos, -size / 2, size / 2, -size / 2));

        }
    }
}
