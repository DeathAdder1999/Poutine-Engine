using System;
using System.Threading;
using Engine.Core.EntityComponentSystem;
using Engine.Core.Input;
using Engine.Physics;
using Engine.Render;

namespace Engine
{
    public class Engine
    {
        public const float TargetFPS = 45; 
        public const float MinFPS = 25;
        public const long SkipTicks = (long)(1000 / TargetFPS);
        private long _startTime = Utils.GetCurrentTimeMillis();
        private bool _run = true;

        public Engine(params string[] settings)
        {
            InitializeServices();
            EngineService.Renderer.WindowClosed += OnClosed;
        }

        private void OnClosed(object sender, EventArgs e)
        {
            //TODO cleanup
            _run = false;
        }

        /// <summary>
        /// Entry point of the engine loop.
        /// <remarks>Blocking call</remarks>
        /// </summary>
        public void Start()
        {
            var nextGameTick = GetTickCount();

            //Main loop
            while (_run)
            {
                Update();
                Display();

                nextGameTick += SkipTicks;
                var sleepTime = nextGameTick - GetTickCount();

                if (sleepTime >= 0)
                {
                   Thread.Sleep((int) sleepTime);
                }
                else
                {
                    //Need to catch up
                }
            }
        }

        public void Update()
        {
            PhysicsManager.Instance.Update();
            InputManager.Instance.HandleInputs();
        }

        public void Display()
        {
            EngineService.Renderer.Render();
        }

        private long GetTickCount()
        {
            return Utils.GetCurrentTimeMillis() - _startTime;
        }

        /// <summary>
        /// Initializes all of components of the engine
        /// </summary>
        private void InitializeServices()
        {
            EngineService.Renderer = new Renderer();
            EngineService.Renderer.Init();

        }
    }
}
