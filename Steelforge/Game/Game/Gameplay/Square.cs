using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class CollisionInfo
    {
        private List<Square[]> collidedSquares;

        public CollisionInfo()
        {
            collidedSquares = new List<Square[]>();

        }

        public void AddPair(Square[] pair)
        {
            collidedSquares.Add(pair);

        }

        public bool HasCollisions()
        {
            return collidedSquares.Count > 0;

        }

        public List<Square[]> GetCollidedSquares()
        {
            return collidedSquares;

        }
    }

    class Square : GameDrawable
    {
        public static CollisionInfo Collide(ref Square[] squares)
        {
            CollisionInfo collisionInfo = new CollisionInfo();

            for (int i = 0; i < squares.Length; i++)
            {
                int currentSquare = i;

                for (int j = i; j < squares.Length; j++)
                {
                    if (j == currentSquare)
                        continue;

                    if (squares[currentSquare].Collide(squares[j]))
                    {
                        Square[] pair = new Square[2];
                        pair[0] = squares[currentSquare];
                        pair[1] = squares[j];

                        collisionInfo.AddPair(pair);

                        squares[currentSquare].collided = true;
                        squares[j].collided = true;

                    }
                }
            }
            return collisionInfo;

        }

        private RectangleShape rect;
        private Vector2f position;
        private Color color;

        private Vector2f velocity;

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

        public override void DrawTexture(RenderTexture texture, RenderStates states)
        {
            rect.Position = position;
            if (collided)
                rect.FillColor = Color.Red;
            else
                rect.FillColor = color;

            texture.Draw(rect);

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

        public void SetVelocity(Vector2f velocity)
        {
            this.velocity = velocity;

        }

        public void Update(Time time)
        {
            this.position += velocity * time.AsSeconds();

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
