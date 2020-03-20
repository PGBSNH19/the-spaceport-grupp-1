using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public interface IEventLogger
    {
        void WriteToLog(string entry);
        List<string> GetLog();
    }
}
