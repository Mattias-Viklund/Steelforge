using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using Steelforge.Core.States;
using Steelforge.Rendering;

namespace SAnimator.Animation
{
    class AnimationState : StateBase
    {
        private DrawBuffer buffer;

        public AnimationState()
        {
            buffer = new DrawBuffer(0xFFFF);

        }

        public void AddObject(RectangleShape shape)
        {
            buffer.Add(new GameRenderable(shape));

        }


        public override void Update(Time time)
        {

        }

        public override void FixedUpdate(Time time)
        { }

        public override void Init(RenderWindow window)
        {

        }

        public override DrawBuffer Render()
        {
            return buffer;

        }
    }
}
