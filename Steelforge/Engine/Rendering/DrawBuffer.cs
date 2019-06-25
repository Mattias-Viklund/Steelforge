using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using System;

namespace Steelforge.Rendering
{
    public class DrawBuffer
    {
        private GameDrawable[] drawables;

        private int maxItems;
        private int items = 0;

        // Drawable is anything that can be drawn by a RenderWindow.
        // This creates a static array that can be filled with drawables.
        public DrawBuffer(int maxItems)
        {
            drawables = new GameDrawable[maxItems];
            this.maxItems = maxItems;

        }

        // When we clear we just reset the position to iterate from
        public void Clear()
        {
            items = 0;

        }

        public int GetItems()
        {
            return items;

        }

        // Interface Draw function, passes (hopefully) a RenderWindow as a target.
        public void Draw(RenderTexture texture)
        {
            RenderStates state = RenderStates.Default;

            for (int i = 0; i < items; i++)
            {

                texture.Draw(drawables[i]);

            }
        }

        // Returns the success of the operation.
        public int Add(GameDrawable d)
        {
            if (items == maxItems)
                return -1;

            drawables[items] = d;
            items++;

            return items;

        }
    }
}
