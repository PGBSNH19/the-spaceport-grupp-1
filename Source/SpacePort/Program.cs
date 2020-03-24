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
            List<Character> characters = new List<Character>();
            APICaller data = new APICaller();
            SpaceParkCorp s = new SpaceParkCorp();


            var ship = data.GetSpaceship("falcon");
            spaceShips.Add(new SpaceShip(ship.results[0].name, Convert.ToDouble(ship.results[0].length), int.Parse(ship.results[0].passengers)));
            ship = data.GetSpaceship("destroyer");
            Console.WriteLine(ship.results[0].name);
            spaceShips.Add(new SpaceShip(ship.results[0].name, Convert.ToDouble(ship.results[0].length), int.Parse(ship.results[0].passengers)));
            spaceShips.Add(new SpaceShip(ship.results[1].name, Convert.ToDouble(ship.results[1].length), int.Parse(ship.results[1].passengers)));

            var c = data.GetCharacter("luke");
            characters.Add(new Character(c.results[0].name, (2000.0m), 1));

            c = data.GetCharacter("yoda");
            characters.Add(new Character(c.results[0].name, (2000.0m), 2));

            characters.Add(new Character("Olle", (2000.0m), 3));

            SpaceShipObjectBuilder.Start().NameShip
            
            
        }
    }
}
