using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpacePort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort.Tests
{
    [TestClass()]
    public class EngineComponentTests
    {
        [TestMethod()]
        public void IsRunningTest_()
        {
            EngineComponent engine = new EngineComponent(false);
            Assert.IsNotNull(engine.GetIsRunning());
        }

        [TestMethod()]
        public void StartTest_StartEngine_IsRunningTrue()
        {
            EngineComponent engine = new EngineComponent(false);
            engine.Start();
            Assert.IsTrue(engine.GetIsRunning());
        }

        [TestMethod()]
        public void StopTest_StopEngine_IsRunningFalse()
        {
            EngineComponent engine = new EngineComponent(false);
            engine.Stop();
            Assert.IsFalse(engine.GetIsRunning());
        }
    }





}