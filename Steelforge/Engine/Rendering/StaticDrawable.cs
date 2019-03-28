using SFML.Graphics;
using Steelforge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Rendering
{
    public class StaticDrawable : GameDrawable
    {
        private bool Enabled
        {
            get;
            set;

        }

        private GameDrawable drawable;

        public StaticDrawable(GameDrawable drawable, bool enabled)
        {
            this.Enabled = enabled;
            this.drawable = drawable;

        }

        public override void DrawTexture(RenderTexture texture, RenderStates states)
        {
            if (Enabled)
            {
                texture.Draw(drawable);

            }
        }
    }
}
