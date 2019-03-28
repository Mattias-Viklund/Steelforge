using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class GameGUI : Drawable
    {
        private RectangleShape topBar;

        public GameGUI(int width, int height)
        {
            topBar = new RectangleShape(new Vector2f(width, height));

        }

        public void Draw(RenderTarget target, RenderStates states)
        {

            
        }
    }
}
