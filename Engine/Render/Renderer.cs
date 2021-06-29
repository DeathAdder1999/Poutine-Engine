using System;
using System.Collections.Generic;
using Engine.Core;
using Engine.Core.EntityComponentSystem;
using SFML.Graphics;
using SFML.Window;

namespace Engine.Render
{
    public class Renderer
    {
        private RenderWindow _window;
        private List<RenderComponent> _renderComponents = new List<RenderComponent>();
        public EventHandler WindowClosed;

        public Renderer()
        {
             _window = new RenderWindow(VideoMode.DesktopMode, EngineService.AppName);

             _window.Closed += (sender, args) => {
                 WindowClosed?.Invoke(this, EventArgs.Empty);
                 _window.Close();
             };

            EngineService.MainWindow = _window;
             GameObjectManager.Instance.GameObjectAdded += OnGameObjectAdded;
        }

        private void OnGameObjectAdded(object sender, GameObject e)
        {
            if (e.TryGetComponent<RenderComponent>(out var component))
            {
                _renderComponents.Add(component);
            }
        }

        public void Render()
        {
            _window.DispatchEvents();
            _window.Clear();

            var renderComponents = new RenderComponent[_renderComponents.Count];
            _renderComponents.CopyTo(renderComponents);

            foreach (var renderComponent in renderComponents)
            {
                if (renderComponent.IsActive)
                {
                    renderComponent.Update();
                }
            }

            SelectionManager.Instance.DrawDebugGizmos();

            _window.Display();
        }

        public void Init()
        {
            if (_window.IsOpen)
            {
                return;
            }

            _window.SetActive(true);
        }
    }
}
