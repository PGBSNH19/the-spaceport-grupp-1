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
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<SpaceShip> spaceShips = new List<SpaceShip>();
            List<Person> characters = new List<Person>();
            ApiFetchData data = new ApiFetchData();
            SpaceParkCorp s = new SpaceParkCorp();

            SpaceShip falcon = SpaceShipObjectBuilder.BuildFromApi("destroyer");
            SpaceShip falcon2 = SpaceShipObjectBuilder.BuildFromApi(9);
            SpaceShip falcon3 = SpaceShipObjectBuilder.BuildFromApi(10);
            SpaceShip falcon4 = SpaceShipObjectBuilder.BuildFromApi(9);

            falcon.AddPassenger(PersonObjectBuilder.BuildFromApi(1));

            Console.WriteLine(falcon.PassengerList()[0].Name);

            
            ApiFetchData apiFetch = new ApiFetchData();

            Console.ReadKey();
        }
    }
}
