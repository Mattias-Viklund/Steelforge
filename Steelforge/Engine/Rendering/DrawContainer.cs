using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Rendering
{
    public class DrawContainer
    {
        private Drawable[] drawables;
        
        public DrawContainer(Drawable[] drawables)
        {
            this.drawables = drawables;

        }

        public void Draw(RenderWindow window)
        {
            foreach (Drawable d in drawables)
            {
                window.Draw(d);

            }
        }
    }
}
