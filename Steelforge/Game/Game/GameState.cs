using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge;
using Steelforge.Core;
using Steelforge.Input;
using Steelforge.Rendering;
using Steelforge.TileSystem;
using Steelforge.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steelforge.Core.States;
using Steelforge.Objects;

namespace Steelforge.Game
{
    class GameState : StateBase
    {
        private DrawQueue queue;

        // Keep track of the screen
        private Vector2u size;
        private Vector2u center;

        private Button button;

        public GameState(int drawLimit)
        {
            queue = new DrawQueue(drawLimit);

        }

        public override void Init(RenderWindow window)
        {
            this.size = window.Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);
            this.button = new Button(new Vector2f(25, center.Y), "AIDS", 72);

        }

        public override void Update(Time time)
        {
            if (InputManager.PRESSED_KEYS != 0)
            {
                Debug.Write("Pressed Keys: "+InputManager.PRESSED_KEYS);

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_ESCAPE))
            {
                base.Close();

            }

            if (InputManager.MouseButtonPressed(GlobalConstants.MOUSE_1))
            {
                Debug.Write("M1 Pressed, MOUSE_VELOCITY: " + InputManager.MOUSE_VELOCITY);
                GameObject.Create(new Placeholder(new RectangleShape(new Vector2f(20, 20)) { Position = InputManager.MOUSE_POSITION }));

            }
        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();
            queue.Add(button);
            foreach (GameObject gObj in GameObject.gameObjects)
            {
                queue.Add(gObj);

            }
        }

        public override void Render(ref DrawQueue queueOut)
        {
            queueOut = queue;

        }
    }
}
