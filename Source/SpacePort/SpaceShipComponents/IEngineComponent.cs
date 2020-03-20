using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public interface IEngineComponent
    {
        void Start();
        void Stop();
        bool IsRunning();
    }
}
