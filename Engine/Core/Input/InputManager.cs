using System;
using System.Collections.Generic;
using Engine.Core.EntityComponentSystem;
using SFML.Window;

namespace Engine.Core.Input
{
    public class InputManager
    {
        public static InputManager Instance = new InputManager();
        private List<InputComponent> _inputComponents = new List<InputComponent>();
        public EventHandler<Keyboard.Key> KeyPressed;
        public EventHandler<Keyboard.Key> KeyReleased;

        private InputManager()
        {
            EngineService.MainWindow.KeyPressed += OnKeyPressed;
            EngineService.MainWindow.KeyReleased += OnKeyReleased;
            GameObjectManager.Instance.GameObjectAdded += OnGameObjectAdded;
        }

        private void OnGameObjectAdded(object sender, GameObject e)
        {
            if (e.TryGetComponent<InputComponent>(out var component))
            {
                _inputComponents.Add(component);
            }
        }

        public void HandleInputs()
        {
            var inputComponents = new InputComponent[_inputComponents.Count];
            _inputComponents.CopyTo(inputComponents);

            foreach (var component in _inputComponents)
            {
                component.Update();
            }
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
