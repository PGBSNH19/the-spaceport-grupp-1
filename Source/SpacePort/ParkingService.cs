using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpacePort;

namespace SpacePort
{
    public class ParkingService
    {
        private ParkingSpace[] parkingSpaces;
        private readonly ApiDataFetch apiDataFetch;

        public ParkingService(int parkingSpaces)
        {
            this.parkingSpaces = new ParkingSpace[parkingSpaces];
            this.apiDataFetch = new ApiDataFetch();

            for (int i = 0; i < this.parkingSpaces.Length; i++)
            {
                this.parkingSpaces[i] = new ParkingSpace();
            }
        }

        public bool IsAllowedToPark(Person person, Spaceship spaceShip)
        {
            if (NumberOfFreeParkingSpaces() <= 0)
            {
                return false;
            }

            return apiDataFetch.GetPerson(person.Name).name != null &&
                        spaceShip.Length <= 120000;
        }

        public int NumberOfFreeParkingSpaces()
        {
            return parkingSpaces.Where(p => p.OccupyingSpaceship == null).Count();
        }
    }
}
