using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge.Engine;
using Steelforge.Engine.Core;
using Steelforge.Engine.Input;
using Steelforge.Engine.Rendering;
using Steelforge.Engine.TileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class GameState : StateBase
    {
        private DrawQueue queue;
        private static DrawQueue staticQueue = new DrawQueue(0);

        // Keep track of the screen
        private Vector2u size;
        private Vector2u center;

        // private TileSet tileSet;

        public GameState(int drawLimit)
        {
            Console.WriteLine("popoo");
            queue = new DrawQueue(drawLimit);

        }

        public override void FixedUpdate(Time time)
        {
        }

        public override void Init(RenderWindow window)
        {
            this.size = window.Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);

            //tileSet = new TileSet((int)size.X, (int)size.Y, 25);

        }

        public override void MouseMoved(object sender, MouseMoveEventArgs e)
        {
        }

        public override void MouseScrolled(object sender, MouseWheelEventArgs e)
        {
        }

        public override void Render(ref DrawQueue queueOut)
        {
            queueOut = queue;

        }

        public override void Update(Time time)
        {
            if (InputManager.PRESSED_KEYS != 0)
            {
                Console.WriteLine("Pressed Keys: " + InputManager.PRESSED_KEYS);

            }

            if ((InputManager.PRESSED_KEYS & GlobalConstants.KEYBOARD_ESCAPE) == GlobalConstants.KEYBOARD_ESCAPE)
            {
                RequestExtendedUpdate();

            }
        }

        protected override void Update(Time time, RenderWindow window)
        {
            if ((InputManager.PRESSED_KEYS & GlobalConstants.KEYBOARD_ESCAPE) == GlobalConstants.KEYBOARD_ESCAPE)
            {
                window.Close();

            }
        }
    }
}
