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

        [TestMethod()]
        public void ParkTest_IsOccupiedSetsToFalse_False()
        {
            ParkingSpaceComponent parking = new ParkingSpaceComponent();

            parking.Depart();

            Assert.IsFalse(parking.IsOccupied());
        }


        [TestMethod()]
        public void ParkTest_IsOccupiedStatus_()
        {
            ParkingSpaceComponent parking = new ParkingSpaceComponent();

           

            Assert.IsNotNull(parking.IsOccupied());
        }




    }
}