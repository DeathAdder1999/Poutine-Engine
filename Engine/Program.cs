using System.Collections.Generic;
using System.Numerics;
using Engine.Core.SceneManagement;
using Engine.Core.EntityComponentSystem;
using Engine.Core.Input;
using Engine.Physics;
using Engine.Render;
using SFML.Window;
using Engine.Core;
using Rectangle = Engine.Render.Shapes.Rectangle;

namespace Engine
{
    static class Program
    {
        static void Main()
        {
            var engine = new Engine();
            var camera = new Camera();
            EngineService.MainCamera = camera;
            var r = new Prebuilt.Rectangle(250, 250, 50, 50);
            var r2 = new Prebuilt.Rectangle(400, 400, 50, 50);
            var inputComponent = new InputComponent();
            var cameraInputComponent = new InputComponent();
            var x = PhysicsManager.Instance;

            /*
            inputComponent.BindOnPress(Keyboard.Key.W, () =>
            {
                var pos = inputComponent.Owner.Transform.Position;
                inputComponent.Owner.Transform.Position = new Vector2(pos.X + 1, pos.Y);
            });
            */

            cameraInputComponent.BindOnPress(Keyboard.Key.A, () => {
                var pos = cameraInputComponent.Owner.Transform.Position;
                cameraInputComponent.Owner.Transform.Position = new Vector2(pos.X - 1, pos.Y);
            });

            cameraInputComponent.BindOnPress(Keyboard.Key.D, () => {
                var pos = cameraInputComponent.Owner.Transform.Position;
                cameraInputComponent.Owner.Transform.Position = new Vector2(pos.X + 1, pos.Y);
            });

            cameraInputComponent.BindOnPress(Keyboard.Key.W, () => {
                var pos = cameraInputComponent.Owner.Transform.Position;
                cameraInputComponent.Owner.Transform.Position = new Vector2(pos.X, pos.Y - 1);
            });

            cameraInputComponent.BindOnPress(Keyboard.Key.S, () => {
                var pos = cameraInputComponent.Owner.Transform.Position;
                cameraInputComponent.Owner.Transform.Position = new Vector2(pos.X, pos.Y + 1);
            });

            camera.AddComponent(cameraInputComponent);

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
            GameObjectManager.Instance.Add(r, r2, camera);

            Scene scene = new Scene("SampleScene");
            scene.AddChildren(new List<GameObject> { r, r2 });

            SceneManager.Instance.AddScene(scene);

            engine.Start(); 
        }
    }
}
