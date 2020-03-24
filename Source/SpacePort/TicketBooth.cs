using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpacePort;

namespace SpacePort
{
    public class TicketBooth
    {
        private readonly IParkingSpaceComponent[] parkingSpaces;
        private readonly ApiFetchData apiCaller;

        public TicketBooth(IParkingSpaceComponent[] parkingSpaces)
        {
            this.parkingSpaces = parkingSpaces;
            apiCaller = new ApiFetchData();
        }
        public bool IsAllowedToPark(Person person, SpaceShip spaceShip)
        {

            if (NumberOfFreeParkingSpaces() <= 0)
            {
                return false;
            }

            return true;
        }

        public int NumberOfFreeParkingSpaces()
        {
            return parkingSpaces.Where(p => p.IsOccupied() == false).Count(); ;
        }


    }

}
