using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class EventLogComponent : IEventLogComponent
    {
        private List<string> eventLog = new List<string>();

        public List<string> GetEventLog()
        {
            return eventLog;
        }

        public void WriteToEventLog(string entry)
        {
            eventLog.Add(entry);
        }
    }
}
