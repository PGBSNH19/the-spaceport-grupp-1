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
            List<SpaceShip> spaceShips = new List<SpaceShip>();
            
            APICaller data = new APICaller();
            SpaceParkCorp s = new SpaceParkCorp();


            var ship = data.GetSpaceship("falcon");
            Console.WriteLine(ship.results[0].passengers);
            spaceShips.Add(new SpaceShip(ship.results[0].name, double.Parse(ship.results[0].length), int.Parse(ship.results[0].passengers)));

            Console.ReadKey();
            
        }
    }
}
