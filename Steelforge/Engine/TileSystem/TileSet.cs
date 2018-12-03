using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Steelforge.TileSystem
{
    public class TileSet : Drawable
    {
        private List<Tile> tiles = new List<Tile>();
        private Color tileColor = Color.White;

        private Vector2f offset = new Vector2f();

        //private float drawWidth;
        //private float drawHeight;

        //private int offsetX;
        //private int offsetY;

        //private int drawableTilesX;
        //private int drawableTilesY;

        //private float aspectRatio;

        // int screenWidth, int screenHeight, int tileHeight, int tiles = 1024
        public TileSet()
        {      
            // this.drawHeight = tileHeight;
               
            // offsetX = tiles / 2;
            // offsetY = offsetX;
               
            // aspectRatio = (float)screenWidth / (float)screenHeight;
            // this.drawWidth = drawHeight * aspectRatio;
               
            // float drawX = screenWidth / drawWidth + 1;
            // float drawY = screenHeight / drawHeight + 1;
               
            // drawableTilesX = (int)drawX;
            // drawableTilesY = (int)drawY;

        }

        public void AddTile(Tile t)
        {
            tiles.Add(t);

        }

        //public void AddOffset(int x, int y)
        //{
        //    offsetX += x;
        //    offsetY += y;

        //}

        public void AddOffset(Vector2f offset)
        {
            this.offset += offset;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                foreach (Tile tile in tiles)
                {
                    Rendering.Draw.DrawTile((target as RenderWindow), tile, tileColor, offset);

                }
            }
        }
    }
}