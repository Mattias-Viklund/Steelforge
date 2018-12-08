using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Input
{
    class CustomCursor : Drawable
    {
        private RectangleShape rect;

        public CustomCursor(Vector2f size, Texture texture)
        {
            rect = new RectangleShape(size);
            rect.Texture = texture;

        }

        public void SetPosition(Vector2f position)
        {
            rect.Position = position;

        }

        public Vector2f GetSize()
        {
            return rect.Size;

        }

        public Vector2f GetCenter()
        {
            return rect.Size / 2;

        }

        public Vector2f GetPosition()
        {
            return rect.Position;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                (target as RenderWindow).Draw(rect);

            }
        }
    }
}
