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

        }

        public override DrawBuffer Render()
        {
            return queue;

        }
    }
}
