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

            logCopy = eLog.GetLog();

            Assert.IsNotNull(logCopy);
        }
    }
}