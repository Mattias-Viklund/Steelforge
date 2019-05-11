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
        private Text niggaText = new Text(
            "|   |----\n" +
            "|   |    \n" +
            "|--KKK--|\n" +
            "    |   |\n" +
            "----|   |", Engine.engineFont);
        private CircleShape circol;
        private RectangleShape rectum;

        public Minefield()
        {
            niggaText.CharacterSize = 128;
            niggaText.Position = new Vector2f(600, 200);
            niggaText.Color = Color.Black;

            Vector2f textPos = niggaText.Position;
            FloatRect textRectum = niggaText.GetGlobalBounds();

            Console.WriteLine("LOCAL: "+niggaText.GetLocalBounds().ToString());
            Console.WriteLine("GLOBAL: "+niggaText.GetGlobalBounds().ToString());

            niggaText.Transform.Rotate(45);

            circol = new CircleShape(textRectum.Width/2 + 100, 100);
            circol.Position = new Vector2f(textRectum.Left - 100, textRectum.Top - 130);
            circol.FillColor = Color.White;

            rectum = new RectangleShape(new Vector2f(circol.Radius*2 + 150, circol.Radius*2 + 150));
            rectum.Position = new Vector2f(circol.Position.X - 75, circol.Position.Y-75);
            rectum.FillColor = Color.Red;

        }

        public override void DrawTexture(RenderTexture texture, RenderStates states)
        {
            texture.Draw(rectum);
            texture.Draw(circol);
            texture.Draw(niggaText);

        }
    }
}
