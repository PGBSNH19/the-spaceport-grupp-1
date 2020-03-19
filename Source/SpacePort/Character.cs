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
            this.Name = name;
            this.Wallet = wallet;
            this.SpaceShipID = spaceShipId;
        }

        public int PayParking()
        {

        }
    }
}
