using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public interface IEventLogger
    {
        void WriteToLog(string entry);
        string ReadEntry(int index);
        List<string> GetLog();
    }
}
