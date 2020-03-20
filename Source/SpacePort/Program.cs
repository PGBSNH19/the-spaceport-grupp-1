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
            API_Caller data = new API_Caller();
            SpaceParkCorp s = new SpaceParkCorp();
            s.Deposit(1000);
            Console.WriteLine(s.CheckBalance());
            s.Withdraw(500);
            Console.WriteLine(s.CheckBalance());
            var c = data.GetCharacter();
            Console.WriteLine(c.results[0].name);


            SpaceShip theFalcon = new SpaceShip("The Millenium Falcon", 100.13, 6);
            theFalcon.AddPassenger(new Character("Luke Skywalker", 100, 1));
            theFalcon.AddPassenger(new Character("Ben Kenobi", 100, 1));
            theFalcon.AddPassenger(new Character("C3PO", 100, 1));
            theFalcon.AddPassenger(new Character("R2D2", 100, 1));
            theFalcon.AddPassenger(new Character("Han Solo", 100, 1));
            theFalcon.AddPassenger(new Character("Chewbacca", 100, 1));
            theFalcon.AddPassenger(new Character("Darth Maul", 100, 1));

            List<Character> theFalconCrew = theFalcon.PassengerList().ToList();

            theFalcon.StartEngine();
            theFalcon.AddLogEntry("Left for Alderaan.");
            theFalcon.StopEngine();
            theFalcon.AddLogEntry("Stopped to look at remnants of Alderaan.");
            theFalcon.StartEngine();
            theFalcon.AddLogEntry("Ship caught in tractorbeam.");
            theFalcon.StopEngine();
            
            foreach (Character character in theFalconCrew)
            {
                theFalcon.RemovePassenger(character);
            }

            theFalcon.AddLogEntry("Boarded the deathstar.");

            theFalconCrew.Remove(theFalconCrew.Find(c => c.Name == "Ben Kenobi"));

            foreach (Character character in theFalconCrew)
            {
                theFalcon.AddPassenger(character);
            }

            theFalcon.StartEngine();

            foreach (string entry in theFalcon.GetShipLog())
            {
                Console.WriteLine(entry);
            }          
        }
    }
}
