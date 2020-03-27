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

            //Person person = PersonObjectBuilder.BuildFromDataBase(1);
            SpaceShip spaceShip = SpaceShipObjectBuilder.BuildFromDb(18);
            Console.WriteLine(spaceShip.Owner.Name);
            Console.ReadKey();

        }
    }
}
