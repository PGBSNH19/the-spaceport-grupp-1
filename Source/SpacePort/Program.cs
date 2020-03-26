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
                //Test creation and db entry
                using (var context = new SpaceParkContext())
                {
                    for (int i = 1; i < 11; i++)
                    {
                        if (apiDFetch.GetSpaceShip(i).name != null)
                        {
                            SpaceShipModel spaceShip = SpaceShipModel.
                                CreateModelFromAPI(new ApiDataFetch(), 
                                                    i, 
                                                    new PersonModel
                                                    {
                                                        Name = "test",
                                                        Wallet = 100
                                                    });

                            context.SpaceShip.Add(spaceShip);
                        }                        
                    }
                    
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

        public static async Task<PersonModel> GetPersonDataById(int id)
        {
            PersonModel person = null;

            using (var context = new SpaceParkContext())
            {
                Console.WriteLine("Start GetSpaceship...");

                person = await context.Person.Where(s => s.PersonID == id).FirstOrDefaultAsync<PersonModel>();

                Console.WriteLine("Finished GetSpaceship...");
            }

            return person;
        }

        public static async Task<SpaceShipModel> GetSpaceShipDataById(int id)
        {
            SpaceShipModel spaceShip = null;

            using (var context = new SpaceParkContext())
            {
                Console.WriteLine("Start GetPerson...");

                spaceShip = await context.SpaceShip.Where(s => s.SpaceShipID == id).FirstOrDefaultAsync<SpaceShipModel>();

                Console.WriteLine("Finished GetPerson...");
            }

            return spaceShip;
        }
    }
}
