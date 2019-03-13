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
    class NewState : StateBase
    {
        private DrawBuffer queue;

        // Keep track of the screen
        private Vector2u size;
        private Vector2u center;

        private SplitLine line = new SplitLine(64, 0.9f);

        public NewState(int drawLimit)
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
            queue.Add(line);

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
