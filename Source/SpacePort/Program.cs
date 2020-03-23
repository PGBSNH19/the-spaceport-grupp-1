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

            Console.WriteLine("Hello World!");
            APICaller data = new APICaller();
            SpaceParkCorp s = new SpaceParkCorp();


            var ship = data.GetSpaceship("");
            
        }
    }
}
