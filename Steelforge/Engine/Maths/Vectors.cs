using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Maths
{
    public class Vectors
    {
        public static float Distance(Vector2f p1, Vector2f p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            return (float)Math.Sqrt(dx * dx + dy * dy);

        }

        public static Vector3f Relative(Vector3f left, float dx, float dy, float dz)
        {
            return new Vector3f(left.X + dx, left.Y + dy, left.Z + dz);

        }
    }
}
