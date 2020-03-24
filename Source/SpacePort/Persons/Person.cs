using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class Person
    {
        public string Name { get; set; }
        public double Wallet { get; set; }
        public int SpaceShipID { get; set; }
        public Person(string name, double wallet, int spaceShipId) {
            Name = name;
            Wallet = wallet;
            SpaceShipID = spaceShipId;
        }

        public int Pay()
        {
            return 1;
        }
    }
}
