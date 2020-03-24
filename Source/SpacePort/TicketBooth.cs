using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpacePort;

namespace SpacePort
{
    public class TicketBooth
    {
        private IParkingSpaceComponent[] parkingSpaces;
        private readonly ApiFetchData apiCaller;

        public TicketBooth(int parkingSpaces)
        {
            this.parkingSpaces = new IParkingSpaceComponent[parkingSpaces];
            this.apiCaller = new ApiFetchData();
            for (int i = 0; i < this.parkingSpaces.Length; i++)
            {
                this.parkingSpaces[i] = new ParkingSpaceComponent();
            }
        }
        public bool IsAllowedToPark(Person person, SpaceShip spaceShip)
        {

            if (NumberOfFreeParkingSpaces() <= 0)
            {
                return false;
            }


            return apiCaller.GetPerson(person.Name).name != null && spaceShip.GetShipLength() <= 120000;
        }

        public int NumberOfFreeParkingSpaces()
        {
            return parkingSpaces.Where(p => p.IsOccupied() == false).Count();
        }


    }

}
