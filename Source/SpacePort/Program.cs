using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing area!
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            DbTesting();
            List<ParkingSpace> parkingSpaces = new List<ParkingSpace>();
            List<Spaceship> Spaceships = new List<Spaceship>();
            ApiDataFetch apiFetch = new ApiDataFetch();

            for (int i = 0; i < 3; i++)
            {
                parkingSpaces.Add(new ParkingSpace());
            }
            int[] shipsAPInums = { 2, 3, 5, 9 };
            int[] personsAPInums = { 1, 2, 3, 4 };

            for (int i = 0; i < shipsAPInums.Length; i++)
            {
                Spaceships.Add(Spaceship.CreateObjectFromAPI(apiFetch, shipsAPInums[i]));
                Spaceships.Last().Owner = Person.CreateObjectFromAPI(apiFetch, personsAPInums[i]);
            }

            using (var context = new SpaceParkContext())
            {
                for (int i = 0; i < 3; i++)
                {
                    parkingSpaces[i].OccupyingSpaceship = Spaceships[i];
                    
                        context.ParkingSpaceInfo.Add(parkingSpaces[i].ToDbModel());
                }
                context.SaveChanges();
            }


        }

        public static void DbTesting()
        {
            //Person aronCederlund = new Person("Aron Cederlund", 200);

            //Spaceship falcon = new Spaceship { Name = "Falcon", Length = 200, Owner = aronCederlund };
            //Spaceship cruiser = new Spaceship { Name = "cruiser", Length = 100 };

            //List<ParkingSpace> ParkingSpaces = new List<ParkingSpace>();
            //ParkingSpaces.Add(new ParkingSpace { OccupyingSpaceship = falcon });
            //ParkingSpaces.Add(new ParkingSpace());
            List<Person> persons = Person.GetPeopleAsync().Result;
            List<Spaceship> spaceships = Spaceship.GetSpaceShipsAsync().Result;

            //ParkingSpace newPark = ParkingSpaceDbModel.CreateModelFromDb(2).Result.CreateObjectFromModel();

        }

        public void EraseAllTableEntries()
        {
            

        }
    }
}
