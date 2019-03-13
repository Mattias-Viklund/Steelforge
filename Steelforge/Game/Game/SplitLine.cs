using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class SplitLine : Drawable
    {
        private int segments;
        private float totalWidth;

        private Color[] segmentColors;

        public SplitLine(int segments, float totalWidth)
        {
            this.segments = segments;
            this.totalWidth = totalWidth;
            segmentColors = new Color[segments];
            FillColors();

        }

        private void FillColors()
        {
            for (int i = 0; i < segments; i++)
            {
                SetColor(i, Color.White);

            }
        }

        public void SetColor(int index, Color color)
        {
            segmentColors[index] = color;

        }

        public void Increment()
        {
            Color tempColor = Color.White;

            for (int i = 0; i < segments; i++)
            {
                Color color = segmentColors[i];
                segmentColors[i] = tempColor;
                tempColor = color;

            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                RenderWindow window = (target as RenderWindow);

                float width = window.Size.X * totalWidth;
                float widthDifference = window.Size.X - width;

                float segmentWidth = width / segments;
                float segmentHeight = segmentWidth;

                Vector2f offset = new Vector2f(widthDifference / 2, (window.Size.Y / 2) - (segmentHeight / 2));

                for (int i = 0; i < segments; i++)
                {
                    RectangleShape rect = new RectangleShape(new Vector2f(segmentWidth, segmentHeight));
                    rect.FillColor = segmentColors[i];
                    rect.Position = offset;

                    window.Draw(rect);

                    offset += new Vector2f(segmentWidth, 0);

                }
            }
        }
    }
}
