using SAnimator.Animation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAnimator
{
    public partial class Form1 : Form
    {
        private Animator animator;

        public Form1()
        {
            InitializeComponent();
            CreateCustomComponents();
            RunCustomCode();

        }

        private void CreateCustomComponents()
        {
            animator = new Animator(panel1.Size);
            panel1.Controls.Add(animator);

        }

        private void RunCustomCode()
        {
            while (this.Visible)
            {
                Application.DoEvents();
                animator.Draw();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            animator.state.CreateRects(1000);
            RunCustomCode();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            animator.state.Clear();

        }
    }
}
