﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge.Engine.Rendering;

namespace Steelforge.Engine.Core
{
    public class EmptyState : StateBase
    {
        private DrawQueue drawQueue = new DrawQueue(0);

        public override void FixedUpdate(Time time)
        {
        }

        public override void Init(Screen screen)
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
