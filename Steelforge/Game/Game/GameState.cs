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
using Steelforge.Game.Components;

namespace Steelforge.Game
{
    class GameState : StateBase
    {
        private DrawBuffer queue;

        // Keep track of the screen
        private Vector2u size;
        private Vector2u center;

        private Vector2f offset = new Vector2f();
        private Graph graph = new Graph(new Vector2f(), new Vector2f());

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


        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();

            foreach (GameObject g in GameObject.gameObjects)
            {
                queue.Add(g);

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
