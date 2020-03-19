using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort.EventLogComponents
{
    public class EventLogComponent : IEventLogger
    {


        public List<string> GetLog()
        {
            throw new NotImplementedException();
        }

        public string ReadEntry(int index)
        {
            throw new NotImplementedException();
        }

        public void WriteToLog(string entry)
        {
            throw new NotImplementedException();
        }

        //Hello!
    }
}
