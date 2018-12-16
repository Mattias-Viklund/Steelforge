using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Objects.Physics
{
    public static class Collision
    {
        public static bool Intersects(FloatRect obj1, FloatRect obj2)
        {
            if (obj1.Left > (obj2.Left + obj2.Width) || obj2.Left > (obj1.Left + obj1.Width))
                return false;

            if (obj1.Top > (obj2.Top + obj2.Height) || obj2.Top > (obj1.Top + obj1.Height))
                return false;

            return true;

        }
    }
}
