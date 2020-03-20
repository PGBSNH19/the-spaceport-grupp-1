using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpacePort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort.Tests
{
    [TestClass()]
    public class ParkingSpaceComponentTests
    {
        [TestMethod()]
        public void ParkTest_IsOccupiedSetsToTrue_True()
        {
            ParkingSpaceComponent parking = new ParkingSpaceComponent();

            parking.Park();

            Assert.IsTrue(parking.IsOccupied());
        }


    }
}