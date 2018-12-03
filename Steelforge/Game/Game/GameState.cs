using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge;
using Steelforge.Core;
using Steelforge.Input;
using Steelforge.Rendering;
using Steelforge.TileSystem;
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

        private TileSet tileSet;

        public GameState(int drawLimit)
        {
            Console.WriteLine("popoo");
            queue = new DrawQueue(drawLimit);

        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();
            queue.QueueItem(tileSet);

        }

        public override void Init(RenderWindow window)
        {
            this.size = window.Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);

            // (int)size.X, (int)size.Y, 25
            tileSet = new TileSet();
            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 0, 20 + 70 * 0), 50));
            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 1, 20 + 70 * 0), 50));
            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 2, 20 + 70 * 0), 50));

            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 0, 20 + 70 * 1), 50));
            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 1, 20 + 70 * 1), 50));
            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 2, 20 + 70 * 1), 50));

            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 0, 20 + 70 * 2), 50));
            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 1, 20 + 70 * 2), 50));
            tileSet.AddTile(new Tile(new Vector2f(20 + 70 * 2, 20 + 70 * 2), 50));

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

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_W))
            {
                tileSet.AddOffset(new Vector2f(0, -4));

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_A))
            {
                tileSet.AddOffset(new Vector2f(-4, 0));

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_S))
            {
                tileSet.AddOffset(new Vector2f(0, 4));

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_D))
            {
                tileSet.AddOffset(new Vector2f(4, 0));

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
