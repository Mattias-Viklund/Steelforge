using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class Square : Drawable
    {
        public static void Collide(ref Square[] squares)
        {
            for (int i = 0; i < squares.Length; i++)
            {
                int currentSquare = i;
                
                for (int j = i; j < squares.Length; j++)
                {
                    if (j == currentSquare)
                        continue;

                    if (squares[currentSquare].Collide(squares[j]))
                    {
                        squares[currentSquare].collided = true;
                        squares[j].collided = true;

                    }
                }
            }
        }

        private RectangleShape rect;
        private Vector2f position;
        private Color color;

        public bool collided = false;

        public Square(Vector2f size, Vector2f position)
            : this(size, position, Color.White)
        { }

        public Square(Vector2f size, Vector2f position, Color color)
        {
            rect = new RectangleShape(size);
            rect.FillColor = color;

            this.position = position;
            this.color = color;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                rect.Position = position;
                if (collided)
                    rect.FillColor = Color.Red;
                else
                    rect.FillColor = color;

                (target as RenderWindow).Draw(rect);

            }
        }

        public bool Collide(Square other)
        {
            Vector2f otherPosition = other.GetPosition();
            Vector2f otherSize = other.GetSize();

            if (position.X < otherPosition.X + otherSize.X &&
                position.X + rect.Size.X > otherPosition.X &&
                position.Y < otherPosition.Y + otherSize.Y &&
                position.Y + rect.Size.Y > otherPosition.Y)
            {
                return true;

            }

            return false;

        }

        public Vector2f GetPosition()
        {
            return position;

        }

        public Vector2f GetSize()
        {
            return rect.Size;

        }

        public void Move(Vector2f velocity)
        {
            position += velocity;

        }
    }
}
