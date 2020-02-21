using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Engine.Core.Input
{
    public class InputComponent : ComponentBase
    {
        private Dictionary<Keyboard.Key, KeyAction> _bindings = new Dictionary<Keyboard.Key, KeyAction>();

        /// <summary>
        /// Used to store all of the input to be used on update
        /// </summary>
        private Queue<Keyboard.Key> _inputQueue = new Queue<Keyboard.Key>();

        public InputComponent(GameObject owner) : base(owner)
        {
            InputManager.Instance.KeyPressed += OnKeyPressed;
            InputManager.Instance.KeyReleased += OnKeyReleased;
        }

        private void OnKeyReleased(object sender, Keyboard.Key e)
        {
            _inputQueue.Enqueue(e);
        }

        private void OnKeyPressed(object sender, Keyboard.Key e)
        {
            _inputQueue.Enqueue(e);
        }

        public override void Update()
        {
            if (_inputQueue.TryDequeue(out var key) && _bindings.TryGetValue(key, out var action))
            {
                action.Action.Invoke();
            }
        }

        public void BindOnRelease(Keyboard.Key key, Action a)
        {
            _bindings.Add(key, new KeyAction(a, true));
        }

        public void BindOnPress(Keyboard.Key key, Action a)
        {
            _bindings.Add(key, new KeyAction(a, false));
        }
    }

    struct KeyAction
    {
        public Action Action { get; }
        public bool OnRelease { get; }

        public KeyAction(Action keyAction, bool onRelease)
        {
            Action = keyAction;
            OnRelease = onRelease;
        }
    }
}
