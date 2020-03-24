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
            ApiFetchData data = new ApiFetchData();
            SpaceParkCorp s = new SpaceParkCorp();

            var c = data.GetPerson("luke");
            characters.Add(new Person(c.results[0].name, (2000), 1));

            c = data.GetPerson("yoda");
            characters.Add(new Person(c.results[0].name, (2000), 2));

            characters.Add(new Person("Olle", (2000), 3));

            SpaceShip falcon = SpaceShipObjectBuilder.BuildFromApi(1);
                

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
