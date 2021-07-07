using System.Numerics;
using Engine.Core;
using Engine.Core.Input;
using Engine.Physics;
using Engine.Render.Shapes;
using SFML.Graphics;
using SFML.System;

namespace Engine.Render
{
    public class RenderComponent : ComponentBase
    {
        public Sprite Sprite { get; set; }

        public ShapeBase Shape { get; set; }

        public Color Color { get; set; }

        public RenderComponent()
        {
            Type = ComponentType.RENDER;
        }

        public bool IsUnderMouse(MousePosition pos)
        {
            if (Sprite != null)
            {
                return Sprite.Contains(pos);
            }

            return Shape != null && Shape.Contains(pos);
        }

        public override void Update()
        {
            Draw();
            DrawDebug();         
        }

        private void Draw()
        {
            var camera = EngineService.MainCamera;
            var cameraPos = camera?.Transform?.Position ?? Vector2.Zero;
            var pos = Owner.Transform.Position;
            Shape.Position = new Vector2f(pos.X - cameraPos.X, pos.Y - cameraPos.Y);
            Graphics.Draw(Shape);
        }

        private void DrawDebug()
        {
        #if DEBUG
            var colliders = Owner.GetComponents<ColliderComponent>();
            
            if (Owner.IsSelected)
            {
                var pos = Shape.Position;

                Graphics.DrawArrows(new Vector2f(pos.X, pos.Y), Shape.Scale);

                foreach (var collider in colliders)
                {
                    collider.ColliderShape.Position = pos;
                    Graphics.Draw(collider.ColliderShape);
                }
            }
        #endif
        }
    }
}
