using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using Steelforge.Core.States;
using Steelforge.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Game
{
    class LightingDemo : StateBase
    {
        private DrawBuffer queue;
        private List<VertexArray> lines = new List<VertexArray>();
        private VertexArray vertices = new VertexArray(PrimitiveType.Lines);
        private VertexArray vertices2 = new VertexArray(PrimitiveType.Lines);
        private Light light = new Light(Color.Yellow, new Vector2f(400, 400), 200);

        public override void Init(RenderWindow window)
        {
            queue = new DrawBuffer(0xFF);

            vertices.Append(new Vertex(new Vector2f(0, -100), new Color(255, 0, 0)));
            vertices.Append(new Vertex(new Vector2f(600, 900), new Color(0, 255, 0)));

            vertices2.Append(new Vertex(new Vector2f(1920, -100), new Color(255, 0, 0)));
            vertices2.Append(new Vertex(new Vector2f(600, 900), new Color(0, 255, 0)));

            GenerateLines(1000, (int)window.Size.X, (int)window.Size.Y);

        }

        public void GenerateLines(int count, int maxX, int maxY)
        {
            Random rng = new Random();
            for (int i = 0; i < count; i++)
            {
                VertexArray line = new VertexArray(PrimitiveType.Lines);
                line.Append(new Vertex(new Vector2f(rng.Next(0, maxX), rng.Next(0, maxY)), new Color((byte)rng.Next(0, 255), (byte)rng.Next(0, 255), (byte)rng.Next(0, 255))));
                line.Append(new Vertex(new Vector2f(rng.Next(0, maxX), rng.Next(0, maxY)), new Color((byte)rng.Next(0, 255), (byte)rng.Next(0, 255), (byte)rng.Next(0, 255))));

                lines.Add(line);

            }
        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();
            light.Clear();

            foreach (VertexArray arr in lines)
            {
                queue.Add(new GameRenderable(light.GetLight(arr)));

            }
            //light.Draw(ref queue);

        }

        public override DrawBuffer Render()
        {
            return queue;

        }

        public override void Update(Time time)
        {
            light.Move(Input.InputManager.MOUSE_POSITION);

        }
    }
}
