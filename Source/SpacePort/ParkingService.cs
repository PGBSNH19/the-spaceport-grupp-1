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
            return apiDataFetch.GetPeople(person.Name).count >= 1 &&
                        spaceShip.Length <= 120000;
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
                var all = from c in context.ParkingSpaceInfo select c;
                context.ParkingSpaceInfo.RemoveRange(all);
                context.SaveChanges();
                ParkingSpace parkingSpace = parkingSpaces.Where(p => p.OccupyingSpaceship == null).First();
                parkingSpace.OccupyingSpaceship = spaceship;
                
            }
            
        }

        public bool DepartSpaceShip(Spaceship spaceship)
        {
            using (var context = new SpaceParkContext())
            {
                ParkingSpaceDbModel model = parkingSpaces.Where(p => p.OccupyingSpaceship.ID == spaceship.ID).First().ToDbModel();
                
                
                context.SaveChanges();
                return true;
            }
        }

        public void CreateInvoice(Person person, Spaceship spaceship)
        {
            
        }


    }
}
