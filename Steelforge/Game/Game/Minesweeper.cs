using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using Steelforge.Core.States;
using Steelforge.Game.Gameplay;
using Steelforge.Input;
using Steelforge.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class Minesweeper : StateBase
    {
        private DrawBuffer queue;
        private GameDrawable grid = new GameRenderable(new RectangleShape(new Vector2f(50, 50)) { Position = new Vector2f(100, 50), FillColor = Color.Yellow });
        private Minefield minefield = new Minefield();

        public Minesweeper()
        {
            queue = new DrawBuffer(0xFF);

        }

        public override void Init(RenderWindow window)
        {

        }

        public override void Update(Time time)
        {
            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_ESCAPE))
            {
                base.Close();

            }

        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();
            //queue.Add(grid);
            queue.Add(minefield);

        }

        public override DrawBuffer Render()
        {
            return queue;

        }
    }
}
