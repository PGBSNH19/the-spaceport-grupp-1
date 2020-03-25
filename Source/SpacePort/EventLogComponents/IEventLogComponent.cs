using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public interface IEventLogComponent
    {
        void WriteToEventLog(string entry);
        List<string> GetEventLog();
    }
}
