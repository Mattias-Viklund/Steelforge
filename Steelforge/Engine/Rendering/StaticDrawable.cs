using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Rendering
{
    public class StaticDrawable : Drawable
    {
        private bool Enabled
        {
            get;
            set;

        }

        private Drawable drawable;

        public StaticDrawable(Drawable drawable, bool enabled)
        {
            this.Enabled = enabled;
            this.drawable = drawable;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (Enabled)
            {
                if (target is RenderWindow)
                {
                    (target as RenderWindow).Draw(drawable);

                }
            }
        }
    }
}
