using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge.Engine;
using Steelforge.Engine.Core;
using Steelforge.Engine.Input;
using Steelforge.Engine.Rendering;
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

        private Vector2u size;
        private Vector2u center;

        private bool draw = true;

        public GameState(int drawLimit)
        {
            Console.WriteLine("popoo");
            queue = new DrawQueue(drawLimit);

        }

        public override void FixedUpdate(Time time)
        {
        }

        public override void Init(Screen screen)
        {
            this.size = screen.GetWindow().Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);

            Vertex[] triangle = new Vertex[3];

            triangle[0] = new Vertex(new Vector2f(0, -300) + (Vector2f)center, Color.Red);
            triangle[1] = new Vertex(new Vector2f(300, 300) + (Vector2f)center, Color.Green);
            triangle[2] = new Vertex(new Vector2f(-300, 300) + (Vector2f)center, Color.Blue);

            VertexArray array = new VertexArray(PrimitiveType.Triangles, 3);
            array.Append(triangle[0]);
            array.Append(triangle[1]);
            array.Append(triangle[2]);

            queue.QueueItem(array);

        }

        public override void MouseMoved(object sender, MouseMoveEventArgs e)
        {
        }

        public override void MouseScrolled(object sender, MouseWheelEventArgs e)
        {
        }

        public override void Render(ref DrawQueue queueOut)
        {
            if (draw)
                queueOut = queue;
            else
                queueOut = staticQueue;

        }

        public override void Update(Time time)
        {
            if (InputManager.PRESSED_KEYS != 0)
            {
                Console.WriteLine("HELD Keys: " + InputManager.HELD_KEYS);

            }
            if ((InputManager.HELD_KEYS & GlobalConstants.KEYBOARD_SPACE) == GlobalConstants.KEYBOARD_SPACE)
                draw = false;
            else
                draw = true;

        }
    }
}
