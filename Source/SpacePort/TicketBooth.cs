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

        public bool IsAllowedToPark(Character person, string shipName)
        {

            if (NumberOfFreeParkingSpaces() <= 0)
            {
                return false;
            }

            var SpaceShipInformation = apiCaller.GetSpaceship(shipName);
            var CharacterInformation = apiCaller.GetCharacter(person.Name);

            return CharacterInformation.results.Any() && SpaceShipInformation.results.Any();
        }
        public int NumberOfFreeParkingSpaces()
        {
            return parkingSpaces.Where(p => p.IsOccupied() == false).Count(); ;
        }


    }

}
