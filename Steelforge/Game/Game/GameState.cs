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
        private DrawBuffer queue;

        // Keep track of the screen
        private Vector2u size;
        private Vector2u center;

        private Vector2f offset = new Vector2f();

        private Button button;
        private Text text;

        public GameState(int drawLimit)
        {
            queue = new DrawBuffer(drawLimit);

        }

        public override void Init(RenderWindow window)
        {
            this.size = window.Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);
            this.button = new Button(new Vector2f(25, center.Y), "Motorbiking, Streak of lightning", 48);

            this.text = new Text("Hello", Engine.engineFont);
            this.text.Position = new Vector2f(500, 360);

            base.RequestExtendedUpdate();

        }

        public override void Update(Time time)
        {
            if (InputManager.PRESSED_KEYS != 0)
            {
                Debug.Write("Pressed Keys: " + InputManager.PRESSED_KEYS);

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_ESCAPE))
            {
                base.Close();

            }

            if (InputManager.MouseButtonPressed(GlobalConstants.MOUSE_1))
            {
                Debug.Write("M1 Pressed, MOUSE_VELOCITY: " + InputManager.MOUSE_VELOCITY);

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_W))
            {
                this.offset += new Vector2f(0, -10);

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_A))
            {
                this.offset += new Vector2f(-10, 0);

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_S))
            {
                this.offset += new Vector2f(0, 10);

            }

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_D))
            {
                this.offset += new Vector2f(10, 0);

            }
        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();
            queue.Add(text, offset);
            queue.Add(button, -offset);

            foreach (GameObject gObj in GameObject.gameObjects)
            {
                queue.Add(gObj);

            }
        }

        protected override void Update(Time time, Engine engine)
        {

        }

        public override DrawBuffer Render()
        {
            return queue;

        }
    }
}
