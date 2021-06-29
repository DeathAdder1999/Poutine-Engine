using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Engine.Core.EntityComponentSystem;
using Engine.Core.Input;
using Engine.Physics;
using Engine.Prebuilt;
using Engine.Render;
using Engine.Render.Shapes;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Rectangle = Engine.Render.Shapes.Rectangle;

namespace Engine
{
    static class Program
    {
        static void Main()
        {
            var engine = new Engine();
            var r = new Prebuilt.Rectangle(250, 250, 50, 50);
            var r2 = new Prebuilt.Rectangle(400, 400, 50, 50);
            var inputComponent = new InputComponent();
            var x = PhysicsManager.Instance;

            inputComponent.BindOnPress(Keyboard.Key.W, () =>
            {
                var pos = inputComponent.Owner.Transform.Position;
                inputComponent.Owner.Transform.Position = new Vector2(pos.X + 1, pos.Y);
            });

            var renderComponent = r.GetComponent<RenderComponent>();
            var renderComponent2 = r2.GetComponent<RenderComponent>();

            r.AddComponent(new PhysicsComponent());
            r2.AddComponent(new PhysicsComponent());

            var rectangle1 = (Rectangle) renderComponent.Shape;
            var rectangle2 = (Rectangle) renderComponent2.Shape;
            var collider = new RectangleCollider(rectangle1.X, rectangle1.Y, rectangle1.Width + 10, rectangle1.Height + 10);
            var collider2 = new RectangleCollider(rectangle2.X, rectangle2.Y, rectangle2.Width + 10, rectangle2.Height + 10);

            r.AddComponents(inputComponent, collider);
            r2.AddComponents(collider2);
            GameObjectManager.Instance.Add(r, r2);

            engine.Start(); 
        }
    }
}
