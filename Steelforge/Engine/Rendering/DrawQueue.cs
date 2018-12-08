using SFML.Graphics;

namespace Steelforge.Rendering
{
    public class DrawQueue : Drawable
    {
        private Drawable[] drawables;
        private int maxItems;

        private int items = 0;

        // Drawable is anything that can be drawn by a RenderWindow.
        // This creates a static array that can be filled with drawables.
        public DrawQueue(int maxItems)
        {
            drawables = new Drawable[maxItems];
            this.maxItems = maxItems;

        }

        // When we clear we just reset the position to iterate from
        public void Clear()
        {
            items = 0;

        }

        // Interface Draw function, passes (hopefully) a RenderWindow as a target.
        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                for (int i = 0; i < items; i++)
                {
                    if (items == maxItems - 1)
                        break;

                    // Draw all items in the queue;
                    (target as RenderWindow).Draw(drawables[i]);

                }
            }
        }

        // Returns the success of the operation.
        public bool Add(Drawable d)
        {
            if (items == maxItems)
                return false;

            drawables[items] = d;
            items++;

            return true;

        }
    }
}
