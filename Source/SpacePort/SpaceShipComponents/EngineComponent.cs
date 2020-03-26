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
        public bool IsRunning { get; set; }

        public EngineComponent(bool isRunning)
        {
            this.IsRunning = isRunning;
        }

        public bool GetIsRunning()
        {
            return IsRunning;
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}
