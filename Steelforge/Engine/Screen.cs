using SFML.Graphics;
using SFML.Window;
using Steelforge.Engine.TileSystem;

namespace Steelforge.Engine
{
    public class Screen
    {
        private RenderWindow window;
        //private TileSet tileSet;

        public Screen(uint width, uint height, int tileX, int tileY, string name, Styles style=Styles.Default)
        {
            window = new RenderWindow(new VideoMode(width, height), name, style);

        }

        public void SetTile(int x, int y)
        {


        }

        public RenderWindow GetWindow()
        {
            return window;

        }
    }
}
