using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEditor
{
    public partial class Editor : Form
    {
        private TextureBrowser browser;

        public Editor()
        {
            InitializeComponent();

        }

        private void Editor_Load(object sender, EventArgs e)
        {
            browser = new TextureBrowser(panel1);
            browser.VerticalScroll.Visible = true;

            this.panel1.Controls.Add(browser);

            foreach (Control c in this.Controls)
            {
                Console.WriteLine(c);

            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
