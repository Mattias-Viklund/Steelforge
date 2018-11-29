using SFML.Graphics;

namespace Steelforge.Engine.TileSystem
{
    public class TileSet : Drawable
    {
        private Tile[,] tiles;
        public int tileSetWidth;
        public int tileSetHeight;

        public TileSet(int tilesX, int tilesY, float aspectRatio)
        {
            this.tileSetWidth = tilesX;
            this.tileSetHeight = tilesY;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {


            }
        }
    }
}