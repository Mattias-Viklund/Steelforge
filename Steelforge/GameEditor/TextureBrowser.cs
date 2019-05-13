using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEditor
{
    class TextureBrowser : Panel
    {
        private Image image = Image.FromFile("Thumbnail.png");

        public TextureBrowser(Control parent)
        {
            this.Size = parent.Size;
            this.Paint += new PaintEventHandler(CreateThumbnails);
            this.Scroll += new ScrollEventHandler(HandleScroll);

        }

        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            this.HorizontalScroll.Value = e.NewValue;
        }

        private void CreateThumbnails(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int thumbnailSpacing = 5;

            int thumbnailHeight = 64;
            int thumbnailWidth = 64;

            int scrollWidth = 3;

            int fitsX = this.Size.Width / (thumbnailSpacing + thumbnailWidth + scrollWidth);
            int fitsY = this.Size.Height / (thumbnailSpacing + thumbnailHeight + scrollWidth);

            for (int x = 1; x <= fitsX; x++)
            {
                int padX = thumbnailSpacing* x +thumbnailWidth * (x - 1);
                for (int y = 1; y <= fitsY; y++)
                {
                    int padY = thumbnailSpacing * y + thumbnailHeight * (y - 1);
                    g.DrawImage(image, padX, padY, 64, 64);

                }
            }
        }
    }
}
