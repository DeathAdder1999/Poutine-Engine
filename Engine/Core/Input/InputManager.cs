using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Engine.Core.EntityComponentSystem;
using SFML.Window;

namespace Engine.Core.Input
{
    public class InputManager
    {
        private static InputManager _instance;

        public static InputManager Instance => _instance ?? (_instance = new InputManager());

        private readonly List<InputComponent> _inputComponents = new List<InputComponent>();
        public EventHandler<Keyboard.Key> KeyPressed;
        public EventHandler<Keyboard.Key> KeyReleased;
        public EventHandler<MouseButtonEventArgs> MouseDown;
        public EventHandler<MouseButtonEventArgs> MouseUp;
        public EventHandler<MouseMoveEventArgs> MouseMoved;
        public EventHandler<MouseWheelScrollEventArgs> MouseScrolled;

        private InputManager()
        {
            EngineService.MainWindow.KeyPressed += OnKeyPressed;
            EngineService.MainWindow.KeyReleased += OnKeyReleased;
            EngineService.MainWindow.MouseButtonPressed += HandleMouseDown;
            EngineService.MainWindow.MouseButtonReleased += HandleMouseUp;
            EngineService.MainWindow.MouseWheelScrolled += HandleMouseScroll;
            EngineService.MainWindow.MouseMoved += HandleMouseMove;
            GameObjectManager.Instance.GameObjectAdded += OnGameObjectAdded;
        }

        public MousePosition MousePosition { get; private set; }
        public bool IsMousePressed { get; private set; }
        public bool IsCtrlPressed { get; private set; }
        public bool IsShiftPressed { get; private set; }
        public bool IsAltPressed { get; private set; }

        private void HandleMouseDown(object sender, MouseButtonEventArgs e)
        {
            IsMousePressed = true;

            HandleSelection(e);

            MouseDown?.Invoke(this, e);
        }

        private void HandleMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsMousePressed = false;

            MouseUp?.Invoke(this, e);
        }

        private void HandleMouseScroll(object sender, MouseWheelScrollEventArgs e)
        {
            MouseScrolled?.Invoke(this, e);
        }

        private void HandleMouseMove(object sender, MouseMoveEventArgs e)
        {
            var newPos = new MousePosition(e.X, e.Y);
            var delta = MousePosition - newPos;
            MousePosition = newPos;

            if (IsMousePressed && !SelectionManager.Instance.IsEmpty)
            {
                SelectionManager.Instance.MoveSelectionBy(delta);
            }

            MouseMoved?.Invoke(this, e);
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.LControl)
            {
                IsCtrlPressed = true;
            }

            if (e.Code == Keyboard.Key.LShift)
            {
                IsShiftPressed = true;
            }

            if (e.Code == Keyboard.Key.LAlt)
            {
                IsAltPressed = true;
            }

            KeyPressed?.Invoke(this, e.Code);
        }

        private void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.LControl)
            {
                IsCtrlPressed = false;
            }

            if (e.Code == Keyboard.Key.LShift)
            {
                IsShiftPressed = false;
            }

            if (e.Code == Keyboard.Key.LAlt)
            {
                IsAltPressed = false;
            }

            KeyReleased?.Invoke(this, e.Code);
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

        private void HandleSelection(MouseButtonEventArgs e)
        {
            var selection = GameObjectManager.Instance.GetSelectionFromMouse(new MousePosition(e.X, e.Y));

            if (selection != null && IsCtrlPressed)
            {
                SelectionManager.Instance.AddSelection(selection);
            }
            else if (selection != null)
            {
                SelectionManager.Instance.Select(selection);
            }
            else
            {
                SelectionManager.Instance.Clear();
            }
        }
    }

    public struct MousePosition
    {
        public MousePosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X;
        public float Y;

        public static MousePosition operator+(MousePosition p1, MousePosition p2) => new MousePosition(p1.X + p2.X, p1.Y + p2.Y);
        public static MousePosition operator-(MousePosition p1, MousePosition p2) => new MousePosition(p1.X - p2.X, p1.Y - p2.Y);
        public static implicit operator PointF(MousePosition m) => new PointF(m.X, m.Y);
        public static explicit operator MousePosition(PointF p) => new MousePosition(p.X, p.Y);
    }
}
