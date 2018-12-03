using SFML.Graphics;
using SFML.System;
using Steelforge.TileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Rendering
{
    class Draw
    {
        public static void DrawTile(RenderWindow window, Tile tile, Color color, Vector2f offset)
        {
            RectangleShape rectangle = new RectangleShape();

            rectangle.Size = new Vector2f(tile.size, tile.size);
            rectangle.Position = tile.position + offset;
            rectangle.FillColor = color;

            window.Draw(rectangle);

        }
    }
}
