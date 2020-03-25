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
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            SpaceParkCorp spacePark = new SpaceParkCorp(new BankAccountComponent(1000), new ParkingService(30));
            SpaceShip falcon = SpaceShipObjectBuilder.BuildFromApi("destroyer");
            falcon.AddPassenger(PersonObjectBuilder.BuildFromApi(1));
            Console.WriteLine(falcon.PassengerList()[0].Name);

            Console.WriteLine(spacePark.IsAllowedToPark(falcon.PassengerList()[0], falcon));
            Console.ReadKey();

        }
    }
}
