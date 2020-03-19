using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class Character
    {
        public string Name { get; set; }
        public decimal Wallet { get; set; }
        public int SpaceShipID { get; set; }

        public Character(string name, decimal wallet, int spaceShipId) {
            Name = name;
            Wallet = wallet;
            SpaceShipID = spaceShipId;
        }

        public int Pay()
        {

        }
    }
}
