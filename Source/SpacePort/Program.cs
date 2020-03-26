using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Newtonsoft.Json;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing area!
            ApiDataFetch apiDFetch = new ApiDataFetch();

            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            SpaceParkCorp spacePark = new SpaceParkCorp(new BankAccountComponent(1000), new ParkingService(30));
            SpaceShip falcon = SpaceShipObjectBuilder.BuildFromApi("destroyer");
            falcon.AddPassenger(PersonObjectBuilder.BuildFromApi(1));
            Console.WriteLine(falcon.PassengerList()[0].Name);

            Console.WriteLine(spacePark.IsAllowedToPark(falcon.PassengerList()[0], falcon));
            //Console.ReadKey();

            if (true)
            {              
                SpaceShipModel spaceShipModel = new SpaceShipModel();
                SpaceshipData spaceshipData = apiDFetch.GetSpaceShip("falcon");
                spaceShipModel.Name = spaceshipData.name;
                spaceShipModel.Length = double.Parse(spaceshipData.length);
                spaceShipModel.Owner = new PersonModel
                {
                    Name = "Harry Dirt",
                    Wallet = 100
                };

                SpaceShipModel spaceShipModel2 = new SpaceShipModel();
                spaceShipModel2.Name = spaceshipData.name;
                spaceShipModel2.Length = double.Parse(spaceshipData.length);
                spaceShipModel2.Owner = new PersonModel
                {
                    Name = "Dirty Hair",
                    Wallet = 500
                };

                //Test creation and db entry
                using (var context = new SpaceParkContext())
                {
                    context.SpaceShip.Add(spaceShipModel);
                    context.SpaceShip.Add(spaceShipModel2);

                    context.SaveChanges();
                }

                //Delete all entries in db-tables
                using (var context = new SpaceParkContext())
                {
                    List<SpaceShipModel> tempSList = context.SpaceShip.ToList();
                    List<PersonModel> tempPList = context.Person.ToList();

                    foreach (var item in tempSList)
                    {
                        context.SpaceShip.Remove(item);
                    }

                    foreach (var item in tempPList)
                    {
                        context.Person.Remove(item);
                    }

                    context.SaveChanges();
                }
                
            }



        }
    }
}
