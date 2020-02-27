using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Render;
using SFML.Graphics;

namespace Engine
{
    public static class EngineService
    {
        public static RenderWindow MainWindow { get; set; }
        public static Renderer Renderer { get; set; }
        public static Engine Engine { get; set; }
        public static string AppName = "Poutine Engine";
        public static bool IsDebug { get; set; } = true;
    }
}
