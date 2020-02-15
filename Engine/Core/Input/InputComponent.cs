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

        public InputComponent(GameObject owner) : base(owner)
        {
            InputManager.Instance.KeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, Keyboard.Key e)
        {
            
        }

        public override void Update()
        {
            
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
