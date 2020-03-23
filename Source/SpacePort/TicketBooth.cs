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
        public bool IsAllowedToPark(Character person, SpaceShip spaceShip)
        {
            if (NumberOfFreeParkingSpaces() <= 0)
            {
                return false;
            }
            var CharacterInformation = apiCaller.GetCharacter(person.Name) == ;
        }
        public int NumberOfFreeParkingSpaces()
        {
            return parkingSpaces.Where(p => p.IsOccupied() == false).Count(); ;
        }


    }

}
