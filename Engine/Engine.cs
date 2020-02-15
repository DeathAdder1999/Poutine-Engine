using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Engine
{
    public class Engine
    {
        public const float TargetFPS = 45; 
        public const float MinFPS = 25;
        public const long SkipTicks = (long)(1000 / TargetFPS);
        private long _startTime = Utils.GetCurrentTimeMillis();

        public Engine(params string[] settings)
        {

        }

        /// <summary>
        /// Entry point of the engine.
        /// </summary>
        public void Start()
        {
            InitializeServices();
            var nextGameTick = GetTickCount();

            //Main loop
            while (true)
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

        }

        public void Display()
        {

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

        }
    }
}
