using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort
{
    public class EventLogComponent : IEventLogComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventLogID { get; set; }
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
