using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge.Rendering;

namespace Steelforge.Core.States
{
    public class EmptyState : StateBase
    {
        private DrawQueue drawQueue = new DrawQueue(0);

        public override void FixedUpdate(Time time)
        {
        }

        public override void Init(RenderWindow window)
        {
        }

        public override void MouseMoved(object sender, MouseMoveEventArgs e)
        {
        }

        public override void MouseScrolled(object sender, MouseWheelEventArgs e)
        {
        }

        public override void Render(ref DrawQueue queueOut)
        {
            queueOut = this.drawQueue;
        }

        public override void Update(Time time)
        {
        }
    }
}
