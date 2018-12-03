using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Steelforge.Engine.TileSystem
{
    public class TileSet : Drawable
    {
        private List<Tile> tiles = new List<Tile>();
        private float drawWidth;
        private float drawHeight;

        private int offsetX;
        private int offsetY;

        private int drawableTilesX;
        private int drawableTilesY;

        private float aspectRatio;

        private Vector2i selectedTile = new Vector2i(0, 0);

        public TileSet(int screenWidth, int screenHeight, int tileHeight, int tiles = 1024)
        {
            this.drawHeight = tileHeight;

            offsetX = tiles / 2;
            offsetY = offsetX;

            aspectRatio = (float)screenWidth / (float)screenHeight;
            this.drawWidth = drawHeight * aspectRatio;

            float drawX = screenWidth / drawWidth + 1;
            float drawY = screenHeight / drawHeight + 1;

            drawableTilesX = (int)drawX;
            drawableTilesY = (int)drawY;

        }

        private bool CheckTile(int tile)
        {
            return false;

        }

        public void ChangeTile(int tile, Color color)
        {

        }

        public void AddOffset(int x, int y)
        {
            offsetX += x;
            offsetY += y;

        }

        public void HighlightTile(int tile)
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                
            }
        }
    }
}