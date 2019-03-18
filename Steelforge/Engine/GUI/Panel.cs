using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.GUI
{
    class Panel : Drawable
    {
        public enum PanelLayout
        {
            Stacking

        }

        private List<GUIDrawable> guiDrawables = new List<GUIDrawable>();
        private PanelLayout layout;
        private int margin;

        public Panel(int margin, PanelLayout layout = PanelLayout.Stacking)
        {
            this.layout = layout;
            this.margin = margin;

        }

        public void AddElement(GUIDrawable drawable)
        {
            guiDrawables.Add(drawable);

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                int maxX = 0;
                int maxY = 0;

                foreach (GUIDrawable drawable in guiDrawables)
                {


                }
            }
        }
    }
}
