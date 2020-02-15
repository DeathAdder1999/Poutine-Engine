using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace Engine.Core.Input
{
    public class InputManager
    {
        public static InputManager Instance = new InputManager();
        public EventHandler<Keyboard.Key> KeyPressed;
        public EventHandler<Keyboard.Key> KeyReleased;

        private InputManager()
        {
            EngineService.MainWindow.KeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            KeyPressed?.Invoke(null, e.Code);
        }

        private void OnKeyReleased(object sender, KeyEventArgs e)
        {
            KeyReleased?.Invoke(null, e.Code);
        }
    }
}
