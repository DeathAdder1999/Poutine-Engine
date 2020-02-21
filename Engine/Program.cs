using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Engine.Core.EntityComponentSystem;
using Engine.Core.Input;
using Engine.Prebuilt;
using Engine.Render;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Engine
{
    static class Program
    {
        static void Main()
        {
            var engine = new Engine();
            var r = new Rectangle(250, 250, 20, 20);
            var inputComponent = new InputComponent(r);
            inputComponent.BindOnPress(Keyboard.Key.W, () =>
            {
                var pos = inputComponent.Owner.Transform.Position;
                inputComponent.Owner.Transform.Position = new Vector2(pos.X + 1, pos.Y);
            });
            var renderComponent = new RenderComponent(r) {Shape = new RectangleShape(new Vector2f(50, 50))};
            //renderComponent.Shape.FillColor = Color.Black;
            r.AddComponents(renderComponent, inputComponent);
            GameObjectManager.Instance.Add(r);

            engine.Start(); 
        }
    }
}
