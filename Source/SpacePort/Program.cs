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


            Person aronCederlund = new Person("Aron Cederlund", 200);

            Spaceship falcon = new Spaceship { Name = "Falcon", Length = 200, Owner = aronCederlund };
            Spaceship cruiser = new Spaceship { Name = "cruiser", Length = 100 };

            List<ParkingSpace> ParkingSpaces = new List<ParkingSpace>();
            ParkingSpaces.Add(new ParkingSpace { OccupyingSpaceship = falcon });
            ParkingSpaces.Add(new ParkingSpace());

            //using (var context = new SpaceParkContext())
            //{
            //    context.Add<ParkingSpaceDbModel>(ParkingSpaces[0].ToDbModel());
            //    context.Add<ParkingSpaceDbModel>(ParkingSpaces[1].ToDbModel());

            //    context.Add<SpaceshipDbModel>(cruiser.ToDbModel());

            //    context.SaveChanges();
            //}

            ParkingSpace newPark = ParkingSpaceDbModel.CreateModelFromDb(2).Result.CreateObjectFromModel();
        }
    }
}
