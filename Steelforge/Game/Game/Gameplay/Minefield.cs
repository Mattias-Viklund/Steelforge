using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game.Gameplay
{
    class Minefield : GameDrawable
    {
        RectangleShape shapes;
        private Vector2f position = new Vector2f(20, 20);

        public Minefield()
        {
            shapes = new RectangleShape(new Vector2f(50, 50));
            shapes.Position = new Vector2f(20, 20);
            shapes.FillColor = Color.Yellow;

        }

        public override void DrawTexture(RenderTexture texture, RenderStates states)
        {
            shapes.Position = (Vector2f)texture.MapCoordsToPixel(position);
            texture.Draw(shapes);

            shapes.Position = (Vector2f)texture.MapCoordsToPixel(position + new Vector2f(50, 50));
            texture.Draw(shapes);

            shapes.Position = (Vector2f)texture.MapCoordsToPixel(position + new Vector2f(100, 100));
            texture.Draw(shapes);

        }

    }
}
