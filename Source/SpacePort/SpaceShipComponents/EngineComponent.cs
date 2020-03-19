using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class EngineComponent : IEngineComponent
    {
        private bool isRunning;

        public EngineComponent(bool isRunning)
        {
            this.isRunning = isRunning;
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public void Start()
        {
            isRunning = true;
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}
