using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpacePort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort.Tests
{
    [TestClass()]
    public class EventLogComponentTests
    {
        [TestMethod()]
        public void GetLogTest()
        {
            EventLogComponent eLog = new EventLogComponent();
            List<string> logCopy;

            logCopy = eLog.GetEventLog();

            Assert.IsNotNull(logCopy);
        }

        [TestMethod()]
        public void WriteToLogTest_AddEntry_GetEntry()
        {
            string entry = "testdata";
            EventLogComponent eventLog = new EventLogComponent();
            eventLog.WriteToEventLog(entry);

            Assert.AreEqual(entry, eventLog.GetEventLog()[0]);
        }
    }
}