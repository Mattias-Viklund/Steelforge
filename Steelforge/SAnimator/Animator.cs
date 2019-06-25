using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAnimator.Animation;
using SFML.Graphics;
using SFML.Window;
using Steelforge;

namespace SAnimator
{
    class Animator : System.Windows.Forms.Control
    {
        public Engine engine;
        public AnimationState state;

        public Animator(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            engine = new Engine(new RenderWindow(this.Handle));
            state = new AnimationState();
            engine.PushState(state);
            engine.SetDebug(false);

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            engine.Update();

        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            engine.Update();

        }
    }
}
