using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Misc
{
    class DebugUtils : Drawable
    {
        private List<Drawable> drawables = new List<Drawable>();

        private Font font;
        private Text fpsCounter;
        private StringBuilder builder = new StringBuilder();

        public DebugUtils(Font font)
        {
            this.font = font;

            this.builder.Append("FPS: 0");
            this.fpsCounter = new Text(builder.ToString(), font, 24);
            this.fpsCounter.Position = new Vector2f(20, 20);

            this.drawables.Add(fpsCounter);

        }

        public int AddNewDebugTool(Drawable drawable)
        {
            this.drawables.Add(drawable);
            return drawables.Count - 1;

        }

        public int ReplaceToolAt(int index, Drawable drawable)
        {
            this.drawables.RemoveAt(index);
            return AddNewDebugTool(drawable);

        }

        public void UpdateFPS(Time time)
        {
            if (time.AsMilliseconds() != 0)
            {
                builder.Clear();
                builder.Append("FPS: " + (1000000L / time.AsMicroseconds()));
                this.fpsCounter.DisplayedString = builder.ToString();

            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                foreach (Drawable d in drawables)
                {
                    (target as RenderWindow).Draw(d);

                }
            }
        }
    }
}
