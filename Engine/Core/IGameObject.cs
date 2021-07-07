using System.Collections.Generic;

namespace Engine.Core
{
    public interface IGameObject 
    {
        void Update();

        void Initialize();

        void Start();
    }
}