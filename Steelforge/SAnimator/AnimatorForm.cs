using SFML.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SFML.Graphics;

namespace SAnimator
{
    public partial class AnimatorForm : Form
    {
        private Animator animator;

        public AnimatorForm()
        {
            InitializeComponent();

        }

        private void FormSetup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void AnimatorForm_Load(object sender, EventArgs e)
        {
            FormSetup();
            this.Size = new Size(1200, 600);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            animator = new Animator(this.Width-200, this.Height);
            animator.Left = 200;
            this.Controls.Add(animator);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            for (int i = 0; i < 10; i++)
            {
                RectangleShape a = new RectangleShape(new Vector2f(200, 200));
                a.Position = new Vector2f(rng.Next(1000), rng.Next(1000));

                animator.state.AddObject(a);

            }
            animator.engine.Update();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            animator.engine.DumpTexture().SaveToFile("test.png");

        }
    }
}
