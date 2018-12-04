using SFML.Graphics;
using SFML.System;
using Steelforge.Objects;
using System.Collections.Generic;

namespace Steelforge.TileSystem
{
    public class TileSet : GameObject, Drawable
    {
        private List<Tile> tiles = new List<Tile>();
        private Color tileColor = Color.White;

        public TileSet()
        {      

        }

        public void AddTile(Tile t)
        {
            tiles.Add(t);

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                foreach (Tile tile in tiles)
                {
                    Rendering.Draw.DrawTile((target as RenderWindow), tile, tileColor, position);

                }
            }
        }

        public List<Tile> GetTiles()
        {
            return tiles;

        }
    }
}