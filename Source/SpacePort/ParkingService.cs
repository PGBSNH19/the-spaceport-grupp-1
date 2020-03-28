using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpacePort;
using System.Threading.Tasks;

namespace SpacePort
{
    public class ParkingService
    {
        private ParkingSpace[] parkingSpaces;
        private readonly ApiDataFetch apiDataFetch;

        public ParkingService(int parkingSpaces)
        {
            this.apiDataFetch = new ApiDataFetch();
            this.parkingSpaces = ParkingSpace.GetParkingSpaceAsync(parkingSpaces).Result.ToArray();
            if (ParkingSpace.GetParkingSpaceAsync(parkingSpaces).Result.ToArray().Count() < 1)
            {
                for (int i = 0; i < this.parkingSpaces.Length; i++)
                {
                    this.parkingSpaces[i] = new ParkingSpace();
                }
            }
        }

        public bool IsAllowedToPark(Person person, Spaceship spaceShip)
        {
            return apiDataFetch.GetPeople(person.Name).count < 1 &&
                        spaceShip.Length <= 120000;
        }

        public bool FreeParkingSpace()
        {
            using (var context = new SpaceParkContext())
            {
                return parkingSpaces.Where(p => p.OccupyingSpaceship != null) != null;
            }
        }


    }
}
