using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort
{
    public class EngineComponent : IEngineComponent
    {
       
        public int EngineID { get; set; }
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
