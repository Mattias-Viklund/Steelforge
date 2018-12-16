using SFML.Graphics;
using SFML.System;
using Steelforge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.GUI
{
    public class Button : GameObject
    {
        private RectangleShape background;
        private Text text;

        public Button(Vector2f position, string text, uint fontSize = 14, byte opacity = 255)
        {
            this.text = new Text(text.ToUpper(), Engine.engineFont);
            this.text.Color = Color.Black;
            this.text.CharacterSize = fontSize;
            this.text.Position = position + new Vector2f(15, 15);

            this.background = new RectangleShape(new Vector2f(this.text.GetGlobalBounds().Width + 30, this.text.GetGlobalBounds().Height + 30));
            this.background.Position = new Vector2f(this.text.GetGlobalBounds().Left - 15, this.text.GetGlobalBounds().Top - 15);
            this.background.FillColor = new Color(255, 255, 255, opacity);

            this.SetPosition(this.background.Position);

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                RenderWindow window = (target as RenderWindow);

                window.Draw(background);
                window.Draw(text);

            }
        }
    }
}
