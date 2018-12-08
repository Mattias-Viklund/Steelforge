using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.GUI
{
    public class Button : Drawable
    {
        private RectangleShape background;
        private Text text;

        public Button(Vector2f position, string text, uint fontSize = 14, byte opacity = 255)
        {
            this.background = new RectangleShape(new Vector2f(text.Length * fontSize + (fontSize / 2), fontSize + (fontSize / 2)));
            this.background.FillColor = new Color(255, 255, 255, opacity);
            this.background.Position = position;

            this.text = new Text(text, Engine.engineFont);
            this.text.Color = Color.Black;
            this.text.CharacterSize = fontSize;
            this.text.Position = position + new Vector2f(fontSize, (fontSize / 5));

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
