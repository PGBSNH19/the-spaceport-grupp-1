using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpacePort.API;

namespace SpacePort
{
    public class TicketBooth
    {
        private readonly IParkingSpaceComponent[] parkingSpaces;
        private readonly APICaller apiCaller;

        public TicketBooth(IParkingSpaceComponent[] parkingSpaces)
        {
            this.parkingSpaces = parkingSpaces;
            apiCaller = new APICaller();
        }
        public bool IsAllowedToPark(Character person, SpaceshipInformation spaceShip)
        {

            if (NumberOfFreeParkingSpaces() <= 0)
            {
                return false;
            }

            
            var characterInformation = apiCaller.GetCharacter(person.Name);

            return characterInformation.results.Any(c => c.name == person.Name) && double.Parse(spaceShip.length) <= 120000;
        }
        public int NumberOfFreeParkingSpaces()
        {
            return parkingSpaces.Where(p => p.IsOccupied() == false).Count(); ;
        }


    }

}
