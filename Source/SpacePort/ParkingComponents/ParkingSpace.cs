using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class ParkingSpace
    {
        public int ParkingSpaceID { get; set; }
        public SpaceShip SpaceShip { get; set; }
        public bool Occupied { get; set; }


        public ParkingSpace(int parkingSpaceID, SpaceShip spaceShip, bool occupied)
        {
            this.ParkingSpaceID = parkingSpaceID;
            this.SpaceShip = spaceShip;
            this.Occupied = Occupied;
        }
        public ParkingSpace(bool occupied = false)
        {
            
        }
    }
}
