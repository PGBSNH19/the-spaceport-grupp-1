using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            API_Caller data = new API_Caller();
            
            var c = data.GetCharacter();
            Console.WriteLine(c.results[0].name);
     


        }
    }
}
