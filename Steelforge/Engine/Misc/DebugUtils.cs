using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Engine.Misc
{
    class DebugUtils : Drawable
    {
        private List<Drawable> drawables = new List<Drawable>();

        private Font font;
        private Text fpsCounter;

        public DebugUtils(string fontPath)
        {
            this.font = new Font(fontPath);
            this.fpsCounter = new Text("FPS: ", font, 24);
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

        public void UpdateFPS(long frames, Time time)
        {
            if (time.AsMilliseconds() != 0)
                this.fpsCounter.DisplayedString = "FPS: " + (1000000l / (time.AsMicroseconds()));

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
