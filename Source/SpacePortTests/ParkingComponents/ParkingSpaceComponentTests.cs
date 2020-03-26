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
            ParkingSpace parking = new ParkingSpace();

            parking.Park();

            Assert.IsTrue(parking.IsOccupied());
        }

        [TestMethod()]
        public void ParkTest_IsOccupiedSetsToFalse_False()
        {
            ParkingSpace parking = new ParkingSpace();

            parking.Depart();

            Assert.IsFalse(parking.IsOccupied());
        }


        [TestMethod()]
        public void ParkTest_IsOccupiedStatus_()
        {
            ParkingSpace parking = new ParkingSpace();

           

            Assert.IsNotNull(parking.IsOccupied());
        }




    }
}