using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Objects
{
    public class Placeholder : GameObject
    {
        private Drawable drawable;

        public Placeholder(Drawable drawable)
        {
            this.drawable = drawable;

        }

        public override void Draw(RenderWindow window, RenderStates states)
        {
            window.Draw(drawable);

        }

        public static GameObject FromDrawable(Drawable drawable)
        {
            return new Placeholder(drawable);

        }
    }
}
