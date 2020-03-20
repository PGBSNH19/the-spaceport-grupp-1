using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class EventLogComponent : IEventLogComponent
    {
        private List<string> log = new List<string>();

        public List<string> GetLog()
        {
            return log;
        }

        public void WriteToLog(string entry)
        {
            log.Add(entry);
        }

        
    }
}
