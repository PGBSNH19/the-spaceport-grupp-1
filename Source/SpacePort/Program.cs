using System;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SpaceShip s = new SpaceShip("name", 120, 1);
            s.ShipLength();
        }
    }
}
