﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge.Rendering;

namespace Steelforge.Core.States
{
    public class EmptyState : StateBase
    {
        private DrawBuffer drawBuffer = new DrawBuffer(0);

        public override void FixedUpdate(Time time)
        {
        }

        public override void Init(RenderWindow window)
        {
        }

        public override DrawBuffer Render()
        {
            return drawBuffer;

        }

        public override void Update(Time time)
        {
        }
    }
}
