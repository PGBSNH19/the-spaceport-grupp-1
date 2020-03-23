using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpacePort
{
    public class TicketBooth
    {
        private readonly IParkingSpaceComponent[] parkingSpaces;
        private readonly APICaller apiCaller;
        public bool IsAllowedToPark()
        {
            return false;
        }
        public int NumberOfFreeParkingSpaces()
        {
            return parkingSpaces.Where(p => p.IsOccupied() == false).Count(); ;
        }
    }

}
