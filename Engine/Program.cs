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
            var r = new Prebuilt.Rectangle(250, 250, 20, 20);
            var r2 = new Prebuilt.Rectangle(400, 400, 20, 20);
            var inputComponent = new InputComponent(r);
            var x = PhysicsManager.Instance;

            inputComponent.BindOnPress(Keyboard.Key.W, () =>
            {
                var pos = inputComponent.Owner.Transform.Position;
                inputComponent.Owner.Transform.Position = new Vector2(pos.X + 1, pos.Y);
            });

            var renderComponent = new RenderComponent(r) {Shape = new Render.Shapes.Rectangle(new Vector2f(50, 50))};
            var renderComponent2 = new RenderComponent(r2) { Shape = new Render.Shapes.Rectangle(new Vector2f(50, 50)) };
            var p1 = new PhysicsComponent(r);
            var p2 = new PhysicsComponent(r2);

            r.AddComponent(p1);
            r2.AddComponent(p2);

            var rectangle1 = (Rectangle) renderComponent.Shape;
            var rectangle2 = (Rectangle) renderComponent.Shape;
            var collider = new RectangleCollider(r, rectangle1.X, rectangle1.Y, rectangle1.Width + 10, rectangle1.Height + 10);
            var collider2 = new RectangleCollider(r2, rectangle2.X, rectangle2.Y, rectangle2.Width + 10, rectangle2.Height + 10);

            r.AddComponents(renderComponent, inputComponent, collider);
            r2.AddComponents(renderComponent2, collider2);
            GameObjectManager.Instance.Add(r, r2);

            engine.Start(); 
        }
    }
}
