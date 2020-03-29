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

        public bool AllowedPerson(Person person)
        {
            return apiDataFetch.GetPeople(person.Name).count >= 1;
        }

        public bool AllowedShipLength(Spaceship spaceship)
        {
            return spaceship.Length <= 120000;
        }

        public bool FreeParkingSpace()
        {
            using (var context = new SpaceParkContext())
            {
                return parkingSpaces.Where(p => p.OccupyingSpaceship == null) != null;
            }
        }

        public void ParkSpaceship(Person person, Spaceship spaceship)
        {            
            using(var context = new SpaceParkContext())
            {
                ParkingSpace parkingSpace = parkingSpaces.Where(p => p.OccupyingSpaceship == null).First();
                parkingSpace.OccupyingSpaceship = spaceship;
                var parkSpace = context.Parkingspace.Where(p => p.ParkingSpaceID == parkingSpace.ParkingSpaceID).First();
                parkSpace.Spaceship = spaceship.ToDbModel();
                
                context.SaveChanges();
                
            }            
        }

        public bool DepartSpaceShip(Spaceship spaceship)
        {
            using (var context = new SpaceParkContext())
            {
                ParkingSpace parkingSpace = parkingSpaces.Where(p => p.OccupyingSpaceship == spaceship).First();
                parkingSpace.OccupyingSpaceship = null;

                var parkSpace = context.Parkingspace.Where(p => p.ParkingSpaceID == parkingSpace.ParkingSpaceID).First();
                parkSpace.Spaceship = null;
                parkSpace.SpaceshipID = null;
                context.SaveChanges();
                return true;
            }
        }
    }
}
