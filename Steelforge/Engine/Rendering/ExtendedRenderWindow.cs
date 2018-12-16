using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Steelforge.Rendering
{
    public struct ExtendedRenderWindow
    {
        public RenderWindow window;
        public ExtendedRenderWindow(VideoMode videoMode, string title, Styles style)
        {
            window = new RenderWindow(videoMode, title, style);

        }
    }
}
