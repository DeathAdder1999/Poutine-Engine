using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Engine.Core
{
    public class Transform
    {
        public Vector2f Position { get; set; }
        public float Rotation { get; set; }
        public Transform Parent { get; set; }
    }
}
