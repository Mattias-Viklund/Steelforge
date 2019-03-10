using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class Grid : Drawable
    {
        private Vector2f offset = new Vector2f();
        private float zoom = 1;

        private float baseLength = 100.0f;
        private float baseSize = 20.0f;

        public Grid(float baseLength, float baseSize)
        {
            this.baseLength = baseLength;

        }

        public void Move(Vector2f offset)
        {
            this.offset += offset;

        }

        public void Zoom(float factor)
        {
            zoom += factor;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                RenderWindow window = (target as RenderWindow);

                float zoomLength = zoom * baseLength;
                float zoomSize = zoom * baseSize;

                float drawablePointsX = window.Size.X / zoomLength;
                float drawablePointsY = window.Size.Y / zoomLength;

                float remainderX = drawablePointsX - (int)drawablePointsX;
                float remainderY = drawablePointsY - (int)drawablePointsY;

                Vector2f newOffset = offset;
                newOffset.X += zoomLength * remainderX;
                newOffset.Y += zoomLength * remainderY;

                for (int x = 0; x < (int)drawablePointsX+1; x++)
                {
                    for (int y = 0; y < (int)drawablePointsY+1; y++)
                    {
                        Vector2f position = new Vector2f(newOffset.X + zoomLength * x - zoomSize / 2, newOffset.Y + zoomLength * y - zoomSize / 2);
                        Vector2f size = new Vector2f(zoomSize, zoomSize);

                        RectangleShape rect = new RectangleShape(size);
                        rect.Position = position;

                        window.Draw(rect);

                    }
                }
            }
        }

        public void Highlight(RenderWindow window, Vector2f mousePosition)
        {
            float zoomLength = zoom * baseLength;
            float zoomSize = zoom * baseSize;

            float drawablePointsX = window.Size.X / zoomLength;
            float drawablePointsY = window.Size.Y / zoomLength;

            float remainderX = drawablePointsX - (int)drawablePointsX;
            float remainderY = drawablePointsY - (int)drawablePointsY;

            Vector2f newOffset = offset;
            newOffset.X -= zoomLength * remainderX;
            newOffset.Y -= zoomLength * remainderY;

            

            bool found = false;
            for (int x = 0; x < (int)drawablePointsX + 1; x++)
            {
                for (int y = 0; y < (int)drawablePointsY + 1; y++)
                {
                    Vector2f position = new Vector2f(newOffset.X + zoomLength * x - zoomSize / 2, newOffset.Y + zoomLength * y - zoomSize / 2);



                    if (found)
                    {
                        Vector2f size = new Vector2f(zoomSize, zoomSize);

                        RectangleShape rect = new RectangleShape(size);
                        rect.Position = position;
                        rect.FillColor = Color.Yellow;

                        window.Draw(rect);

                    }
                }
            }
        }
    }
}
