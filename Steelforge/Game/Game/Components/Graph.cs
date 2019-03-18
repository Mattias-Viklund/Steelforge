using SFML.Graphics;
using SFML.System;
using Steelforge.Objects;
using Steelforge.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game.Components
{
    class Graph : Drawable
    {
        private Vector2f position;
        private Vector2f size;

        private List<int> points = new List<int>();

        static Drawable[] aids = { new RectangleShape(new Vector2f(200, 200)) { Position = new Vector2f(500, 500), FillColor = Color.Red } };
        private DrawContainer drawContainer = new DrawContainer(aids);

        public Graph(Vector2f position, Vector2f size)
        {
            this.position = position;
            this.size = size;

        }

        public void AddPoint()
        {


        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
                drawContainer.Draw((target as RenderWindow));

        }
    }
}
