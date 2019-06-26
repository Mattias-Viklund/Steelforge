using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge.Core;
using Steelforge.Core.States;
using Steelforge.Input;
using Steelforge.Rendering;

namespace SAnimator.Animation
{
    class AnimationState : StateBase
    {
        private DrawBuffer drawBuffer;

        public AnimationState()
        {
            drawBuffer = new DrawBuffer(0xFFF);

        }

        public override void Update(Time time)
        {
            if (InputManager.MouseButtonPressed(GlobalConstants.MOUSE_1))
            {
                CreateRects(50);

            }
        }

        public void Clear()
        {
            drawBuffer.Clear();

        }

        public void CreateRects(int count)
        {
            Random rng = new Random();
            for (int i = 0; i < count; i++)
            {
                RectangleShape shape = new RectangleShape(new Vector2f(200, 200));
                byte[] color = new byte[3];
                rng.NextBytes(color);
                shape.FillColor = new Color(color[0], color[1], color[2], 255);
                shape.Position = new Vector2f(rng.Next(1000), rng.Next(1000));
                drawBuffer.Add(new GameRenderable(shape));

            }
        }

        public override void FixedUpdate(Time time)
        { }
        public override void Init(RenderWindow window)
        {
            drawBuffer.Add(new GameRenderable(new RectangleShape(new Vector2f(200, 200)) { Position = new Vector2f(200, 200), FillColor = Color.Yellow }));

        }
        public override DrawBuffer Render()
        { return drawBuffer; }

    }
}
