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

        private Grid grid = new Grid(100.0f, 20.0f);

        private Vector2f offset = new Vector2f();

        private float movementSpeed = 500.0f;

        public GameState(int drawLimit)
        {
            queue = new DrawBuffer(drawLimit);

        }

        public override void Init(RenderWindow window)
        {
            this.size = window.Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);

            base.RequestExtendedUpdate();

        }

        public override void Update(Time time)
        {
            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_ESCAPE))
            {
                base.Close();

            }

            int scroll = InputManager.ReadScroll();
            if (scroll != 0)
            {
                grid.Zoom(scroll * 0.05f);

            }

            this.offset += InputManager.MOUSE_VELOCITY * movementSpeed * time.AsSeconds();

        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();
            queue.Add(grid);

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
