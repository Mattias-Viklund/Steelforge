using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Core
{
    public abstract class GameDrawable : Drawable
    {
        public virtual void DrawTexture(RenderTexture texture, RenderStates states)
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderTexture)
                DrawTexture((target as RenderTexture), states);

        }
    }

    public class GameRenderable : GameDrawable
    {
        private Drawable d;

        public GameRenderable(Drawable d)
        {
            this.d = d;

        }

        public override void DrawTexture(RenderTexture texture, RenderStates states)
        {
            texture.Draw(d);

        }
    }
}
