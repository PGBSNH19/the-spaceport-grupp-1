using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<SpaceShip> spaceShips = new List<SpaceShip>();
            List<Person> characters = new List<Person>();
            APICaller data = new APICaller();
            SpaceParkCorp s = new SpaceParkCorp();

            var c = data.GetCharacter("luke");
            characters.Add(new Person(c.results[0].name, (2000), 1));

            c = data.GetCharacter("yoda");
            characters.Add(new Person(c.results[0].name, (2000), 2));

            characters.Add(new Person("Olle", (2000), 3));

            SpaceShip falcon = SpaceShipObjectBuilder
                .ShipName("Falcon")
                .AddEngine(new EngineComponent())
                .AddShipLog(new EventLogComponent())
                .AddPassengerModule(new PassengerCarriageComponent(111111, 6))
                .BuildShip();

            Person babyyoda = PersonObjectBuilder
                .AddName("Yoda")
                .AddSpaceShipID(1)
                .AddWallet(100)
                .BuildPerson();

            Console.WriteLine(falcon);
            Console.ReadKey();
            
            
        }
    }
}
