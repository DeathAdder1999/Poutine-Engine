using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Engine
{
    public class Engine
    {
        public Engine(params string[] settings)
        {

        }

        /// <summary>
        /// Entry point of the engine.
        /// </summary>
        public void Start()
        {
            InitializeServices();

            //Main loop
            while (true)
            {

            }
        }

        /// <summary>
        /// Initializes all of components of the engine
        /// </summary>
        private void InitializeServices()
        {

        }
    }
}
