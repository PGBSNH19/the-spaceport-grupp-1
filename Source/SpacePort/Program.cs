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
            
            SpaceParkCorp spacePark = new SpaceParkCorp(new BankAccountComponent(), new ParkingService(4));
            string[] menuOptions = { "check in", "pay", "checkout" };
            VisualMenu menu = new VisualMenu(spacePark, menuOptions);
            
            menu.Start();
        }

        public static void AddSpaceShipsToDb()
        {
            using (var context = new SpaceParkContext())
            {
                context.SpaceshipInfo.Add(SpaceshipDbModel.CreateModelFromAPI(new ApiDataFetch(), 13));
                context.SpaceshipInfo.Add(SpaceshipDbModel.CreateModelFromAPI(new ApiDataFetch(), 15));

                context.SpaceshipInfo.Add(SpaceshipDbModel.CreateModelFromAPI(new ApiDataFetch(), 10));
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
