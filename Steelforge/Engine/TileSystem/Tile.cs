using SFML.Graphics;
using SFML.System;
using Steelforge.Objects;

namespace Steelforge.TileSystem
{
    public class Tile
    {
        public Vector2f position;
        public int size;

        public Tile(Vector2f position, int size)
        {
            this.position = position;
            this.size = size;

        }

        public Vector2f GetPosition()
        {
            return position;

        }
    }
}
