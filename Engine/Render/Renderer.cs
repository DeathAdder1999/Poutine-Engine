using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Engine.Render
{
    public class Renderer
    {
        private RenderWindow _window;

        public Renderer()
        {
             _window = new RenderWindow(VideoMode.DesktopMode, "screen");
        }

        public void Render()
        {
                     
        }
    }
}
