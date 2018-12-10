using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge.Rendering;

namespace Steelforge.Core.States
{
    public class EmptyState : StateBase
    {
        private Buffer drawBuffer = new Buffer(0);

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

        public override void Render(ref Buffer bufferOut)
        {
            bufferOut = this.drawBuffer;
        }

        public override void Update(Time time)
        {
        }
    }
}
