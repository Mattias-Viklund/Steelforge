using SFML.Graphics;
using SFML.System;

namespace Steelforge.TileSystem
{
    public struct Tile
    {
        public Vector2f position;
        public int size;

        public Tile(Vector2f position, int size)
        {
            this.position = position;
            this.size = size;

        }
    }
}
