using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class EventLogComponent : IEventLogger
    {
        private List<string> log = new List<string>();

        public List<string> GetLog()
        {
            return log;
        }

        public string ReadEntry(int index)
        {
            return log[index];
        }

        public void WriteToLog(string entry)
        {
            log.Add(entry);
        }        
    }
}
