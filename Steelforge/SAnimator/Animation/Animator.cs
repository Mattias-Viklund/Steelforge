using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using Steelforge;
using Steelforge.Core;

namespace SAnimator.Animation
{
    class Animator : Control
    {
        public AnimationState state;
        private Engine engine;
         
        public Animator(Size controlSize)
        {
            controlSize.Width -= 100;
            Left += 100;
            this.Size = controlSize;
            state = new AnimationState();

            engine = new Engine(new RenderWindow(this.Handle));
            engine.PushState(state);
            engine.FormInit();

        }

        public void Draw()
        {
            engine.FormClear();
            engine.FormUpdate();
            engine.FormDisplay();

        }

        // Prevent default Draw behaviours.
        protected override void OnPaint(PaintEventArgs e)
        { /*base.OnPaint(e);*/ Draw(); }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        { /*base.OnPaintBackground(pevent); */ Draw(); }

    }
}
