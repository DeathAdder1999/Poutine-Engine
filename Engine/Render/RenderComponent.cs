﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.Physics;
using SFML.Graphics;

namespace Engine.Render
{
    public class RenderComponent : ComponentBase
    {
        public Texture Texture { get; set; }

        public Shape Shape { get; set; }

        public Color Color { get; set; }

        public RenderComponent(GameObject owner) : base(owner)
        {
            Type = ComponentType.RENDER;
        }

        public override void Update()
        {
            
        }


        private void DrawDebug()
        {
        #if DEBUG
            var colliders = Owner.GetComponents<Collider>();
            //Draw colliders
        #endif
        }
    }
}
