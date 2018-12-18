using SFML.Graphics;
using SFML.System;
using System;

namespace Steelforge.Rendering
{
    public class DrawBuffer
    {
        private Drawable[] drawables;
        private Vector2f[] offsets;

        private int maxItems;
        private int items = 0;

        // Drawable is anything that can be drawn by a RenderWindow.
        // This creates a static array that can be filled with drawables.
        public DrawBuffer(int maxItems)
        {
            drawables = new Drawable[maxItems];
            offsets = new Vector2f[maxItems];
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
        public void Draw(RenderWindow window)
        {
            RenderStates state = RenderStates.Default;
            Vector2f offset = new Vector2f();

            for (int i = 0; i < items; i++)
            {
                offset = offsets[i];

                if (offset.X != 0 || offset.Y != 0)
                {
                    state.Transform.Translate(offset);
                    window.Draw(drawables[i], state);

                    state.Transform.Translate(-offset);

                }
                else
                    window.Draw(drawables[i]);

            }
        }

        // Returns the success of the operation.
        public int Add(Drawable d)
        {
            if (items == maxItems)
                return -1;

            drawables[items] = d;
            items++;

            return items;

        }

        // Returns the success of the operation.
        public int Add(Drawable d, Vector2f offset)
        {
            if (items == maxItems)
                return -1;

            drawables[items] = d;
            offsets[items] = offset;
            items++;

            return items;

        }
    }
}
