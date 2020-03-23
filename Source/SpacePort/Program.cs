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
            
            APICaller data = new APICaller();
            SpaceParkCorp s = new SpaceParkCorp();


            var ship = data.GetSpaceship("falcon");
            Console.WriteLine(Convert.ToDouble(ship.results[0].length));
            spaceShips.Add(new SpaceShip(ship.results[0].name, Convert.ToDouble(ship.results[0].length), int.Parse(ship.results[0].passengers)));

            Console.ReadKey();
            
        }
    }
}
