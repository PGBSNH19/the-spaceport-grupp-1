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
            SpaceParkCorp s = new SpaceParkCorp();
            s.Deposit(1000);
            Console.WriteLine(s.CheckBalance());
            s.Withdraw(500);
            Console.WriteLine(s.CheckBalance());
            var c = data.GetCharacter();
            Console.WriteLine(c.results[0].name);
     


        }
    }
}
